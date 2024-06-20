public class Player
{
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; } = 1;
    public int CurrentXP { get; set; } = 0;
    public int XPToLevel { get; set; } = 1000;
    public int CurrentHP { get; set; } = 10;
    public int MaxHP { get; set; } = 10;
    public Race Race { get; set; }
    public bool RaceAssigned { get; set; } = false;
    public int Strength { get; set; } = 10;
    public int Dexterity { get; set; } = 10;
    public int Constitution { get; set; } = 10;
    public int Intelligence { get; set; } = 10;
    public int Wisdom { get; set; } = 10;
    public int Charisma { get; set; } = 10;
    public List<SaveBonus> SaveBonuses { get; set; } = new List<SaveBonus>();
    public CharacterClass Class { get; set; }
    public Journal Journal { get; set; } = new Journal();
    public int Gold { get; set; } = 10;
    public List<Item> Inventory = new List<Item>();
    public Slot LeftHand = new Slot();
    public Slot LeftFinger = new Slot();
    
    public Slot RightHand = new Slot();
    public Slot RightFinger = new Slot();
    public Slot Hands = new Slot();
    
    public Slot Head = new Slot();
    public Slot Body = new Slot();
    public Slot Waist = new Slot();
    public Slot Feet = new Slot();
    public Slot Back = new Slot();

    public Player()
    {
        Race = new Race("Empty");
        Class = new CharacterClass("Empty");
    }
    public void AssignName(string _name)
    {
        Name = _name;
    }
    public bool IsValidPlayer()
    {
        if(Name == string.Empty)
        {
            return false;
        }
        return true;
    }
    public void AssignRaceBenefits()
    {
        if(!RaceAssigned)
        {
            RaceAssigned = true;
            Strength += Race.Strength;
            Dexterity += Race.Dexterity;
            Constitution += Race.Constitution;
            Intelligence += Race.Intelligence;
            Wisdom += Race.Wisdom;
            Charisma += Race.Charisma;
            foreach(SaveBonus save in Race.SaveBonuses)
            {
                SaveBonuses.Add(save);
            }
        }
    }
    public void ShowStats()
    {
        Console.WriteLine(Name);
        Console.WriteLine("Level " + Level + " " + Race.Name + " " + Class.Name);
        Console.WriteLine("XP: " + CurrentXP + "/" + XPToLevel);
        Console.WriteLine("Health: " + CurrentHP + "/" + MaxHP);
        ShowAttributes(false);
    }
    public void ShowAttributes(bool ShowMeta = true)
    {
        if(ShowMeta)
        {
            Console.WriteLine(Name);
            Console.WriteLine(Race.Name + " " + Class.Name);
        }
        Console.WriteLine("Strength: " + Strength);
        Console.WriteLine("Dexterity: " + Dexterity);
        Console.WriteLine("Constitution: " + Constitution);
        Console.WriteLine("Intelligence: " + Intelligence);
        Console.WriteLine("Wisdom: " + Wisdom);
        Console.WriteLine("Charisma: " + Strength);
    }
    public void ShowInventory()
    {
        Console.Clear();
        Console.WriteLine($"Helmet: {Head.Item.Name}");
        Console.WriteLine($"Armor: {Body.Item.Name}");
        Console.WriteLine($"Left Hand: {LeftHand.Item.Name}");
        Console.WriteLine($"Right Hand: {RightHand.Item.Name}");
        Console.WriteLine($"Gloves: {Hands.Item.Name}");
        Console.WriteLine($"Ring 1: {LeftFinger.Item.Name}");
        Console.WriteLine($"Ring 2: {RightFinger.Item.Name}");
        Console.WriteLine($"Belt: {Waist.Item.Name}");
        Console.WriteLine($"Boots: {Feet.Item.Name}");
        Console.WriteLine($"Cape: {Back.Item.Name}");
        Console.WriteLine("");
        Console.WriteLine($"Gold: {Gold}");
        Console.WriteLine("In your backpack, you have: ");
        foreach(Item item in Inventory)
        {
            Console.WriteLine(item.Name + ". " + item.Description);
        }
        Console.ReadKey();
        Console.Clear();
    }
    public void EquipStartingGear()
    {
        RightHand.Item = new Item(Class.StartingWeapon, Class.StartingWeaponType, "Normal");
        Body.Item = new Item("Armor", Class.StartingArmor, "Normal");
        Inventory.Add(new Item("Potion", "Healing", "Small"));
    }
}