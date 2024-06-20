public class CharacterClass
{
    public string Name { get; set; }
    public string StartingArmor { get; set; }
    public string StartingWeapon { get; set; }
    public string StartingWeaponType { get; set; }
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
        StartingArmor = "Scale";
        StartingWeapon = "Sword";
        StartingWeaponType = "Long";
    }
}