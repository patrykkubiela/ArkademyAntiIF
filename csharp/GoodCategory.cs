namespace csharp
{
    public class GoodCategory
    {
        public IGood BuildFor(Item item, Quality quality)
        {
            switch (item.Name)
            {
                case "Aged Brie": return AgedBrie.Build(item.SellIn);
                case "Backstage passes to a TAFKAL80ETC concert": return Backstage.Build(item.SellIn);
                case "Conjured Mana Cake": return Conjured.Build(item.SellIn);
                default: return Generic.Build(item.SellIn);
            }
        }
    }
}