using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void GenericHandle(Item item)
        {

            if (item.Quality > 0)
            {
                item.DecreaseQuality();
                item.DecreaseSellIn();

                if (item.SellIn < 0)
                {
                    if (item.Quality > 0)
                    {
                        item.DecreaseQuality();
                    }
                }
            }
        }

        public void BackstageHandle(Item item)
        {
            if (item.IsQualityLessThanMax())
            {
                item.IncreaseQuality();
                if (item.SellIn < 11)
                {
                    if (item.IsQualityLessThanMax())
                    {
                        item.IncreaseQuality();
                    }
                }

                if (item.SellIn < 6)
                {
                    if (item.IsQualityLessThanMax())
                    {
                        item.IncreaseQuality();
                    }
                }
            }

            item.DecreaseSellIn();

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        public void BrieHandle(Item item)
        {
            if (item.IsQualityLessThanMax())
            {
                item.IncreaseQuality();
            }
            item.DecreaseSellIn();

            if (item.SellIn < 0)
            {
                if (item.IsQualityLessThanMax())
                {
                    item.IncreaseQuality();
                }
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].IsSulfurasType()) { }
                else if (_items[i].IsGenericType())
                {
                    GenericHandle(_items[i]);
                }
                else if (_items[i].IsBrieType())
                {
                    BrieHandle(_items[i]);
                }
                else if (_items[i].IsBackstageType())
                {
                    BackstageHandle(_items[i]);
                }
            }
        }
    }
}