using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class Game
    {
        public static List<int> CenterDices { get; private set; }
        public List<Player> Players { get; private set; }
        public int CurrentPlayerIndex { get; private set; }
        public string Winner { get; private set; }
        private readonly Form1 form;
        private readonly Bank bank;

        public Game(List<Player> players, Bank bank, Form1 form)
        {
            Players = players;
            CurrentPlayerIndex = 0;
            CenterDices = new List<int>();
            Winner = string.Empty;
            this.form = form;
            this.bank = bank;
        }

        public void DeterminePlayerOrder()
        {
            form.LogAction("Определение порядка игроков:");

            var playerCombinations = Players.Select(player =>
            {
                var diceValues = player.Dices;
                var combination = new PokerCombination(diceValues);
                return (player, combination);
            }).ToList();

            playerCombinations.Sort((x, y) => y.combination.CompareTo(x.combination));
            Players = playerCombinations.Select(x => x.player).ToList();
            CurrentPlayerIndex = 0;

            form.LogAction("Порядок игроков:");
            Players.ForEach(player => form.LogAction(player.Name));
        }

        public void NextTurn()
        {
            var currentPlayer = Players[CurrentPlayerIndex];

            var diceValues = currentPlayer.RollDice();
            form.LogAction($"Текущие кости у {currentPlayer.Name}: {string.Join(", ", currentPlayer.Dices)}");
            form.UpdateDiceImages(currentPlayer.Dices);

            var leftPlayer = GetLeftPlayer();
            var rightPlayer = GetRightPlayer();
            currentPlayer.TransferDice(leftPlayer, rightPlayer, form);

            var onesToCenter = currentPlayer.Dices.Where(dice => dice == 1).ToList();
            onesToCenter.ForEach(one =>
            {
                CenterDices.Add(one);
                form.LogAction($"{currentPlayer.Name} поместил единицу в центр стола.");
            });
            currentPlayer.Dices.RemoveAll(dice => dice == 1);
            form.UpdateCenterDiceImages();

            if (!Players.Any(player => player.Dices.Count > 0))
            {
                form.LogAction("Игра завершена, все кубики помещены в центр стола.");
                EndGame(bank);
                form.UpdateUI();
                return;
            }

            if (currentPlayer.Dices.Count == 0)
            {
                form.LogAction($"{currentPlayer.Name} передает ход, так как у него закончились кубики.");
                if (Players.All(player => player.Dices.Count == 0))
                {
                    form.LogAction("Игра завершена, все кубики помещены в центр стола.");
                    EndGame(bank);
                    form.UpdateUI();
                    return;
                }
                MoveToNextPlayerWithDice();
            }
            else if (ShouldContinueTurn(diceValues))
            {
                form.LogAction($"{currentPlayer.Name} продолжает ход из-за выпавших 1, 2 или 5.");
            }
            else
            {
                MoveToNextPlayerWithDice();
            }

            form.UpdateUI();
        }

        private void MoveToNextPlayerWithDice()
        {
            do
            {
                CurrentPlayerIndex = (CurrentPlayerIndex + 1) % Players.Count;
            } while (Players[CurrentPlayerIndex].Dices.Count == 0);
        }

        private bool ShouldContinueTurn(List<int> diceValues)
        {
            return diceValues.Any(value => value == 1 || value == 2 || value == 5);
        }

        private Player GetLeftPlayer()
        {
            return Players[(CurrentPlayerIndex + 1) % Players.Count];
        }

        private Player GetRightPlayer()
        {
            return CurrentPlayerIndex == 0 ? Players[Players.Count - 1] : Players[CurrentPlayerIndex - 1];
        }

        public void EndGame(Bank bank)
        {
            Winner = Players.FirstOrDefault(player => player.Dices.Contains(1))?.Name ?? Players[CurrentPlayerIndex].Name;
            bank.ResetBalance();
        }

        public Player GetCurrentPlayer()
        {
            if (CurrentPlayerIndex >= 0 && CurrentPlayerIndex < Players.Count)
            {
                return Players[CurrentPlayerIndex];
            }
            return null;
        }
    }
}