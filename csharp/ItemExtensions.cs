namespace csharp
{
    public static class ItemExtensions
    {
        public static bool IsGenericType(this Item item)
        {
            return !item.IsBackstageType() && !item.IsBrieType() && !item.IsSulfurasType();
        }

        public static bool IsBrieType(this Item item)
        {
            return item.Name == "Aged Brie";
        }

        public static bool IsBackstageType(this Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public static bool IsSulfurasType(this Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}