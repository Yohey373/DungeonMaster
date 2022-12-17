public class ItemBase 
{
    public enum ItemTypes {
        Invalide =-1,
        Portion,
        TreasureBox
    }

    public string ItemName;
    public ItemTypes ItemType;

    public ItemBase(string itemName,ItemTypes itemType) {
        this.ItemName = itemName;
        this.ItemType = itemType;
    }
}
