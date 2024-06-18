public class SaveBonus
{
    public string Save { get; set; }
    public int Modifier { get; set; }
    public string Effect { get; set; }
    public SaveBonus(string _save, int _modifier, string _effect)
    {
        Save = _save;
        Modifier = _modifier;
        Effect = _effect;
    }
}