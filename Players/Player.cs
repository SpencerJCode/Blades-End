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
    public int Gold { get; set; } = 10;
    public List<SaveBonus> SaveBonuses { get; set; } = new List<SaveBonus>();
    public CharacterClass Class { get; set; }
    public Journal Journal { get; set; } = new Journal();
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

    }
}