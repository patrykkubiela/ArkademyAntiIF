namespace csharp
{
    public class AgedBrie : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;
        public int SellIn { get; set; }

        public AgedBrie(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public void Update()
        {
            _quality.Increase();

            SellIn = --SellIn;

            if (SellIn < 0)
            {
                _quality.Increase();
            }
        }
    }
}