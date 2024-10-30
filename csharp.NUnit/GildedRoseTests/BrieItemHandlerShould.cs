using FakeItEasy;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

[TestFixture]
public class BackStagePassItemHandlerShould
{
    [Test]
    public void doThing()
    {
        //Arrange
        //Act
        //Assert
    }
}

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

    [Test]
    public void Increase_the_quality_of_brie_by_one_while_within_sellin_date()
    {
        // Arrange
        var brie = new Item { Name = "Aged Brie", SellIn = 2, Quality = 2 };
        var brieItemHandler = new BrieItemHandler();

        // Act
        brieItemHandler.UpdateItem(brie);

        // Assert
        Assert.That(brie.Quality, Is.EqualTo(3));
    }

    [Test]
    public void Do_not_increase_quality_if_non_brie_item()
    {
        // Arrange
        var item = new Item { Name = "Random Item", SellIn = 2, Quality = 2 };
        var brieItemHandler = new BrieItemHandler();
        var expectedQuality = 2;
        var nextHandler = A.Fake<Handler>();

        //Act
        brieItemHandler.SetNextHandler(nextHandler);
        brieItemHandler.UpdateItem(item);

        //Assert
        Assert.That(item.Quality, Is.EqualTo(expectedQuality));
    }

    [TestCase(0, 4)]
    [TestCase(1, 3)]
    [TestCase(-1, 4)]
    public void Increase_the_quality_of_brie_by_two_after_sellin_date(int sellin, int expectedQuality)
    {
        // Arrange
        var brie = new Item { Name = "Aged Brie", SellIn = sellin, Quality = 2 };
        var brieItemHandler = new BrieItemHandler();

        // Act
        brieItemHandler.UpdateItem(brie);

        // Assert
        Assert.That(brie.Quality, Is.EqualTo(expectedQuality));
    }

    //this tests the abstract class - could move this to another location.
    [Test]
    public void Not_increase_in_quality_beyond_maximum()
    {
        // Arrange
        var brie = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };
        var brieItemHandler = new BrieItemHandler();

        // Act
        brieItemHandler.UpdateItem(brie);

        // Assert
        Assert.That(brie.Quality, Is.EqualTo(50));
    }
    
}