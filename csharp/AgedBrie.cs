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