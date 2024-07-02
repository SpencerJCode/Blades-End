public class Dummy : Enemy
{
    public Dummy(int Difficulty)
    {
        CharacterClass Dummy = new CharacterClass("Empty");
        Race = new Race("Empty");
        Classes.Add(Dummy);
        Name = "Practice Dummy";
        Classes[0].Name = "Target Practice";
        IsDisabled = true;
        MaxHP = 12*Difficulty;
        CurrentHP = MaxHP;
    }
}