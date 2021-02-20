namespace csharp
{
    public class GoodCategory
    {
        public IGood BuildFor(Item item, Quality quality)
        {
            switch (item.Name)
            {
                case "Aged Brie": return AgedBrie.Build(quality, item.SellIn);
                case "Backstage passes to a TAFKAL80ETC concert": return Backstage.Build(quality, item.SellIn);
                default: return Generic.Build(quality, item.SellIn);
            }
        }
    }
}