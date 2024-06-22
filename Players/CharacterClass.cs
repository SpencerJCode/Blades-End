using System.Net.Mail;

public class CharacterClass
{
    public string Name { get; set; }
    public int ClassLevel { get; set; } = 1;
    public int SkillPointsPerLevel { get; set; } = 0;
    public int HPDiceType { get; set; }
    public List<int> Attacks { get; set; }
    public int FortitudeSave { get; set; } = 0;
    public int ReflexSave { get; set; } = 0;
    public int WillSave { get; set; } = 0;

    public string StartingArmor { get; set; }
    public string StartingWeapon { get; set; }
    public string StartingWeaponType { get; set; }
    public List<List<int>> StrongAttacks { get; set; } = new List<List<int>>();
    public CharacterClass(string _code)
    {
        switch(_code)
        {
            case "Empty" : Name = string.Empty; break;
            case "Fighter" : LoadFighter(); break;
        }
    }
    private void LoadFighter()
    {
        Name = "Fighter";
        SkillPointsPerLevel = 2;
        HPDiceType = 8;
        StartingArmor = "Scale";
        StartingWeapon = "Sword";
        StartingWeaponType = "Long";
        LoadStrongAttacks();
        LoadStrongAttack(1);
        int WeakSave = (int)Math.Floor(Convert.ToDouble(ClassLevel/3)); //Lowest save is a third of the class level rounded down.
        LoadMightSaves(WeakSave);
    }
    private void LoadStrongAttack(int Level)
    {
        Attacks = StrongAttacks[Level-1];
    }
    private void LoadStrongAttacks()
    {
        List<int> attack = new List<int>();
        attack.Add(0);
        for(int i=1; i<21; i++)
        {
            attack[0]=i;
            StrongAttacks.Add(attack);
        }
        for(int i=5; i<20; i++)
        {
            StrongAttacks[i].Add(i-4);
        }
        for(int i=10; i<20; i++)
        {
            StrongAttacks[i].Add(i-9);
        }
        for(int i=15; i<20; i++)
        {
            StrongAttacks[i].Add(i-14);
        }
    }
    private void LoadMightSaves(int WeakSave)
    {
        FortitudeSave = WeakSave * 2;
        ReflexSave = WeakSave;
        WillSave  = WeakSave;
    }
    private void LoadNimbleSaves(int WeakSave)
    {
        FortitudeSave = WeakSave;
        ReflexSave = WeakSave * 2;
        WillSave  = WeakSave;
    }
    private void LoadSeerSaves(int WeakSave)
    {
        FortitudeSave = WeakSave;
        ReflexSave = WeakSave;
        WillSave  = WeakSave * 2;
    }
}