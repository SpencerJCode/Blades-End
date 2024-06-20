public class Slot
{
    public Item Item { get; set; }
    public Slot(string _code = "Empty")
    {
        switch(_code)
        {
            case "Empty" : Item = new Item("Empty"); break;
        }
    }
    public Item Unequip()
    {
        Item UnequippedItem = Item;
        Item = new Item("Empty");
        return UnequippedItem;
    }
    public Item Equip(Item ItemToEquip)
    {
        Item ItemToPutInInventory = Item;
        Item = ItemToEquip;
        return ItemToPutInInventory;
    }
}