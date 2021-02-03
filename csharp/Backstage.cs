namespace csharp
{
    public class Backstage : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;
        public int SellIn { get; set; }

        public Backstage(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public void Update()
        {
            _quality.Increase();

            if (SellIn < 10)  _quality.Increase();

            if (SellIn < 5) _quality.Increase();

            if (SellIn < 0) _quality.Reset();
        }
    }
}