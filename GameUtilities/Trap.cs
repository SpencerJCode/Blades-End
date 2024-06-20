public class Trap
{
    public int DiceType { get; set; }
    public string Save { get; set; }
    public bool FullSave { get; set; }
    public string Effect { get; set; }
    public string EffectDescription { get; set; }
    public int Difficulty { get; set; }
    public Trap(int ValueScore)
    {
        if(ValueScore <= 25)
        {
            DiceType = 4;
        }
        else if(ValueScore <= 50)
        {
            DiceType = 8;
        }
        else if(ValueScore <= 75)
        {
            DiceType = 10;
        }
        else
        {
            DiceType = 20;
        }
        Difficulty = 10 + (int)Math.Floor(Convert.ToDouble(((ValueScore)/4)));
        RandomTrapType();
    }
    private void RandomTrapType()
    {
        Random RandomInt = new Random();
        int result = RandomInt.Next(1,4);
        if(result == 1)
        {
            Save = "Fortitude";
            Effect = "Poison";
            EffectDescription = "Toxic fumes fill your lungs.";
        }
        else if(result == 2)
        {
            Save = "Reflex";
            Effect = string.Empty;
            EffectDescription = "Shrapnel explodes out of the chest in your direction.";
        }
        else
        {
            Save = "Will";
            Effect = "Stun";
            EffectDescription = "A wave of energy strikes your mind with concussive force.";
        }
        result = RandomInt.Next(1,3);
        if(result == 1)
        {
            FullSave = true;
        }
        else
        {
            FullSave = false;
        }
    }
}