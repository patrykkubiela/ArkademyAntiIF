using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace csharp.tests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(22, 8, 20)]
        [InlineData(23, 4, 20)]
        [InlineData(0, 0, 20)]
        public void BackstagePasses_Quality(int expected, int givenSellIn, int givenQuality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = givenSellIn, Quality = givenQuality
                }
            };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expected, items[0].Quality);
        }

       [Theory]
        [InlineData(22, 0, 20)]
        public void AgedBrie_Quality(int expected, int givenSellIn, int givenQuality)
        {
            var items = new List<Item> {new Item {Name = "Aged Brie", SellIn = givenSellIn, Quality = givenQuality}};
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expected, items[0].Quality);
        }
        
        [Theory]
        [InlineData(48, 0, 1, 49)]
        [InlineData(47, -1, 0, 49)]
        [InlineData(0, 0, 1, 0)]
        [InlineData(0, 0, 1, 1)]
        [InlineData(1, -1, 0, 3)]

        public void Generic_Quality(int expQuality, int expSellIn, int givenSellIn, int givenQuality)
        {
            var items = new List<Item> {new Item {Name = "Generic", SellIn = givenSellIn, Quality = givenQuality}};
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expQuality, items[0].Quality);
            Assert.Equal(expSellIn, items[0].SellIn);
        }
    }
}