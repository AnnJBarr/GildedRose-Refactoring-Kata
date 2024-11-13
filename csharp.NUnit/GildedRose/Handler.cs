namespace GildedRoseKata;

public abstract class Handler
{
    protected Handler NextHandler;
    public void SetNextHandler(Handler nextHandler) => NextHandler = nextHandler;

    public abstract void UpdateItem(Item item);

    public static void DecreaseQuality(Item item)
    {
        ChangeQuality(item,-1);
    }
    
    public static void IncreaseQuality(Item item)
    {
        ChangeQuality(item,1);
    }
    
    private const int MaxItemQuality = 50;

    public static void ChangeQuality(Item item, int amount)
    {
        var newItemQuality = item.Quality + amount;
        if (newItemQuality > MaxItemQuality)
        {
            newItemQuality = MaxItemQuality;
        }
        item.Quality = newItemQuality;
    } 

    public static bool HasExpired(Item item)
    {
        return item.SellIn < 0;
        return item.SellIn <= 0;
    }

    public static int DecreaseSellIn(Item item)
    {
        return item.SellIn -= 1;
    }
}