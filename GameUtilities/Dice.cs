public class Dice
{
    public Random Random = new Random();
    public int Roll(int DiceQuantity = 1, int DiceType = 20, int PerDiceModifier = 0, int TotalModifier = 0)
    {
        int total = TotalModifier;
        for(int i=1; i<=DiceQuantity; i++)
        {
            total += Random.Next(1,DiceType+1) + PerDiceModifier;
        }
        return total;
    }
    public int d100()
    {
        return Random.Next(1,101);
    }
    public int d20()
    {
        return Random.Next(1,21);
    }
    public int d12()
    {
        return Random.Next(1,13);
    }
    public int d10()
    {
        return Random.Next(1,13);
    }
    public int d8()
    {
        return Random.Next(1,9);
    }
    public int d6()
    {
        return Random.Next(1,7);
    }
    public int d4()
    {
        return Random.Next(1,5);
    }
    public int d2()
    {
        return Random.Next(1,3);
    }
}