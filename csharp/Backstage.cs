namespace csharp
{
    public class Backstage : IGood
    {
        private readonly Quality _quality;
        public int SellIn { get; set; }

        public Backstage(Quality quality)
        {
            _quality = quality;
        }

        public void Update(int? sellIn = null)
        {
            _quality.Increase();

            if (sellIn < 10)  _quality.Increase();
            if (sellIn < 5) _quality.Increase();
            if (sellIn < 0) _quality.Reset();
        }
    }
}