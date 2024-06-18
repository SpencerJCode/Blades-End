public class StoryBoard
{
    public List<string> Dialogues { get; set; } = new List<string>();
    public StoryBoard(string _code)
    {
        switch(_code)
        {
            case "Blank" : break;
            case "IntroDialogue" : LoadIntroDialogue(); break;
        }
    }
    public void RunDialogue()
    {
        Console.Clear();
        foreach(string dialogue in Dialogues)
        {
            Console.WriteLine(dialogue);
            Console.ReadKey();
            Console.Clear();
        }
    }
    private void LoadIntroDialogue()
    {
        Dialogues.Add("Mastanox, 441 TE. The mightiest and wealthiest city in the continent of Colatna. The 'Shining Star' of the South, where any who come with a strong will and courageous hope can make a future for themselves.");
        Dialogues.Add("Here, your journey begins, a footman in the mercenary guild known as Blades's End. Not the most prestigious of the mercenary guilds in the city, but that's part of the plan.");
        Dialogues.Add("Yours is the will, and yours is the courage, that brought you to this city. But what were you seeking? Wealth? Power? Fame? Or just an escape from the traditional bucolic life of the surrounding countryland?");
        Dialogues.Add("Time will tell. Who knows what darkness lurks just underfoot; what cruel plots are being hashed in the shadowy corners of the city. For now, you must hone your skill set and learn as much as you can. The time may come when you are needed more than you ever thought, and sooner than you ever hoped.");
        Dialogues.Add("Onward, adventurer! Your first assignment awaits!");
    }
}