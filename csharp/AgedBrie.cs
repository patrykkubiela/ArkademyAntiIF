namespace csharp
{
    public class AgedBrie : IGood
    {
        private readonly Quality _quality;
        public int SellIn { get; set; }

        public AgedBrie(Quality quality)
        {
            _quality = quality;
        }

        public void Update(int? sellIn = null)
        {
            _quality.Increase();
        }

        public static IGood Build(Quality quality, int sellIn)
        {
            return sellIn < 0 ? new Expired(quality) : new AgedBrie(quality);
        }

        public class Expired : IGood
        {
            private readonly Quality _quality;
            public int SellIn { get; set; }

            public Expired(Quality quality)
            {
                _quality = quality;
            }

            public void Update(int? sellIn = null)
            {
                _quality.Increase();
                _quality.Increase();
            }
        }
    }
}