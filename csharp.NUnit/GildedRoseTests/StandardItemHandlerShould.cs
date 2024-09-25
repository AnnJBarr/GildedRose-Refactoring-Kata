using FakeItEasy;
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

    [Test]
    public void Should_not_call_next_handler()
    {
        var nextHandlerFake = A.Fake<Handler>();
        var standardItemHandler = new StandardItemHandler();
        standardItemHandler.SetNextHandler(nextHandlerFake);
        var standardItem = new Item();
        
        standardItemHandler.UpdateItem(standardItem);
        
        A.CallTo(() => nextHandlerFake.UpdateItem(standardItem)).MustNotHaveHappened();
    }
}