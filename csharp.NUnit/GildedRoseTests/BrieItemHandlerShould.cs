using FakeItEasy;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

[TestFixture]
public class BrieItemHandlerShould
{
    [Test]
    public void Only_handle_brie()
    {
        var item = new Item { Name = "Random Item", SellIn = 2, Quality = 2 };
        var nextHandler = A.Fake<Handler>();
        var brieItemHandler = new BrieItemHandler();

        brieItemHandler.SetNextHandler(nextHandler);
        brieItemHandler.UpdateItem(item);

        A.CallTo(() => nextHandler.UpdateItem(item)).MustHaveHappened();
    }
}

public class BrieItemHandler : Handler
{
    public override void UpdateItem(Item item)
    {
        NextHandler.UpdateItem(item);
    }
}