public class Menu
{
    public string MenuText { get; set; }
    public List<string> MenuOptions { get; set; } = new List<string>();
    public List<string> MenuMethods { get; set; } = new List<string>();
    public bool UseMenu { get; set; }
    public int SelectedOption { get; set; } = 1;
    public ConsoleKeyInfo Key { get; set; }
    public Menu(string MenuType, int PointsToAssign = 0)
    {
        switch(MenuType)
        {
            case "Blank" : LoadBlankMenu(); break;
            case "YesNo" : LoadYesNoMenu(); break;
            case "ChooseRace" : LoadChooseRaceMenu(); break;
            case "CONFIRMCHOOSEHUMAN" : LoadConfirmChooseHumanMenu(); break;
            case "CONFIRMCHOOSEELF" : LoadConfirmChooseElfMenu(); break;
            case "CONFIRMCHOOSEDWARF" : LoadConfirmChooseDwarfMenu(); break;
            case "CONFIRMCHOOSEHALFLING" : LoadConfirmChooseHalflingMenu(); break;
            case "CONFIRMCHOOSEHALFELF" : LoadConfirmChooseHalfelfMenu(); break;
            case "CONFIRMCHOOSEHALFORC" : LoadConfirmChooseHalforcMenu(); break;
            case "ChooseClass" : LoadChooseClassMenu(); break;
            case "CONFIRMCHOOSEFIGHTER" : LoadConfirmChooseFighterMenu(); break;
            case "AssignPoints" : LoadAssignPointsMenu(PointsToAssign); break;
            case "MainMenu" : LoadMainMenu(); break;
            default : LoadMainMenu(); break;
        }
    }
    public Menu(string MenuType, Area CurrentArea, Player Player, List<Enemy>? Enemies = null)
    {
        switch(MenuType)
        {
            case "AssignSkills" : LoadAssignSkillsMenu(Player); break;
            case "Play" : LoadPlayMenu(CurrentArea, Player); break;
            case "Train" : LoadTrainMenu(CurrentArea, Player); break;
            case "Fight" : LoadFightMenu(CurrentArea, Player, Enemies); break;
        }
    }
    private void LoadFightMenu(Area CurrentArea, Player Player, List<Enemy> Enemies)
    {
        MenuText = "Fighting a ";
        if(Enemies.Count() == 1)
        {
            MenuText += $"{Enemies[0].Name}!";
        }
        else
        {
            for(int i=0; i<Enemies.Count(); i++)
            {
                if(i != Enemies.Count()-1)
                {
                    MenuText += $"{Enemies[i].Name}, ";
                }
                else
                {
                    MenuText += $"and a {Enemies[i].Name}!";
                }
            }
        }
        int index = 0;
        foreach(Enemy enemy in Enemies)
        {
            MenuOptions.Add($"Attack {enemy.Name}!");
            MenuMethods.Add($"{index}");
        }
    }
    public void LoadBlankMenu()
    {
        MenuText = string.Empty;
        UseMenu = false;
        Key = new ConsoleKeyInfo();
    }
    private void LoadTrainMenu(Area CurrentArea, Player Player)
    {
        MenuText = "How do you want to train?";
        if(Player.AvailableSkillPoints != 0)
        {
            MenuOptions.Add("Develop your skills");
            MenuMethods.Add("TRAINSKILLS");
        }
        if(Player.AvailableAttributePoints != 0)
        {
            MenuOptions.Add("Train your body");
            MenuMethods.Add("TRAINATTRIBUTES");
        }
        if(Player.CurrentXP > Player.XPToLevel)
        {
            MenuOptions.Add("Advance your class");
            MenuMethods.Add("LEVELUP");
        }
        MenuOptions.Add("Practice combat");
        MenuMethods.Add("PRACTICECOMBAT");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    public void LoadYesNoMenu()
    {
        MenuText = "Confirm?";
        MenuOptions.Add("Yes");
        MenuOptions.Add("No");
        MenuMethods.Add("YES");
        MenuMethods.Add("NO");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    public void LoadChooseRaceMenu()
    {
        MenuText = "Choose your race.";
        MenuOptions.Add("Human");
        MenuOptions.Add("Elf");
        MenuOptions.Add("Dwarf");
        MenuOptions.Add("Halfling");
        MenuOptions.Add("Half-Elf");
        MenuOptions.Add("Half-Orc");
        MenuMethods.Add("CONFIRMCHOOSEHUMAN");
        MenuMethods.Add("CONFIRMCHOOSEELF");
        MenuMethods.Add("CONFIRMCHOOSEDWARF");
        MenuMethods.Add("CONFIRMCHOOSEHALFLING");
        MenuMethods.Add("CONFIRMCHOOSEHALFELF");
        MenuMethods.Add("CONFIRMCHOOSEHALFORC");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadConfirmChooseHumanMenu()
    {
        MenuText = "Humans have no stat benefits, but receive enough skill points for an additional skill. Choose human?";
        MenuOptions.Add("1) Yes");
        MenuOptions.Add("2) No");
        MenuMethods.Add("CHOOSEHUMAN");
        MenuMethods.Add("RETURN");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadConfirmChooseElfMenu()
    {
        MenuText = "Elves are frail but graceful, and are resistant to sleep effects. Choose Elf?";
        MenuOptions.Add("1) Yes");
        MenuOptions.Add("2) No");
        MenuMethods.Add("CHOOSEELF");
        MenuMethods.Add("RETURN");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadConfirmChooseDwarfMenu()
    {
        MenuText = "Dwarves are strong and full of vitality, but are crass and thoughtless. Choose Dwarf?";
        MenuOptions.Add("1) Yes");
        MenuOptions.Add("2) No");
        MenuMethods.Add("CHOOSEDWARF");
        MenuMethods.Add("RETURN");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadConfirmChooseHalflingMenu()
    {
        MenuText = "Halflings are nimble but weak. Choose Halfling?";
        MenuOptions.Add("1) Yes");
        MenuOptions.Add("2) No");
        MenuMethods.Add("CHOOSEHALFLING");
        MenuMethods.Add("RETURN");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadConfirmChooseHalfelfMenu()
    {
        MenuText = "Half-elves have half the strengths of elves, but also half the weaknesses. Choose Half-Elf?";
        MenuOptions.Add("1) Yes");
        MenuOptions.Add("2) No");
        MenuMethods.Add("CHOOSEHALFELF");
        MenuMethods.Add("RETURN");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadConfirmChooseHalforcMenu()
    {
        MenuText = "Half-Orcs are mighty with great endurance, but terribly anti-social. Choose Half-Orc?";
        MenuOptions.Add("1) Yes");
        MenuOptions.Add("2) No");
        MenuMethods.Add("CHOOSEHALFORC");
        MenuMethods.Add("RETURN");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    public void LoadMainMenu()
    {
        MenuText = "Welcome to Blade's End! Please select an option below:";
        MenuOptions.Add("1) New Game");
        MenuOptions.Add("2) Quit");
        MenuMethods.Add("NEWGAME");
        MenuMethods.Add("EXIT");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    public void LoadChooseClassMenu()
    {
        MenuText = "Choose your class.";
        MenuOptions.Add("Fighter");
        MenuMethods.Add("CONFIRMCHOOSEFIGHTER");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadConfirmChooseFighterMenu()
    {
        MenuText = "Fighters specialize in melee fighting, and can choose a new feat every other level. Choose fighter?";
        MenuOptions.Add("1) Yes");
        MenuOptions.Add("2) No");
        MenuMethods.Add("CHOOSEFIGHTER");
        MenuMethods.Add("RETURN");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadAssignPointsMenu(int PointsToAssign)
    {
        MenuText = $"You have {PointsToAssign} attribute points to assign. Move the arrow to the attribute you wish to increase and press enter.";
        MenuOptions.Add("Strength - ");
        MenuOptions.Add("Dexterity - ");
        MenuOptions.Add("Constitution - ");
        MenuOptions.Add("Intelligence - ");
        MenuOptions.Add("Wisdom - ");
        MenuOptions.Add("Charisma - ");
        MenuMethods.Add("ADDSTRENGTH");
        MenuMethods.Add("ADDDEXTERITY");
        MenuMethods.Add("ADDCONSTITUTION");
        MenuMethods.Add("ADDINTELLIGENCE");
        MenuMethods.Add("ADDWISDOM");
        MenuMethods.Add("ADDCHARISMA");
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadAssignSkillsMenu(Player player)
    {
        int Index = 0;
        MenuText = $"You have {player.AvailableSkillPoints} points to assign. Max skill level is your current total level plus 3.";
        foreach(Skill skill in player.Skills)
        {
            MenuOptions.Add($"{skill.Name}: {skill.Points}");
            MenuMethods.Add($"{Index}");
            Index++;
        }
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadPlayMenu(Area CurrentArea, Player player)
    {
        MenuText = $"Current Area: {CurrentArea.Name}. ";
        if(CurrentArea.HealAtArea != string.Empty && player.CurrentHP != player.MaxHP)
        {
            if(player.Gold >= (CurrentArea.HealPrice * ( player.MaxHP - player.CurrentHP)))
            {
                MenuOptions.Add($"Heal at the {CurrentArea.HealAtArea}");
                MenuMethods.Add("HEAL");
            }
            else
            {
                MenuText += $"You need {CurrentArea.HealPrice * ( player.MaxHP - player.CurrentHP)} more gold to afford healing at the {CurrentArea.HealAtArea}. ";
            }
        }
        if(CurrentArea.SleepAtArea  != string.Empty)
        {
            if(player.Gold >= CurrentArea.SleepPrice)
            {
                MenuOptions.Add($"Sleep in {CurrentArea.SleepAtArea}");
                MenuMethods.Add("SLEEP");
            }
            else
            {
                MenuText += $"You need {CurrentArea.HealPrice - player.Gold} more gold to afford to rent a room to sleep in {CurrentArea.SleepAtArea}. ";
            }
        }
        if(player.Inventory.Any(i => i.CanUse == true))
        {
            MenuOptions.Add("Use Item");
            MenuMethods.Add("USEITEM");
        }
        MenuOptions.Add("View Inventory");
        MenuMethods.Add("INVENTORY");
        MenuOptions.Add("View Stats");
        MenuMethods.Add("STATS");
        MenuOptions.Add("Explore");
        MenuMethods.Add("EXPLORE");
        LoadAreaMenu(CurrentArea);
        MenuOptions.Add("Exit Game");
        MenuMethods.Add("EXIT");
        MenuText += "What do you want to do?";
        UseMenu = true;
        Key = new ConsoleKeyInfo();
    }
    private void LoadAreaMenu(Area CurrentArea)
    {
        if(CurrentArea.PlayMenuOptions.Count() > 0)
        {
            for(int i=0; i<CurrentArea.PlayMenuOptions.Count(); i++)
            {
                MenuOptions.Add(CurrentArea.PlayMenuOptions[i]);
                MenuMethods.Add(CurrentArea.PlayMenuMethods[i]);
            }
        }
    }
    public void ShowMenu(bool assignPoints = false, bool assignSkills = false, Player? player = null, int option = 0, int points = 8)
    {
        Console.WriteLine(MenuText);
        if(assignPoints)
        {
            MenuOptions[0] += player?.Strength;
            MenuOptions[1] += player?.Dexterity;
            MenuOptions[2] += player?.Constitution;
            MenuOptions[3] += player?.Intelligence;
            MenuOptions[4] += player?.Wisdom;
            MenuOptions[5] += player?.Charisma;
            SelectedOption = option;
        }
        if(assignSkills)
        {
            SelectedOption = option;
        }
        for(int i = 1; i <= MenuOptions.Count(); i++)
        {
            if(i==SelectedOption)
            {
                Console.WriteLine(MenuOptions[i-1] + " <---");
            }
            else
            {
                Console.WriteLine(MenuOptions[i-1]);
            }
        }
    }
    public string EvaluateKey(ConsoleKeyInfo Key)
    {
        if(Key.Key == ConsoleKey.DownArrow && SelectedOption != MenuOptions.Count())
        {
            SelectedOption++;
            Console.Clear();
            ShowMenu();
            return string.Empty;
        }
        else if(Key.Key == ConsoleKey.UpArrow && SelectedOption != 1)
        {
            SelectedOption--;
            Console.Clear();
            ShowMenu();
            return string.Empty;
        }
        else if(Key.Key == ConsoleKey.Enter)
        {
            ExitMenu();
            Console.Clear();
            return MenuMethods[SelectedOption-1];
        }
        return string.Empty;
    }
    public void ExitMenu()
    {
        UseMenu = false;
        MenuOptions = new List<string>();
        MenuText = string.Empty;
    }
}