namespace csharp
{
    public class GoodCategory
    {
        public IGood BuildFor(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie": return new AgedBrie(item.Quality);
                case "Backstage passes to a TAFKAL80ETC concert": return new Backstage(item.Quality);
                default: return new Generic(item.Quality);
            }
        }
    }
}