namespace csharp
{
    public class Backstage : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;
        public int SellIn { get; set; }

        public Backstage(int quality)
        {
            _quality = new Quality(quality);
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