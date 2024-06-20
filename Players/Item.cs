public class Item
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Work { get; set; } = string.Empty;
    public bool CanUse { get; set; } = false;
    public string Description { get; set; } = string.Empty;
    public int DiceSize { get; set; } = 4;
    public int Value { get; set; } = 1;
    public Item(string _code, string _mod1 = "", string _mod2 = "Normal")
    {
        switch(_code)
        {
            case "Empty" : LoadEmptyItem(); break;
            case "Sword" : LoadSword(_mod1, _mod2);  break;
            case "Potion" : LoadPotion(_mod1, _mod2); break;
            case "Armor" : LoadArmor(_mod1, _mod2); break;
        }
    }
    public Item NewItem(int ValueScore)
    {
        Random RandomInt = new Random();
        int Result = RandomInt.Next(1,14);
        Item ReturnItem;
        switch(Result)
        {
            case 1 : ReturnItem = new Item("Potion", RandomPotionType(), RandomPotionSize()); return ReturnItem;
            default : ReturnItem = new Item("Potion", RandomPotionType(), RandomPotionSize()); return ReturnItem;
        }
    }
    private void LoadEmptyItem()
    {
        Name = "Empty";
        Type = "Empty";
    }
    private void LoadPotion(string _type, string _size)
    {
        Name = _size + " " + _type + " " + "potion";
        Type = _type;
        Work = _size;
        CanUse = true;
        switch(_size)
        {
            case "Small" : DiceSize = 8; Value = 4; break;
            case "Medium" : DiceSize = 12; Value = 8; break;
            case "Large" : DiceSize = 20; Value = 12; break;
            default : DiceSize = 8; Value = 4; break;
        }
        switch(_type)
        {
            case "Healing" : Description = $"A healing potion that restores up to {DiceSize} HP on use.";  break;
        }
    }
    private string RandomPotionType()
    {
        return "Healing";
    }
    private string RandomPotionSize()
    {
        Random RandomInt = new Random();
        int Result = RandomInt.Next(1,10);
        switch(Result)
        {
            case 1 : return "Small";
            case 2 : return "Small";
            case 3 : return "Small";
            case 4 : return "Small";
            case 5 : return "Small";
            case 6 : return "Medium";
            case 7 : return "Medium";
            case 8 : return "Medium";
            case 9 : return "Large";
            default : return "Small";
        }
    }
    private void LoadSword(string _type, string _work)
    {
        switch(_type)
        {
            case "Long" : Name = "Long Sword"; Type = "ONEHAND"; break;
        }
        switch(_work)
        {
            case "Normal" : Work = "Normal"; break;
            case "Masterwork" : Work = "Masterwork"; Name = "Masterwork " + Name; break;
            case "Mithril" : Work = "Mithril"; Name = "Mithril " + Name; break;
        }        
    }
    private void LoadArmor(string _type, string _work)
    {
        switch(_type)
        {
            case "Scale" : Name = "Scale Armor"; Type = "Armor"; break;
        }
        switch(_work)
        {
            case "Normal" : Work = "Normal"; break;
            case "Masterwork" : Work = "Masterwork"; Name = "Masterwork " + Name; break;
            case "Mithril" : Work = "Mithril"; Name = "Mithril " + Name; break;
        }        
    }
}