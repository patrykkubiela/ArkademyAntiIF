namespace csharp
{
    public class AgedBrie : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;
        public int SellIn { get; set; }

        public AgedBrie(int quality)
        {
            _quality = new Quality(quality);
        }

        public void Update(int? sellIn = null)
        {
            _quality.Increase();
        }

        public static IGood Build(int quality, int sellIn)
        {
            return sellIn < 0 ? new Expired(quality) : new AgedBrie(quality);
        }
        
        public class Expired :IGood
        {
            private Quality _quality;

            public int Quality => _quality.Amount;
            public int SellIn { get; set; }

            public Expired(int quality)
            {
                _quality = new Quality(quality);
            }

            public void Update(int? sellIn = null)
            {
                _quality.Increase();
                _quality.Increase();
            }
        }
    }
}