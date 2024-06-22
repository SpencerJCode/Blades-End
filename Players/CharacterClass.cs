public class CharacterClass
{
    public string Name { get; set; }
    public int ClassLevel { get; set; } = 1;
    public int SkillPointsPerLevel { get; set; } = 0;
    public int HPDiceType { get; set; }
    public List<int> Attacks { get; set; }
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
    }
    private void LoadStrongAttack(int Level)
    {
        Attacks = StrongAttacks[Level-1];
    }
    private void LoadStrongAttacks()
    {
        List<int> attack = new List<int>();
        for(int i=1; i<21; i++)
        {
            attack[0]=i;
            StrongAttacks.Add(attack);
        }
        for(int i=6; i<21; i++)
        {
            StrongAttacks[i-1][1] = i-5;
        }
        for(int i=11; i<21; i++)
        {
            StrongAttacks[i-1][2] = i-10;
        }
        for(int i=16; i<21; i++)
        {
            StrongAttacks[i-1][3] = i-15;
        }
    }
}