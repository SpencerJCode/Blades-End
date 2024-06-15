public class CharacterClass
{
    public string Name { get; set; }
    public CharacterClass(string _code)
    {
        if(_code == "Empty")
        {
            Name = string.Empty;
        }
        else
        {
            Name = _code;
        }
    }
}