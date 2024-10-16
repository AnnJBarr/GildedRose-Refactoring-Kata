using FakeItEasy;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

[TestFixture]
public class BrieItemHandlerShould
{
    [TestCase("Random Item", 1)]
    [TestCase("Aged Brie",0)]
    public void Only_handle_brie(string name,int numberOfCalls)
    {
        var item = new Item { Name = name, SellIn = 2, Quality = 2 };
        var nextHandler = A.Fake<Handler>();
        var brieItemHandler = new BrieItemHandler();

        brieItemHandler.SetNextHandler(nextHandler);
        brieItemHandler.UpdateItem(item);

        A.CallTo(() => nextHandler.UpdateItem(item)).MustHaveHappenedANumberOfTimesMatching(i => i == numberOfCalls);
    }
}