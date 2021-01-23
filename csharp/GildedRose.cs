using System.Collections.Generic;

namespace csharp
{
    public class GoodCategory
    {
        public IGood BuildFor(Item item)
        {
            if (IsSulfurasType(item))
                return new Sulfuras(item.Quality, item.SellIn);
            else if (IsBrieType(item))
                return new Brie(item.Quality, item.SellIn);
            else if (IsBackstageType(item))
                return new Backstage(item.Quality, item.SellIn);

            return new Generic(item.Quality, item.SellIn);
        }

        private bool IsBrieType(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private bool IsBackstageType(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsSulfurasType(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }

    public interface IGood
    {
        public int Quality { get; set; }
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
            for (var i = 0; i < _items.Count; i++)
            {
                var goodCategory = new GoodCategory();
                var good = goodCategory.BuildFor(_items[i]);
                good.Update();
                _items[i].Quality = good.Quality;
                _items[i].SellIn = good.SellIn;
            }
        }
    }

    public class Sulfuras : IGood
    {
        public Sulfuras(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public int Quality { get; set; }
        public int SellIn { get; set; }

        public void Update()
        {
        }
    }

    public class Backstage : IGood
    {
        public int Quality { get; set; }
        public int SellIn { get; set; }

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

    public class Brie : IGood
    {
        public int Quality { get; set; }
        public int SellIn { get; set; }

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

    public class Generic : IGood
    {
        public int Quality { get; set; }
        public int SellIn { get; set; }

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