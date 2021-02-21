namespace csharp
{
    public class Generic : IGood
    {
        public int SellIn { get; set; }

        public void Update(Quality quality)
        {
            quality.Degrade();
        }
        
        public static IGood Build(int sellIn)
        {
            return sellIn < 0 ? new Expired() : new Generic();
        }

        public class Expired : IGood
        {
            public int SellIn { get; set; }

            public void Update(Quality quality)
            {
                quality.Degrade();
                quality.Degrade();
            }
        }
    }
}