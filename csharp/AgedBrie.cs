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

        public void Update(int sellIn)
        {
            _quality.Increase();
            if (sellIn < 0)
            {
                _quality.Increase();
            }
        }
    }
}