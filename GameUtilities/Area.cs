public class Area
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Type { get; set; }
    public int Difficulty { get; set; }
    public int Danger { get; set; }
    public string HealAtArea { get; set; }
    public int HealPrice { get; set; } //This is multiplied by the amount of missing HP to determine a price. A
    //HealPrice of 2 and a missing HP amount of 10 results in 20 gold needed to heal.
    public string SleepAtArea { get; set; }
    public int SleepPrice { get; set; } //This is the exact gold amount needed to heal.
    public List<string> Enemies { get; set; } = new List<string>();
    public List<string> TravelToAreas { get; set; } = new List<string>();
    public List<string> PlayMenuOptions { get; set; } = new List<string>();
    public List<string> PlayMenuMethods { get; set; } = new List<string>();
    public List<string> ContainerTypes { get; set; } = new List<string>();

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
        HealPrice = 2;
        SleepAtArea = "your quarters";
        SleepPrice = 0;
        TravelToAreas.Add("MastanoxStreets");
        PlayMenuOptions.Add("Train your skills");
        PlayMenuMethods.Add("TRAIN");
        ContainerTypes.Add("Storage Bin");
        ContainerTypes.Add("Crate");
    }
    public List<Item> LoadContainer(int ValueScore)
    {
        List<Item> Contents = new List<Item>();
        Random RandomInt = new Random();
        int Result = RandomInt.Next(1,21);
        if(Result == 20)
        {
            ValueScore += ValueScore;
        }
        Result = RandomInt.Next(1,3);
        int NumberOfItemsInContainer = 0;
        while(Result == 1)
        {
            NumberOfItemsInContainer++;
            Result = RandomInt.Next(1,3);
        }
        Contents = RandomItems(ValueScore, NumberOfItemsInContainer);
        return Contents;
    }
    public List<Item> RandomItems(int ValueScore, int NumberOfItems)
    {
        List<Item> Items = new List<Item>();
        for(int i=0; i<NumberOfItems; i++)
        {
            Items.Add(RandomItem(ValueScore));
        }
        return Items;
    }
    public Item RandomItem(int ValueScore)
    {
        Item Item = new Item("Empty");
        return Item.NewItem(ValueScore);
    }
}