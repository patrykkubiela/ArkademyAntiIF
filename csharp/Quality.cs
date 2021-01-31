namespace csharp
{
    public class Quality
    {
        public int Amount { get; set; }

        public Quality(int amount)
        {
            Amount = amount;
        }

        public void Degrade()
        {
            if (Amount > 0)
                Amount = --Amount;
        }

        public void Increase()
        {
            if (Amount < 50)
                Amount = ++Amount;
        }

        public void Reset()
        {
            Amount = 0;
        }

        public bool LessThan50()
        {
            return Amount < 50;
        }
    }
}