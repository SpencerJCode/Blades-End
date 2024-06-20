public class Item
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Work { get; set; } = string.Empty;
    public bool CanUse { get; set; } = false;
    public string Description { get; set; } = string.Empty;
    public int DiceSize { get; set; } = 4;
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
            case "Small" : DiceSize = 8; break;
            case "Medium" : DiceSize = 12; break;
            case "Large" : DiceSize = 20; break;
            default : DiceSize = 8; break;
        }
        switch(_type)
        {
            case "Healing" : Description = $"A healing potion that restores up to {DiceSize} HP on use.";  break;
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