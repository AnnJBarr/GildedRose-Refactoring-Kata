using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class StandardItemHandlerShould
{
    [TestCase(2, 2)]
    [TestCase(-1, 3)]
    public void Update_standard_item(int initialSellIn, int initialQuality)
    {
        var expectedQuality = initialSellIn <= 0 ? initialQuality - 2 : initialQuality - 1;
        
        var standardItem = new Item{Name = "foo", SellIn = initialSellIn, Quality = initialQuality};
        var handler = new StandardItemHandler();
        handler.UpdateItem(standardItem);

        Assert.That(standardItem.Quality, Is.EqualTo(expectedQuality));
        Assert.That(standardItem.SellIn, Is.EqualTo(initialSellIn - 1));
    }
}