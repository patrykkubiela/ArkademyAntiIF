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
                    var sulfuras = new Sulfuras(_items[i].Quality, _items[i].SellIn);
                    sulfuras.Update();
                    _items[i].Quality = sulfuras.Quality;
                    _items[i].SellIn = sulfuras.SellIn;
                }
                else if (_items[i].IsGenericType())
                {
                    var generic = new Generic(_items[i].Quality, _items[i].SellIn);
                    generic.Update();
                    _items[i].Quality = generic.Quality;
                    _items[i].SellIn = generic.SellIn;
                }
                else if (_items[i].IsBrieType())
                {
                    var brie = new Brie(_items[i].Quality, _items[i].SellIn);
                    brie.Update();
                    _items[i].Quality = brie.Quality;
                    _items[i].SellIn = brie.SellIn;
                }
                else if (_items[i].IsBackstageType())
                {
                    var backstage = new Backstage(_items[i].Quality, _items[i].SellIn);
                    backstage.Update();
                    _items[i].Quality = backstage.Quality;
                    _items[i].SellIn = backstage.SellIn;
                }
            }
        }
    }

    public class Sulfuras
    {
        public int Quality;
        public int SellIn;

        public Sulfuras(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public void Update()
        {
            
        }
    }

    public class Backstage
    {
        public int Quality;
        public int SellIn;

        public Backstage(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public void Update()
        {
            if (Quality < 50)
            {
                Quality = ++Quality;
                if (SellIn < 11 && Quality < 50)
                {
                    Quality = ++Quality;
                }

                if (SellIn < 6 && Quality < 50)
                {
                    Quality = ++Quality;
                }
            }

            SellIn = --SellIn;

            if (SellIn < 0)
            {
                Quality = Quality - Quality;
            }
        }
    }

    public class Brie
    {
        public int Quality;
        public int SellIn;

        public Brie(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public void Update()
        {
            if (Quality < 50)
            {
                Quality = ++Quality;
            }

            SellIn = --SellIn;

            if (SellIn < 0)
            {
                if (Quality < 50)
                {
                    Quality = ++Quality;
                }
            }
        }
    }

    public class Generic
    {
        public int SellIn;
        public int Quality;

        public Generic(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public void Update()
        {
            if (Quality > 0)
            {
                Quality = --Quality;
                SellIn = --SellIn;

                if (SellIn < 0 && Quality > 0)
                {
                    Quality = --Quality;
                }
            }
        }
    }
}