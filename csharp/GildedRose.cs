using System.Collections.Generic;

namespace csharp
{
    public interface IGood
    {
        public int Quality { get; }
        public int SellIn { get; set; }
        public void Update(int sellIn);
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
                if (item.Name == "Sulfuras, Hand of Ragnaros") continue;

                item.SellIn -= 1;
                var goodCategory = new GoodCategory();
                var good = goodCategory.BuildFor(item);
                good.Update(item.SellIn);

                item.Quality = good.Quality;
            }
        }
    }
}