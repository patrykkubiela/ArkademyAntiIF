using System.Collections.Generic;

namespace csharp
{
    public interface IGood
    {
        public int Quality { get; }
        public int SellIn { get; set; }
        public void Update();
    }

    public class GildedRose
    {
        readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (IsSulfurasType(item)) continue;

                item.SellIn -= 1;
                var goodCategory = new GoodCategory();
                var good = goodCategory.BuildFor(item);
                good.Update();

                item.Quality = good.Quality;
            }
        }

        private bool IsSulfurasType(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}