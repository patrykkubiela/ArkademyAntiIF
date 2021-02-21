namespace csharp
{
    public class AgedBrie : IGood
    {
        public int SellIn { get; set; }
        
        public void Update(Quality quality)
        {
            quality.Increase();
        }

        public static IGood Build(int sellIn)
        {
            return sellIn < 0 ? new Expired() : new AgedBrie();
        }

        public class Expired : IGood
        {
            public int SellIn { get; set; }

            public void Update(Quality quality)
            {
                quality.Increase();
                quality.Increase();
            }
        }
    }
}