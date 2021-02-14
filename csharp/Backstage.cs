namespace csharp
{
    public class Backstage : IGood
    {
        public int SellIn { get; set; }

        public void Update(Quality quality, int? sellIn = null)
        {
            quality.Increase();

            if (sellIn < 10)  quality.Increase();
            if (sellIn < 5) quality.Increase();
            if (sellIn < 0) quality.Reset();
        }
    }
}