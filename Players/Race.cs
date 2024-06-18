public class Race
{
    public string Name { get; set; }
    public int Strength { get; set; } = 0;
    public int Dexterity { get; set; } = 0;
    public int Constitution { get; set; } = 0;
    public int Intelligence { get; set; } = 0;
    public int Wisdom { get; set; } = 0;
    public int Charisma { get; set; } = 0;
    public int Skill { get; set; } = 0;
    public List<SaveBonus> SaveBonuses = new List<SaveBonus>();
    public Race(string _code)
    {
        if(_code == "Empty")
        {
            Name = string.Empty;
        }
        else
        {
            Name = _code;
            switch(_code)
            {
                case "Human" : Skill = 1; break;
                case "Elf" : Dexterity = 2;
                             Constitution = -2;
                             SaveBonuses.Add(new SaveBonus("WILL", 2, "SLEEP"));
                             break;
                case "Dwarf" : Strength = 2;
                               Constitution = 2;
                               Intelligence = -2;
                               Charisma = -2;
                               SaveBonuses.Add(new SaveBonus("FORTITUDE", 2, "POISON"));
                               break;
                case "Halfling" : Strength = -2;
                                  Dexterity = 2;
                                  break;
                case "Half-Elf" : Dexterity = 1;
                                  Constitution = 1;
                                  SaveBonuses.Add(new SaveBonus("WILL", 1, "SLEEP"));
                                  break;
                case "Half-Orc" : Strength = 2;
                                  Constitution = 2;
                                  Charisma = -4;
                                  break;
            }
        }
    }
}