﻿using System.Collections.Generic;

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
        foreach (var item in Items)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (QualityNotMin(item))
                    if (IsStandardItem(item)) ChangeQuality(item,-1);
            }
            else
            {
                if (QualityNotMax(item))
                {
                    ChangeQuality(item,1);

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (QualityNotMax(item)) ChangeQuality(item,1);
                        }

                        if (item.SellIn < 6)
                        {
                            if (QualityNotMax(item)) ChangeQuality(item,1);
                        }
                    }
                }
            }

            if (IsStandardItem(item)) item.SellIn = item.SellIn - 1;

            if (HasExpired(item))
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (QualityNotMin(item))
                        {
                            if (IsStandardItem(item)) ChangeQuality(item,-1);
                        }
                    }
                    else
                    {
                        ChangeQuality(item,-item.Quality);
                    }
                }
                else
                {
                    if (QualityNotMax(item)) ChangeQuality(item,1);
                }
            }
        }
    }

    private static bool IsStandardItem(Item item)
    {
        return item.Name != "Sulfuras, Hand of Ragnaros";
    }

    private static bool QualityNotMin(Item item)
    {
        return item.Quality > 0;
    }

    private static bool HasExpired(Item item)
    {
        return item.SellIn < 0;
    }

    private static bool QualityNotMax(Item item) => item.Quality < 50;

    private static void ChangeQuality(Item item, int amount) => item.Quality += amount;
}