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
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].IsSulfurasType()) { }
                else if (_items[i].IsGenericType() && _items[i].Quality > 0)
                {
                    _items[i].DecreaseQuality();
                    _items[i].DecreaseSellIn();

                    if (_items[i].SellIn < 0)
                    {
                        if (_items[i].Quality > 0)
                        {
                            _items[i].DecreaseQuality();
                        }
                    }
                }
                else if (_items[i].IsBrieType())
                {
                    if (_items[i].IsQualityLessThanMax())
                    {
                        _items[i].IncreaseQuality();
                    }
                    _items[i].DecreaseSellIn();

                    if (_items[i].SellIn < 0)
                    {
                        if (_items[i].IsQualityLessThanMax())
                        {
                            _items[i].IncreaseQuality();
                        }
                    }
                }
                else if (_items[i].IsBackstageType())
                {
                    BackstageHandle(_items[i]);

                    if (_items[i].SellIn < 0)
                    {
                        _items[i].Quality = _items[i].Quality - _items[i].Quality;
                    }
                }
            }
        }
    }
}