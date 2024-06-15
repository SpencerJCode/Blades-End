using System.Runtime.CompilerServices;

public class Game
{
    public string Step { get; set; } = string.Empty;
    public bool Play { get; set; } = false;
    public Menu Menu { get; set; } = new Menu("Blank");
    public Player Player { get; set; } = new Player();
    public Game()
    {

    }
    public void EvaluatePlay()
    {
        if(Step == "NEWGAME" || Step == "CONTINUE")
        {
            Play = true;
        }
        else
        {
            Play = false;
        }
    }
    public void PlayGame()
    {
        if(!Player.IsValidPlayer())
        {
            CreatePlayer();
        }
        Console.Clear();
        Play = false;
    }
    public void CreatePlayer()
    {
        PlayerChooseName(Player);
        PlayerChooseRace(Player);
        Player.AssignRaceBenefits();
        PlayerChooseClass(Player);
        PlayerAssignPoints(Player);
    }
    private void PlayerChooseName(Player  Player)
    {
        while(1==1)
        {
            Console.Clear();
            Console.WriteLine("What is your name?");
            string? input = Console.ReadLine();
            if(input.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("You must have a name.");
                Console.ReadKey();
            }
            else
            {
                Player.Name = input;
                break;
            }
        }
    }
    private void PlayerChooseRace(Player Player)
    {
        Console.Clear();
        Menu = new Menu("ChooseRace");
        Menu.ShowMenu();
        while(Menu.UseMenu)
        {
            Menu.Key= Console.ReadKey();
            Step = Menu.EvaluateKey(Menu.Key);
            if(Step != string.Empty)
            {
                ConfirmRace();
                if(Player.Race.Name == string.Empty)
                {
                    Console.Clear();
                    Menu = new Menu("ChooseRace");
                    Menu.ShowMenu();
                }
            }
        }
    }
    private void PlayerChooseClass(Player Player)
    {
        Console.Clear();
        Menu = new Menu("ChooseClass");
        Menu.ShowMenu();
        while(Menu.UseMenu)
        {
            Menu.Key= Console.ReadKey();
            Step = Menu.EvaluateKey(Menu.Key);
            if(Step != string.Empty)
            {
                ConfirmClass();
                if(Player.Class.Name == string.Empty)
                {
                    Console.Clear();
                    Menu = new Menu("ChooseClass");
                    Menu.ShowMenu();
                }
            }
        }
    }
    private void PlayerAssignPoints(Player Player)
    {
        int PointsToAssign = 8;
        Player _player = new Player();
        _player.Race = new Race(Player.Race.Name);
        _player.AssignRaceBenefits();
        _player.Class = new CharacterClass(Player.Class.Name);
        Console.Clear();
        Menu = new Menu("AssignPoints");
        Menu.ShowMenu(true, _player, 1);
        while(Menu.UseMenu)
        {
            Menu.Key= Console.ReadKey();
            Step = Menu.EvaluateKey(Menu.Key);
            switch(Step)
            {
                case "ADDSTRENGTH" : _player.Strength++;
                                    PointsToAssign--;
                                    Menu = new Menu("AssignPoints");
                                    Menu.ShowMenu(true, _player, 1);
                                    break;
                case "ADDDEXTERITY" : _player.Dexterity++;
                                      PointsToAssign--;
                                      Menu = new Menu("AssignPoints");
                                      Menu.ShowMenu(true, _player, 2);
                                      break;
                case "ADDCONSTITUTION" : _player.Constitution++;
                                         PointsToAssign--;
                                         Menu = new Menu("AssignPoints");
                                         Menu.ShowMenu(true, _player, 3);
                                         break;
                case "ADDINTELLIGENCE" : _player.Intelligence++;
                                         PointsToAssign--;
                                         Menu = new Menu("AssignPoints");
                                         Menu.ShowMenu(true, _player, 4);
                                         break;
                case "ADDWISDOM" : _player.Wisdom++;
                                   PointsToAssign--;
                                   Menu = new Menu("AssignPoints");
                                   Menu.ShowMenu(true, _player, 5);
                                   break;
                case "ADDCHARISMA" : _player.Charisma++;
                                     PointsToAssign--;
                                     Menu = new Menu("AssignPoints");
                                     Menu.ShowMenu(true, _player, 6);
                                     break;
            }
            if(PointsToAssign == 0)
            {
                //ConfirmAssignPoints();
            }
        }
    }
    private void ConfirmRace()
    {
        Console.Clear();
        Menu RaceMenu = new Menu(Step);
        RaceMenu.ShowMenu();
        while(RaceMenu.UseMenu)
        {
            RaceMenu.Key= Console.ReadKey();
            Step = RaceMenu.EvaluateKey(RaceMenu.Key);
            if(Step != "RETURN")
            {
                switch(Step)
                {
                    case "CHOOSEHUMAN" : Player.Race = new Race("Human"); break;
                    case "CHOOSEELF" : Player.Race = new Race("Elf"); break;
                    case "CHOOSEDWARF" : Player.Race = new Race("Dwarf"); break;
                    case "CHOOSEHALFLING" : Player.Race = new Race("Halfling"); break;
                    case "CHOOSEHALFELF" : Player.Race = new Race("Half-Elf"); break;
                    case "CHOOSEHALFORC" : Player.Race = new Race("Half-Orc"); break;
                }
            }
        }
    }
    private void ConfirmClass()
    {
        Console.Clear();
        Menu ClassMenu = new Menu(Step);
        ClassMenu.ShowMenu();
        while(ClassMenu.UseMenu)
        {
            ClassMenu.Key= Console.ReadKey();
            Step = ClassMenu.EvaluateKey(ClassMenu.Key);
            if(Step != "RETURN")
            {
                switch(Step)
                {
                    case "CHOOSEFIGHTER" : Player.Class = new CharacterClass("Fighter"); break;
                }
            }
        }
    }
}