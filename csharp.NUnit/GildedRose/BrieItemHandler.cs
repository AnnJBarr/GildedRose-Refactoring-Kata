namespace GildedRoseKata;

public class BrieItemHandler : Handler
{
    public override void UpdateItem(Item item)
    {
        if (item.Name != "Aged Brie")
        {
            NextHandler.UpdateItem(item);
            return;
        }

        IncreaseQuality(item);
        if (item.SellIn < 1) IncreaseQuality(item);
    }
}