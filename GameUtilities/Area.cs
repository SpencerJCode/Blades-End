public class Area
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Type { get; set; }
    public int Difficulty { get; set; }
    public int Danger { get; set; }
    public string HealAtArea { get; set; }
    public int HealPrice { get; set; }
    public string SleepAtArea { get; set; }
    public int SleepPrice { get; set; }
    public List<string> Enemies { get; set; } = new List<string>();
    public List<string> TravelToAreas { get; set; } = new List<string>();
    public List<string> PlayMenuOptions { get; set; } = new List<string>();
    public List<string> PlayMenuMethods { get; set; } = new List<string>();

    public Area(string _code)
    {
        switch(_code)
        {
            case "Blank" : LoadBlankArea(); break;
            case "BladesEndHQ" : LoadBladesEndHQ(_code); break;
        }
    }
    private void LoadBlankArea()
    {
        Name = string.Empty;
        Code = string.Empty;
        Type = string.Empty;
        Difficulty = 0;
        Danger = 0;
        HealAtArea  = string.Empty;;
        HealPrice = 0;
        SleepAtArea = string.Empty;;
        SleepPrice = 0;
    }
    private void LoadBladesEndHQ(string _code)
    {
        Name = "Blade's End Headquarters";
        Code = _code;
        Type = "CITY";
        Difficulty = 1;
        Danger = 1;
        HealAtArea  = "Clinic";
        HealPrice = 6;
        SleepAtArea = "your quarters";
        SleepPrice = 0;
        TravelToAreas.Add("MastanoxStreets");
        PlayMenuOptions.Add("Train your skills");
        PlayMenuMethods.Add("TRAIN");
    }
}