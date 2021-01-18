using System.Collections.Generic;

namespace csharp
{
    public static class ItemExtensions
    {
        public static int IncreaseQuality(this Item item)
        {
            item.Quality = ++item.Quality;
            return item.Quality;
        }

        public static int DecreaseQuality(this Item item)
        {
            item.Quality = --item.Quality;
            return item.Quality;
        }
        
        public static int DecreaseSellIn(this Item item)
        {
            item.SellIn = --item.SellIn;
            return item.SellIn;
        }

        public static bool IsQualityLessThanMax(this Item item)
        {
            return item.Quality < 50;
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

    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (!Items[i].IsBrieType() && !Items[i].IsBackstageType())
                {
                    if (Items[i].Quality > 0)
                    {
                        if (!Items[i].IsSulfurasType())
                        {
                            Items[i].DecreaseQuality();
                        }
                    }
                }
                else
                {
                    if (Items[i].IsQualityLessThanMax())
                    {
                        Items[i].IncreaseQuality();

                        if (Items[i].IsBackstageType())
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].IsQualityLessThanMax())
                                {
                                    Items[i].IncreaseQuality();
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].IsQualityLessThanMax())
                                {
                                    Items[i].IncreaseQuality();
                                }
                            }
                        }
                    }
                }

                if (!Items[i].IsSulfurasType())
                {
                    Items[i].DecreaseSellIn();
                }

                if (Items[i].SellIn < 0)
                {
                    if (!Items[i].IsBrieType())
                    {
                        if (!Items[i].IsBackstageType())
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (!Items[i].IsSulfurasType())
                                {
                                    Items[i].DecreaseQuality();
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].IsQualityLessThanMax())
                        {
                            Items[i].IncreaseQuality();
                        }
                    }
                }
            }
        }
    }
}
