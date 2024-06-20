public class Container
{
    public string Name { get; set; }
    public bool IsTrapped { get; set; }
    public Trap? Trap { get; set; }
    public List<Item> Contents  = new List<Item>();
    public int Gold { get; set; } = 0;
    public Random RandomInt = new Random();
    public Container(Area Area, int ValueScore)
    {
        int Result = 0;
        if(RandomInt.Next(1,101) <= ValueScore/4)
        {
            IsTrapped = true;
            Trap = new Trap(ValueScore);
        }
        Result  = RandomInt.Next(1,20);
        if(Result  == 1)
        {
            Gold = RandomInt.Next(1, ValueScore/2);
        }
        Result = RandomInt.Next(0,Area.ContainerTypes.Count());
        Name = Area.ContainerTypes[Result];
        foreach(Item Item in Area.LoadContainer(ValueScore))
        {
            Contents.Add(Item);
        }
    }
}