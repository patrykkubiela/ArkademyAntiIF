﻿using System.Collections.Generic;

namespace csharp
{
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
                if (Items[i].IsSulfurasType()) { }
                else if (Items[i].IsGenericType())
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
