namespace csharp
{
    public class Generic : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;

        public int SellIn { get; set; }

        public Generic(int quality)
        {
            _quality = new Quality(quality);
        }

        public void Update(int sellIn)
        {
            _quality.Degrade();
            if (sellIn < 0)
            {
                _quality.Degrade();
            }
        }
    }
}