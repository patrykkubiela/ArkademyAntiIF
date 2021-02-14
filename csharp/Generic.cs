namespace csharp
{
    public class Generic : IGood
    {
        public int SellIn { get; set; }

        public void Update(Quality quality, int? sellIn = null)
        {
            quality.Degrade();
        }
        
        public static IGood Build(Quality quality, int sellIn)
        {
            return sellIn < 0 ? new Expired() : new Generic();
        }

        public class Expired : IGood
        {
            public int SellIn { get; set; }

            public void Update(Quality quality, int? sellIn = null)
            {
                quality.Degrade();
                quality.Degrade();
            }
        }
    }
}