using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
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
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].IsSulfurasType()) { }
                else if (Items[i].IsGenericType() && Items[i].Quality > 0)
                {
                    Items[i].DecreaseQuality();
                }
                else if (Items[i].IsBrieType())
                {
                    if (Items[i].IsQualityLessThanMax())
                    {
                        Items[i].IncreaseQuality();
                    }
                }
                else if (Items[i].IsBackstageType())
                {
                    BackstageHandle(Items[i]);
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
