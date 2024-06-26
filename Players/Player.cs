using System.Reflection.Metadata.Ecma335;

public class Player
{
    public string Name { get; set; } = string.Empty;
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
    public int AvailableSkillPoints  = 0;
    public int AvailableAttributePoints = 0;
    public List<Skill> Skills = new List<Skill>();
    public List<SaveBonus> SaveBonuses { get; set; } = new List<SaveBonus>();
    public List<CharacterClass> Classes { get; set; }
    public Journal Journal { get; set; } = new Journal();
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

    public Player()
    {
        Race = new Race("Empty");
        Classes = new List<CharacterClass>();
        Classes.Add(new CharacterClass("Empty"));
        InitializeSkills();
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
    public void ShowStats(bool Pause = false)
    {
        Console.WriteLine(Name + " the " + Race.Name);
        foreach(CharacterClass Class in Classes)
            {
                Console.WriteLine($"Level {Class.ClassLevel} {Class.Name}");
            }
        Console.WriteLine("XP: " + CurrentXP + "/" + XPToLevel);
        Console.WriteLine("Health: " + CurrentHP + "/" + MaxHP);
        Console.WriteLine("");
        Console.WriteLine("ATTRIBUTES");
        ShowAttributes(false);
        Console.WriteLine("");
        Console.WriteLine("SAVES:");
        Console.WriteLine($"Fortitude Save: {CalculateSave("Fortitude")}");
        Console.WriteLine($"Reflex Save: {CalculateSave("Reflex")}");
        Console.WriteLine($"Will Save: {CalculateSave("Will")}");
        Console.WriteLine("");
        Console.WriteLine("Skills:");
        ShowSkills();
        if(Pause)
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void ShowAttributes(bool ShowMeta = true)
    {
        if(ShowMeta)
        {
            Console.WriteLine(Name + " the " + Race.Name);
            foreach(CharacterClass Class in Classes)
            {
                Console.WriteLine($"Level {Class.ClassLevel} {Class.Name}");
            }
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
        RightHand.Item = new Item(Classes[0].StartingWeapon, Classes[0].StartingWeaponType, "Normal");
        Body.Item = new Item("Armor", Classes[0].StartingArmor, "Normal");
        Inventory.Add(new Item("Potion", "Healing", "Small"));
    }
    public void LoadSkillPoints(int IntelligenceMod, bool Starting, int ClassIndex = 0)
    {
        if(Starting)
        {
            AvailableSkillPoints += ((IntelligenceMod + Race.Skill + Classes[0].SkillPointsPerLevel) * 4);
        }
        else
        {
            AvailableSkillPoints += ((IntelligenceMod + Race.Skill + Classes[ClassIndex].SkillPointsPerLevel));
        }
    }
    private void InitializeSkills()
    {
        Skills.Add(new Skill("Barter", "Charisma"));
        Skills.Add(new Skill("Bluff", "Charisma"));
        Skills.Add(new Skill("Climb", "Strength"));
        Skills.Add(new Skill("Disarm Traps", "Dexterity"));
        Skills.Add(new Skill("Hide", "Dexterity"));
        Skills.Add(new Skill("Jump", "Strength"));
        Skills.Add(new Skill("Listen", "Wisdom"));
        Skills.Add(new Skill("Music", "Charisma"));
        Skills.Add(new Skill("Persuade", "Charisma"));
        Skills.Add(new Skill("Pick Locks", "Dexterity"));
        Skills.Add(new Skill("Search", "Intelligence"));
        Skills.Add(new Skill("Sneak", "Dexterity"));
        Skills.Add(new Skill("Spot", "Wisdom"));
        Skills.Add(new Skill("Swim", "Strength"));
        Skills.Add(new Skill("Tumble", "Dexterity"));
    }
    public void UseSkillPoint(int Index)
    {
        AvailableSkillPoints--;
        Skills[Index].Points++;
    }
    public void ShowSkills(bool Pause = false)
    {
        foreach(Skill skill in Skills)
        {
            Console.WriteLine($"{skill.Name} : {skill.Points}");
        }
        if(Pause)
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
    public int CalculateSave(string _code)
    {
        switch(_code)
        {
            case "Fortitude" :  return CalculateFortitudeSave();
            case "Reflex" :  return CalculateReflexSave();
            case "Will" :  return CalculateWillSave();
            default : return 0;
        }
    }
    private int CalculateFortitudeSave(string effect = "")
    {
        int total = CalculateMod(Constitution);
        if(SaveBonuses.Any(sb => sb.Effect == effect))
        {
            foreach(SaveBonus savebonus in SaveBonuses)
            {
                if(savebonus.Effect == effect)
                {
                    total += savebonus.Modifier;
                }
            }
        }
        for(int i=0; i<Classes.Count(); i++)
        {
            total+=Classes[i].FortitudeSave;
        }
        return total;
    }
    private int CalculateReflexSave(string effect = "")
    {
        int total = CalculateMod(Dexterity);
        if(SaveBonuses.Any(sb => sb.Effect == effect))
        {
            foreach(SaveBonus savebonus in SaveBonuses)
            {
                if(savebonus.Effect == effect)
                {
                    total += savebonus.Modifier;
                }
            }
        }
        for(int i=0; i<Classes.Count(); i++)
        {
            total+=Classes[i].ReflexSave;
        }
        return total;
    }
    private int CalculateWillSave(string effect = "")
    {
        int total = CalculateMod(Wisdom);
        if(SaveBonuses.Any(sb => sb.Effect == effect))
        {
            foreach(SaveBonus savebonus in SaveBonuses)
            {
                if(savebonus.Effect == effect)
                {
                    total += savebonus.Modifier;
                }
            }
        }
        for(int i=0; i<Classes.Count(); i++)
        {
            total+=Classes[i].WillSave;
        }
        return total;
    }
    private int CalculateMod(int stat)
    {
        return (int)Math.Floor(Convert.ToDouble(((stat-10)/2)));
    }
    public void LevelUp(CharacterClass Class, Dice Dice)
    {
        MaxHP += Dice.Roll(1, Class.HPDiceType, CalculateMod(Constitution));
        Class.LevelUp();
        int TotalLevel = Classes.Sum(c => c.ClassLevel);
        CurrentXP = CurrentXP - XPToLevel;
        XPToLevel+= (TotalLevel*1000);
        AvailableSkillPoints+=Class.SkillPointsPerLevel;
        AvailableSkillPoints+=CalculateMod(Intelligence);
        if(TotalLevel % 4 == 0)
        {
            AvailableAttributePoints++;
        }
    }
}