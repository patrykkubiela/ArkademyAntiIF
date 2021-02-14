namespace csharp
{
    public class AgedBrie : IGood
    {
        public int SellIn { get; set; }
        
        public void Update(Quality quality, int? sellIn = null)
        {
            quality.Increase();
        }

        public static IGood Build(Quality quality, int sellIn)
        {
            return sellIn < 0 ? new Expired() : new AgedBrie();
        }

        public class Expired : IGood
        {
            public int SellIn { get; set; }

            public void Update(Quality quality, int? sellIn = null)
            {
                quality.Increase();
                quality.Increase();
            }
        }
    }
}