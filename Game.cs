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
        Player.ShowStats();
        Console.ReadKey();
        Console.Clear();
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
        int PointsToAssign = 8; //this needs to be passed into the menutext. It always reads 8.
        Player _player = new Player();
        _player.Race = new Race(Player.Race.Name);
        _player.AssignRaceBenefits();
        _player.Class = new CharacterClass(Player.Class.Name);
        Console.Clear();
        Menu = new Menu("AssignPoints", PointsToAssign);
        Menu.ShowMenu(true, _player, 1);
        while(Menu.UseMenu)
        {
            Menu.Key= Console.ReadKey();
            Step = Menu.EvaluateKey(Menu.Key);
            switch(Step)
            {
                case "ADDSTRENGTH" : _player.Strength++;
                                    PointsToAssign--;
                                    if(PointsToAssign == 0)
                                    {
                                        ConfirmAssignPoints(_player);
                                        if(Step == "YES")
                                        {
                                            Menu.UseMenu = false;
                                        }
                                        if(Step == "NO")
                                        {
                                            PointsToAssign = 8;
                                            _player = new Player();
                                            _player.Race = new Race(Player.Race.Name);
                                            _player.AssignRaceBenefits();
                                            _player.Class = new CharacterClass(Player.Class.Name);
                                            Console.Clear();
                                            Menu = new Menu("AssignPoints", PointsToAssign);
                                            Menu.ShowMenu(true, _player, 1);
                                        }
                                    }
                                    else
                                    {
                                        Menu = new Menu("AssignPoints", PointsToAssign);
                                        Menu.ShowMenu(true, _player, 1);
                                    }
                                    break;
                case "ADDDEXTERITY" : _player.Dexterity++;
                                      PointsToAssign--;
                                      if(PointsToAssign == 0)
                                      {
                                          ConfirmAssignPoints(_player);
                                      }
                                      else
                                      {
                                          Menu = new Menu("AssignPoints", PointsToAssign);
                                          Menu.ShowMenu(true, _player, 2);
                                      }
                                      break;
                case "ADDCONSTITUTION" : _player.Constitution++;
                                         PointsToAssign--;
                                      if(PointsToAssign == 0)
                                      {
                                          ConfirmAssignPoints(_player);
                                      }
                                      else
                                      {
                                          Menu = new Menu("AssignPoints", PointsToAssign);
                                          Menu.ShowMenu(true, _player, 3);
                                      }
                                         break;
                case "ADDINTELLIGENCE" : _player.Intelligence++;
                                         PointsToAssign--;
                                      if(PointsToAssign == 0)
                                      {
                                          ConfirmAssignPoints(_player);
                                      }
                                      else
                                      {
                                          Menu = new Menu("AssignPoints", PointsToAssign);
                                          Menu.ShowMenu(true, _player, 4);
                                      }
                                         break;
                case "ADDWISDOM" : _player.Wisdom++;
                                   PointsToAssign--;
                                      if(PointsToAssign == 0)
                                      {
                                          ConfirmAssignPoints(_player);
                                      }
                                      else
                                      {
                                          Menu = new Menu("AssignPoints", PointsToAssign);
                                          Menu.ShowMenu(true, _player, 5);
                                      }
                                   break;
                case "ADDCHARISMA" : _player.Charisma++;
                                     PointsToAssign--;
                                     if(PointsToAssign == 0)
                                     {
                                         ConfirmAssignPoints(_player);
                                     }
                                     else
                                     {
                                         Menu = new Menu("AssignPoints", PointsToAssign);
                                         Menu.ShowMenu(true, _player, 6);
                                     }
                                     break;
            }
        }
    }
    private void ConfirmAssignPoints(Player _player)
    {
        Console.Clear();
        Menu YesNoMenu = new Menu("YesNo");
        _player.ShowAttributes();
        Console.WriteLine("");
        YesNoMenu.MenuText = "Confirm point distribution?";
        YesNoMenu.ShowMenu();
        while(YesNoMenu.UseMenu)
        {
            YesNoMenu.Key= Console.ReadKey();
            Step = YesNoMenu.EvaluateKey(YesNoMenu.Key);
            if(Step == "YES")
            {
                SavePoints(_player);
                YesNoMenu.UseMenu = false;
            }
            else if (Step == "NO")
            {
                YesNoMenu.UseMenu = false;
            }
            else
            {
                Console.Clear();
                _player.ShowAttributes();
                Console.WriteLine("");
                YesNoMenu.MenuText = "Confirm point distribution?";
                YesNoMenu.ShowMenu();
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
    private void SavePoints(Player _player)
    {
        Player.Strength = _player.Strength;
        Player.Dexterity = _player.Dexterity;
        Player.Constitution = _player.Constitution;
        Player.Intelligence = _player.Intelligence;
        Player.Wisdom = _player.Wisdom;
        Player.Charisma = _player.Charisma;
    }
}