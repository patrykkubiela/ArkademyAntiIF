namespace csharp
{
    public class Generic : IGood
    {
        public int SellIn { get; set; }

        public void Update(Quality quality, int? sellIn = null)
        {
            quality.Degrade();
            if (sellIn < 0)
            {
                quality.Degrade();
            }
        }
    }
}