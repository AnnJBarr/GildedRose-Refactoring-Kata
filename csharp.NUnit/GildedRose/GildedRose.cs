using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        //can we encapsulate this logic anywhere else?
        foreach (var item in Items)
        {
            if (!IsBrie(item) && !IsBackstagePass(item))
            {
                if (QualityNotMin(item) && IsStandardItem(item)) Handler.DecreaseQuality(item);
            }
            else
            {
                if (QualityNotMax(item))
                {
                    IncreaseQuality(item);

                    if (IsBackstagePass(item))
                    {
                        if (item.SellIn < 11 && QualityNotMax(item)) IncreaseQuality(item);

                        if (item.SellIn < 6 && QualityNotMax(item)) IncreaseQuality(item);
                    }
                }
            }

            if (IsStandardItem(item)) Handler.DecreaseSellIn(item);

            if (Handler.HasExpired(item))
            {
                if (!IsBrie(item))
                {
                    if (!IsBackstagePass(item))
                    {
                        if (QualityNotMin(item) && IsStandardItem(item)) Handler.DecreaseQuality(item);
                    }
                    else
                    {
                        ReduceQualityToZero(item);
                    }
                }
                else
                {
                    if (QualityNotMax(item)) IncreaseQuality(item);
                }
            }
        }
    }

    private static void ReduceQualityToZero(Item item)
    {
        item.Quality = 0;
    }

    private static void IncreaseQuality(Item item)
    {
        Handler.ChangeQuality(item,1);
    }

    private static bool IsBrie(Item item)
    {
        return item.Name == "Aged Brie";
    }

    private static bool IsBackstagePass(Item item)
    {
        return item.Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    private static bool IsStandardItem(Item item)
    {
        return item.Name != "Sulfuras, Hand of Ragnaros";
    }

    private static bool QualityNotMin(Item item)
    {
        return item.Quality > 0;
    }

    private static bool QualityNotMax(Item item) => item.Quality < 50;
}