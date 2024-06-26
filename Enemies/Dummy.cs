public class Dummy : Enemy
{
    public Dummy(int Difficulty)
    {
        Race = new Race("Empty");
        Classes.Add(new CharacterClass("Empty"));
        Name = "Practice Dummy";
        Classes[0].Name = "Target Practice";
        IsDisabled = true;
        MaxHP = 12*Difficulty;
        CurrentHP = MaxHP;
    }
}