namespace csharp
{
    public class Generic : IGood
    {
        private readonly Quality _quality;

        public int SellIn { get; set; }

        public Generic(Quality quality)
        {
            _quality = quality;
        }

        public void Update(int? sellIn = null)
        {
            _quality.Degrade();
            if (sellIn < 0)
            {
                _quality.Degrade();
            }
        }
    }
}