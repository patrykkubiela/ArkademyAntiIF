using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace csharp.tests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void TestReport()
        {
            var reportLines = new List<string>();
            reportLines.Add("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);


            for (var i = 0; i < 8; i++)
            {
                reportLines.Add("-------- day " + i + " --------");
                reportLines.Add("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    reportLines.Add(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                reportLines.Add("");
                app.UpdateQuality();
            }

            reportLines.Should().Equal(new List<string>{
"OMGHAI!"
,"-------- day 0 --------"
,"name, sellIn, quality"
,"+5 Dexterity Vest, 10, 20"
,"Aged Brie, 2, 0"
,"Elixir of the Mongoose, 5, 7"
,"Sulfuras, Hand of Ragnaros, 0, 80"
,"Sulfuras, Hand of Ragnaros, -1, 80"
,"Backstage passes to a TAFKAL80ETC concert, 15, 20"
,"Backstage passes to a TAFKAL80ETC concert, 10, 49"
,"Backstage passes to a TAFKAL80ETC concert, 5, 49"
,"Conjured Mana Cake, 3, 6"
,""
,"-------- day 1 --------"
,"name, sellIn, quality"
,"+5 Dexterity Vest, 9, 19"
,"Aged Brie, 1, 1"
,"Elixir of the Mongoose, 4, 6"
,"Sulfuras, Hand of Ragnaros, 0, 80"
,"Sulfuras, Hand of Ragnaros, -1, 80"
,"Backstage passes to a TAFKAL80ETC concert, 14, 21"
,"Backstage passes to a TAFKAL80ETC concert, 9, 50"
,"Backstage passes to a TAFKAL80ETC concert, 4, 50"
,"Conjured Mana Cake, 2, 5"
,""
,"-------- day 2 --------"
,"name, sellIn, quality"
,"+5 Dexterity Vest, 8, 18"
,"Aged Brie, 0, 2"
,"Elixir of the Mongoose, 3, 5"
,"Sulfuras, Hand of Ragnaros, 0, 80"
,"Sulfuras, Hand of Ragnaros, -1, 80"
,"Backstage passes to a TAFKAL80ETC concert, 13, 22"
,"Backstage passes to a TAFKAL80ETC concert, 8, 50"
,"Backstage passes to a TAFKAL80ETC concert, 3, 50"
,"Conjured Mana Cake, 1, 4"
,""
,"-------- day 3 --------"
,"name, sellIn, quality"
,"+5 Dexterity Vest, 7, 17"
,"Aged Brie, -1, 4"
,"Elixir of the Mongoose, 2, 4"
,"Sulfuras, Hand of Ragnaros, 0, 80"
,"Sulfuras, Hand of Ragnaros, -1, 80"
,"Backstage passes to a TAFKAL80ETC concert, 12, 23"
,"Backstage passes to a TAFKAL80ETC concert, 7, 50"
,"Backstage passes to a TAFKAL80ETC concert, 2, 50"
,"Conjured Mana Cake, 0, 3"
,""
,"-------- day 4 --------"
,"name, sellIn, quality"
,"+5 Dexterity Vest, 6, 16"
,"Aged Brie, -2, 6"
,"Elixir of the Mongoose, 1, 3"
,"Sulfuras, Hand of Ragnaros, 0, 80"
,"Sulfuras, Hand of Ragnaros, -1, 80"
,"Backstage passes to a TAFKAL80ETC concert, 11, 24"
,"Backstage passes to a TAFKAL80ETC concert, 6, 50"
,"Backstage passes to a TAFKAL80ETC concert, 1, 50"
,"Conjured Mana Cake, -1, 1"
,""
,"-------- day 5 --------"
,"name, sellIn, quality"
,"+5 Dexterity Vest, 5, 15"
,"Aged Brie, -3, 8"
,"Elixir of the Mongoose, 0, 2"
,"Sulfuras, Hand of Ragnaros, 0, 80"
,"Sulfuras, Hand of Ragnaros, -1, 80"
,"Backstage passes to a TAFKAL80ETC concert, 10, 25"
,"Backstage passes to a TAFKAL80ETC concert, 5, 50"
,"Backstage passes to a TAFKAL80ETC concert, 0, 50"
,"Conjured Mana Cake, -2, 0"
,""
,"-------- day 6 --------"
,"name, sellIn, quality"
,"+5 Dexterity Vest, 4, 14"
,"Aged Brie, -4, 10"
,"Elixir of the Mongoose, -1, 0"
,"Sulfuras, Hand of Ragnaros, 0, 80"
,"Sulfuras, Hand of Ragnaros, -1, 80"
,"Backstage passes to a TAFKAL80ETC concert, 9, 27"
,"Backstage passes to a TAFKAL80ETC concert, 4, 50"
,"Backstage passes to a TAFKAL80ETC concert, -1, 0"
,"Conjured Mana Cake, -3, 0"
,""
,"-------- day 7 --------"
,"name, sellIn, quality"
,"+5 Dexterity Vest, 3, 13"
,"Aged Brie, -5, 12"
,"Elixir of the Mongoose, -2, 0"
,"Sulfuras, Hand of Ragnaros, 0, 80"
,"Sulfuras, Hand of Ragnaros, -1, 80"
,"Backstage passes to a TAFKAL80ETC concert, 8, 29"
,"Backstage passes to a TAFKAL80ETC concert, 3, 50"
,"Backstage passes to a TAFKAL80ETC concert, -2, 0"
,"Conjured Mana Cake, -4, 0"
,""});
        }
    }
}
