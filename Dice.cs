using System;
using System.Collections.Generic;

namespace Game
{
    public class Dice
    {
        public int Quantity { get; set; }
        public List<int> Values { get; private set; }

        public Dice(int quantity)
        {
            Quantity = quantity;
            Values = new List<int>(quantity);
            Roll();
        }

        public void Roll()
        {
            Random random = new Random();
            Values.Clear();
            for (int i = 0; i < Quantity; i++)
            {
                Values.Add(random.Next(1, 7));
            }
        }
    }
}
