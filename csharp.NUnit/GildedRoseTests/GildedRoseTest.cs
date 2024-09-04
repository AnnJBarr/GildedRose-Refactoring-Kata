using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseShould
{
    [Test]
    public void UpdateQuality_by_reducing_non_special_item_quality_by_1_while_within_sellin_date()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 2 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(1));
    }
    
    [Test]
    public void UpdateQuality_by_reducing_non_special_item_quality_by_2_after_sellin_date()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 2 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
    
    [Test]
    public void Never_allow_quality_to_go_negative_when_UpdateQuality_called()
    {
        var items = new List<Item>
        {
            new Item { Name = "foo", SellIn = 0, Quality = 1 },
            new Item { Name = "item2", SellIn = 1, Quality = 0 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Multiple(() =>
        {
            Assert.That(items[0].Quality, Is.EqualTo(0));
            Assert.That(items[1].Quality, Is.EqualTo(0));    
        });
    }

    [Test]
    public void UpdateQuality_by_increasing_brie_quality_by_1_while_within_sellin_date()
    {
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 1, Quality = 2 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(3));
    }
    
    [Test]
    public void UpdateQuality_by_increasing_brie_quality_by_2_after_sellin_date()
    {
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 2 },
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 3 }
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Multiple(() =>
        {
            Assert.That(items[0].Quality, Is.EqualTo(4));
            Assert.That(items[1].Quality, Is.EqualTo(5));    
        });
    }
    
    [Test]
    public void Never_allow_quality_to_go_over_50()
    {
        var items = new List<Item>
        {
            new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 },
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 },
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 },
        };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Multiple(() =>
        {
            Assert.That(items[0].Quality, Is.EqualTo(50));
            Assert.That(items[1].Quality, Is.EqualTo(50));
            Assert.That(items[2].Quality, Is.EqualTo(50));    
        });
    }
    
    [Test]
    public void Never_decrease_quality_of_Legendary_Items_when_UpdateQuality_called()
    {
        var items = new List<Item>()
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 12 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 12 }
        };

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Multiple(() =>
        {
            Assert.That(items[0].Quality, Is.EqualTo(12));
            Assert.That(items[1].Quality, Is.EqualTo(12));    
        });
    }
    
    [Test]
    public void Never_decrease_sellIn_of_Legendary_Items_when_UpdateQuality_called()
    {
        var items = new List<Item>()
        {
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 12 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 12 }
        };

        var app = new GildedRose(items);
        app.UpdateQuality();

        Assert.Multiple(() =>
        {
            Assert.That(items[0].SellIn, Is.EqualTo(0));
            Assert.That(items[1].SellIn, Is.EqualTo(5));    
        });
    }
}