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
}