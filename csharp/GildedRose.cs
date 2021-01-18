using System.Collections.Generic;

namespace csharp
{
    public static class GildedRoseExtensions
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
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
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

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
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

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].DecreaseSellIn();
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
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
