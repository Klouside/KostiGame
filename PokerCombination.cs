using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class PokerCombination : IComparable<PokerCombination>
    {
        public List<int> Dices { get; private set; }
        public int CombinationRank { get; private set; }
        public List<int> HighDiceValues { get; private set; }

        public PokerCombination(List<int> dices)
        {
            Dices = dices;
            CalculateCombinationRank();
        }

        private void CalculateCombinationRank()
        {
            if (Dices == null || !Dices.Any())
            {
                throw new InvalidOperationException("Список костей пуст.");
            }

            var diceCounts = Dices.GroupBy(d => d)
                                  .Select(g => new { Value = g.Key, Count = g.Count() })
                                  .OrderByDescending(g => g.Count)
                                  .ThenByDescending(g => g.Value == 1 ? 7 : g.Value)
                                  .ToList();

            HighDiceValues = diceCounts.Select(g => g.Value == 1 ? 7 : g.Value).ToList();
            CombinationRank = diceCounts.First().Count * 10 + (HighDiceValues.First() == 7 ? 1 : HighDiceValues.First());
        }


        public int CompareTo(PokerCombination other)
        {
            int result = CombinationRank.CompareTo(other.CombinationRank);
            if (result == 0)
            {
                for (int i = 0; i < HighDiceValues.Count && i < other.HighDiceValues.Count; i++)
                {
                    result = HighDiceValues[i].CompareTo(other.HighDiceValues[i]);
                    if (result != 0) break;
                }
            }
            return result;
        }
    }
}