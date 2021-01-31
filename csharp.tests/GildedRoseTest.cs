using Xunit;
using System.Collections.Generic;

namespace csharp.tests
{
    public class GildedRoseTests
    {
        [Theory]
        [InlineData(22, 8, 20)]
        [InlineData(23, 4, 20)]
        [InlineData(0, 0, 20)]
        [InlineData(23, 1, 20)]
        [InlineData(22, 6, 20)]
        [InlineData(21, 11, 20)]
        public void BackstagePasses_Quality(int expectedQuality, int givenSellIn, int givenQuality)
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

            Assert.Equal(expectedQuality, items[0].Quality);
        }

        [Theory]
        [InlineData(22, 0, 20)]
        [InlineData(21, 1, 20)]
        public void AgedBrie_Quality(int expected, int givenSellIn, int givenQuality)
        {
            var items = new List<Item> {new Item {Name = "Aged Brie", SellIn = givenSellIn, Quality = givenQuality}};
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expected, items[0].Quality);
        }

        [Theory]
        [InlineData(48, 1, 49)]
        [InlineData(47, 0, 49)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 3)]
        public void Generic_Quality_Quality(int expQuality, int givenSellIn, int givenQuality)
        {
            var items = new List<Item> {new Item {Name = "Generic", SellIn = givenSellIn, Quality = givenQuality}};
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expQuality, items[0].Quality);
        }

        [Theory]
        [InlineData(0, 1, 49)]
        [InlineData(-1, 0, 49)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(-1, 0, 3)]
        public void Generic_Quality_SellIn(int expSellIn, int givenSellIn, int givenQuality)
        {
            var items = new List<Item> {new Item {Name = "Generic", SellIn = givenSellIn, Quality = givenQuality}};
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expSellIn, items[0].SellIn);
        }

        [Theory]
        [InlineData("test", 0, -1)]
        [InlineData("", 0, -1)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0, 0)]
        public void IsSulfurasType(string givenName, int expectedQuality, int expectedSellIn)
        {
            var items = new List<Item> {new Item {Name = givenName, SellIn = 0, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(expectedSellIn, items[0].SellIn);
            Assert.Equal(expectedQuality, items[0].Quality);
        }
    }

    public class QualityTests
    {
        [Theory]
        [InlineData(20, 21)]
        [InlineData(50, 50)]
        [InlineData(51, 51)]
        public void Quality_Increase(int amount, int expectedAmount)
        {
            var quality = new Quality(amount);
            quality.Increase();

            Assert.Equal(expectedAmount, quality.Amount);
        }

        [Theory]
        [InlineData(20, true)]
        [InlineData(50, false)]
        [InlineData(51, false)]
        public void Quality_LessThan50(int amount, bool expectedResult)
        {
            var quality = new Quality(amount);
            var result = quality.LessThan50();

            Assert.Equal(expectedResult, result);
        }
    }
}