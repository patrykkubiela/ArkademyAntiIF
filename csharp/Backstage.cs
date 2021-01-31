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

            if (SellIn < 11)  _quality.Increase();

            if (SellIn < 6) _quality.Increase();

            SellIn = --SellIn;

            if (SellIn < 0) _quality.Reset();
        }
    }
}