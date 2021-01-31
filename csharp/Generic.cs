namespace csharp
{
    public class Generic : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;

        public int SellIn { get; set; }

        public Generic(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public void Update()
        {
            _quality.Degrade();

            SellIn = --SellIn;

            if (SellIn < 0)
            {
                _quality.Degrade();
            }
        }
    }
}