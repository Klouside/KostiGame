namespace Game
{
    public class Bank
    {
        public int Balance { get; private set; }

        public Bank(int initialBalance)
        {
            Balance = initialBalance;
        }

        public void AddAmount(int amount)
        {
            Balance += amount;
        }

        public void DeductAmount(int amount)
        {
            Balance -= amount;
        }
        public void ResetBalance()
        {
            Balance = 0;
        }
    }
}
