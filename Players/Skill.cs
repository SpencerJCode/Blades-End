public class Skill
{
    public string Name { get; set; }
    public string Attribute  { get; set; }
    public int Points { get; set; } = 0;
    public Skill(string _name,  string _attribute)
    {
        Name = _name;
        Attribute = _attribute;
    }
}