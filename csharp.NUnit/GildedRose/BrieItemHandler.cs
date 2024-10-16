namespace GildedRoseKata;

public class BrieItemHandler : Handler
{
    public override void UpdateItem(Item item)
    {
        if (item.Name != "Aged Brie")
        {
            NextHandler.UpdateItem(item);
            return; // untested, how do we test for this line?
        }

        item.Quality++;
    }
}