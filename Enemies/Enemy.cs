public abstract class Enemy
{
    public string Name { get; set; } = string.Empty;
    public bool IsDisabled { get; set; }
    public int CurrentHP { get; set; } = 10;
    public int MaxHP { get; set; } = 10;
    public Race Race { get; set; }
    public int Strength { get; set; } = 10;
    public int Dexterity { get; set; } = 10;
    public int Constitution { get; set; } = 10;
    public int Intelligence { get; set; } = 10;
    public int Wisdom { get; set; } = 10;
    public int Charisma { get; set; } = 10;
    public int AvailableAttributePoints = 0;
    public List<Skill> Skills = new List<Skill>();
    public List<SaveBonus> SaveBonuses { get; set; } = new List<SaveBonus>();
    public List<CharacterClass> Classes { get; set; }
    public int Gold { get; set; } = 10;
    public List<Item> Inventory = new List<Item>();
    public Slot LeftHand = new Slot();
    public Slot LeftFinger = new Slot();
    
    public Slot RightHand = new Slot();
    public Slot RightFinger = new Slot();
    public Slot Hands = new Slot();
    
    public Slot Head = new Slot();
    public Slot Amulet = new Slot();
    public Slot Body = new Slot();
    public Slot Waist = new Slot();
    public Slot Feet = new Slot();
    public Slot Back = new Slot();

}