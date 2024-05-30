using Game;
using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; set; }
    public int Bet { get; set; }
    public List<int> Dices { get; set; }
    public bool HasLastAce { get; private set; }
    private static Random random = new Random();

    public Player(string name, int bet)
    {
        Name = name;
        Bet = bet;
        Dices = new List<int>();
        HasLastAce = false;
        InitializeDices();
    }

    public void InitializeDices()
    {
        Dices.Clear();
        for (int i = 0; i < 5; i++)
        {
            Dices.Add(random.Next(1, 7));
        }
    }

    public List<int> RollDice()
    {
        var diceValues = new List<int>();
        for (int i = 0; i < Dices.Count; i++)
        {
            Dices[i] = random.Next(1, 7);
            diceValues.Add(Dices[i]);
        }
        Console.WriteLine($"[{Name}] RollDice: {string.Join(", ", diceValues)}");
        return diceValues;
    }

    public void TransferDice(Player leftPlayer, Player rightPlayer, Form1 form)
    {
        var dicesToRemove = new List<int>();
        foreach (var dice in Dices)
        {
            if (dice == 2)
            {
                leftPlayer.Dices.Add(dice);
                form.LogAction($"{Name} передает двойку игроку слева {leftPlayer.Name}");
                dicesToRemove.Add(dice);
            }
            else if (dice == 5)
            {
                rightPlayer.Dices.Add(dice);
                form.LogAction($"{Name} передает пятерку игроку справа {rightPlayer.Name}");
                dicesToRemove.Add(dice);
            }
        }
        dicesToRemove.ForEach(dice => Dices.Remove(dice));
    }
}
