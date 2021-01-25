using System.Collections.Generic;

namespace csharp
{
    public class Quality
    {
        public int Amount { get; set; }

        public Quality(int amount)
        {
            Amount = amount;
        }

        public void Degrade()
        {
            if (Amount > 0)
                Amount = --Amount;
        }

        public void Increase()
        {
            if (Amount < 50)
                Amount = ++Amount;
        }

        public void Reset()
        {
            Amount = 0;
        }

        public bool LessThan50()
        {
            return Amount < 50;
        }
    }

    public class GoodCategory
    {
        public IGood BuildFor(Item item)
        {
            if (IsBrieType(item))
                return new AgedBrie(item.Quality, item.SellIn);
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
    }

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
                
                var goodCategory = new GoodCategory();
                var good = goodCategory.BuildFor(item);
                good.Update();
                
                item.Quality = good.Quality;
                item.SellIn = good.SellIn;
            }
        }
        
        private bool IsSulfurasType(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }

    public class Backstage : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;
        public int SellIn { get; set; }

        public Backstage(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public void Update()
        {
            _quality.Increase();

            if (_quality.LessThan50())
            {
                if (SellIn < 11)
                {
                    _quality.Increase();
                }

                if (SellIn < 6)
                {
                    _quality.Increase();
                }
            }

            SellIn = --SellIn;

            if (SellIn < 0)
            {
                _quality.Reset();
            }
        }
    }

    public class AgedBrie : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;
        public int SellIn { get; set; }

        public AgedBrie(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public void Update()
        {
            _quality.Increase();

            SellIn = --SellIn;

            if (SellIn < 0)
            {
                _quality.Increase();
            }
        }
    }

    public class Generic : IGood
    {
        private Quality _quality;

        public int Quality => _quality.Amount;

        public int SellIn { get; set; }

        public Generic(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public void Update()
        {
            _quality.Degrade();

            SellIn = --SellIn;

            if (SellIn < 0)
            {
                _quality.Degrade();
            }
        }
    }
}