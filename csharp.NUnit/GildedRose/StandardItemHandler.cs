using System;

namespace GildedRoseKata;

public class StandardItemHandler : Handler
{
    public override void UpdateItem(Item item)
    {
        DecreaseQuality(item);
        if (HasExpired(item))
        {
            DecreaseQuality(item);
        }

        DecreaseSellIn(item);
    }
}