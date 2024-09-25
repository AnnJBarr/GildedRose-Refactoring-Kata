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

    public static void ChangeQuality(Item item, int amount) => item.Quality += amount;

    public static bool HasExpired(Item item)
    {
        return item.SellIn < 0;
    }

    public static int DecreaseSellIn(Item item)
    {
        return item.SellIn -= 1;
    }
}