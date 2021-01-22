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

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].IsSulfurasType())
                {
                }
                else if (_items[i].IsGenericType())
                {
                    if (_items[i].Quality > 0)
                    {
                        _items[i].Quality = --_items[i].Quality;
                        _items[i].SellIn = --_items[i].SellIn;

                        if (_items[i].SellIn < 0)
                        {
                            if (_items[i].Quality > 0)
                            {
                                _items[i].Quality = --_items[i].Quality;
                            }
                        }
                    }
                }
                else if (_items[i].IsBrieType())
                {
                    if (_items[i].IsQualityLessThanMax())
                    {
                        _items[i].Quality = ++_items[i].Quality;
                    }

                    _items[i].SellIn = --_items[i].SellIn;

                    if (_items[i].SellIn < 0)
                    {
                        if (_items[i].IsQualityLessThanMax())
                        {
                            _items[i].Quality = ++_items[i].Quality;
                        }
                    }
                }
                else if (_items[i].IsBackstageType())
                {
                    if (_items[i].IsQualityLessThanMax())
                    {
                        _items[i].Quality = ++_items[i].Quality;
                        if (_items[i].SellIn < 11)
                        {
                            if (_items[i].IsQualityLessThanMax())
                            {
                                _items[i].Quality = ++_items[i].Quality;
                            }
                        }

                        if (_items[i].SellIn < 6)
                        {
                            if (_items[i].IsQualityLessThanMax())
                            {
                                _items[i].Quality = ++_items[i].Quality;
                            }
                        }
                    }

                    _items[i].SellIn = --_items[i].SellIn;

                    if (_items[i].SellIn < 0)
                    {
                        _items[i].Quality = _items[i].Quality - _items[i].Quality;
                    }
                }
            }
        }
    }
}