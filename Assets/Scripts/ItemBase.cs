public class ItemBase
{
    public enum ItemTypes
    {
        Invalide = -1,
        Potion
    }

    public string ItemName;
    public ItemTypes ItemType;

    public ItemBase(string itemName, ItemTypes itemTypes)
    {
        this.ItemName = itemName;
        this.ItemType = itemTypes;
    }


}
