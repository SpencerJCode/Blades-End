public class Journal
{
    public List<JournalEntry> Entries = new List<JournalEntry>();
    public Journal()
    {
        Entries.Add(new JournalEntry("Intro"));
    }
    public void ShowJournal()
    {
        Console.Clear();
        foreach(JournalEntry entry in Entries)
        {
            if(!entry.Complete)
            {
                Console.WriteLine(entry.Entry);
                Console.WriteLine("---" + entry.Brief);
                Console.WriteLine("---Reward: " + entry.Reward);
            }
        }
        Console.ReadKey();
        Console.Clear();
    }
}

public class JournalEntry
{
    public string QuestCode { get; set; } = string.Empty;
    public string Entry { get; set; } = string.Empty;
    public string Brief { get; set; } = string.Empty;
    public string Reward { get; set; } = string.Empty;
    public List<string> RewardMethods { get; set; } = new List<string>();
    public bool Complete { get; set; } = false;
    public JournalEntry(string _code)
    {
        switch(_code)
        {
            case "Intro" : LoadIntroEntry(); break;
        }
    }
    private void LoadIntroEntry()
    {
        QuestCode = "Intro";
        Entry = "I've finally found work as a footman in the Blade's End mercenary guild. I need to finish a few assignments so I can learn my way around the city.";
        Brief = "Complete three assignments with the guild.";
        Reward = "200 XP";
        RewardMethods.Add("XP-200");
    }
}