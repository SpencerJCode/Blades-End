using System.Runtime.CompilerServices;

public class Game
{
    Random Random = new Random();
    public string Step { get; set; } = string.Empty;
    public bool ContinuePlay { get; set; } = false;
    public Clock Clock { get; set; } = new Clock();
    public StoryBoard StoryBoard { get; set; } = new StoryBoard("Blank");
    public Player Player { get; set; } = new Player();
    public Area CurrentArea { get; set; } = new Area("Blank");
    public Menu Menu { get; set; } = new Menu("Blank");
    public Dice Dice = new Dice();
    public void EvaluatePlay()
    {
        if(Step == "NEWGAME" || Step == "CONTINUE")
        {
            ContinuePlay = true;
        }
        else
        {
            ContinuePlay = false;
        }
    }
    public void PlayGame()
    {
        if(!Player.IsValidPlayer())
        {
            CreatePlayer();
            InitializeGame(true);
        }
        else
        {
            LoadPlayer(); //Logic doesn't exist to save/load.Here just as a placeholder.
            InitializeGame(false);
        }
        Play(new Menu("Play", CurrentArea, Player));
    }
    public void Play(Menu PlayMenu)
    {
        PlayMenu.ShowMenu();
        while(PlayMenu.UseMenu)
        {
            PlayMenu.Key= Console.ReadKey();
            Step = PlayMenu.EvaluateKey(PlayMenu.Key);
            if(Step != string.Empty)
            {
                if(EvaluateStep())
                {
                    PlayMenu = new Menu("Play", CurrentArea, Player);
                    PlayMenu.ShowMenu();
                }
                else
                {
                    PlayMenu.UseMenu = false;
                }
            }
        }
    }
    private bool EvaluateStep()
    {
        switch(Step)
        {
            case "EXIT" : return false;
            case "SAVE" : SaveGame(); return true;
            case "STATS" : Player.ShowStats(true); return true;
            case "INVENTORY" : Player.ShowInventory(); return true;
            case "SLEEP" : Sleep(); return true;
            case "HEAL" : Heal(); return true;
            case "TRAIN" : Train(); return true;
            case "EXPLORE" : Explore(); return true;
            default : Console.WriteLine($"No step method exists for {Step}"); return false;
        }
    }
    private void Train()
    {
        Menu TrainMenu = new Menu("Train", CurrentArea, Player);
        TrainMenu.ShowMenu();
        while(TrainMenu.UseMenu)
        {
            TrainMenu.Key= Console.ReadKey();
            Step = TrainMenu.EvaluateKey(TrainMenu.Key);
            if(Step != string.Empty)
            {
                switch(Step)
                {
                    case "PRACTICECOMBAT" : PracticeCombat(); break;
                }
                TrainMenu.UseMenu = false;
            }
        }
    }
    private void Explore()
    {

    }
    private void PracticeCombat()
    {
        Dummy Dummy = new Dummy(CurrentArea.Difficulty);
        List<Enemy> Enemies = new List<Enemy>();
        Enemies.Add(Dummy);
        Fight(Enemies);
    }
    private void Sleep()
    {
        Menu SleepMenu = new Menu("YesNo");
        if(CurrentArea.SleepPrice == 0)
        {
            SleepMenu.MenuText = $"Sleep in {CurrentArea.SleepAtArea} for free?";
        }
        else
        {
            SleepMenu.MenuText = $"Sleep in {CurrentArea.SleepAtArea} for {CurrentArea.SleepPrice} gold?";
        }
        SleepMenu.ShowMenu();
        while(SleepMenu.UseMenu)
        {
            SleepMenu.Key= Console.ReadKey();
            Step = SleepMenu.EvaluateKey(SleepMenu.Key);
            if(Step == "YES")
            {
                SleepMenu.UseMenu = false;
                Player.Gold -= CurrentArea.SleepPrice;
                SleepHeal();
            }
            else if (Step == "NO")
            {
                SleepMenu.UseMenu = false;
            }
        }
    }
    private void SleepHeal()
    {
        Console.Clear();
        Console.WriteLine($"You slept the night in {CurrentArea.SleepAtArea}.");
        int _ConMod = CalculateMod(Player.Constitution);
        int HPGainedBySleeping = _ConMod + 1;
        if((Player.MaxHP - Player.CurrentHP) >= HPGainedBySleeping)
        {
            Player.CurrentHP += HPGainedBySleeping;
            Console.WriteLine($"You gained {HPGainedBySleeping} HP.");
        }
        else if (Player.MaxHP != Player.CurrentHP)
        {
            HPGainedBySleeping = Player.MaxHP - Player.CurrentHP;
            Player.CurrentHP = Player.MaxHP;
            Console.WriteLine($"You gained {HPGainedBySleeping} HP.");
        }
        else
        {
            Console.WriteLine("You are already at full health.");
        }
        Console.ReadKey();
        Console.Clear();
        Clock.AdvanceClock(1);
        Clock.ShowClock(true);
    }
    private void Heal()
    {
        Menu HealMenu = new Menu("YesNo");
        if(CurrentArea.HealPrice == 0)
        {
            HealMenu.MenuText = $"Heal in {CurrentArea.HealAtArea} for free?";
        }
        else
        {
            HealMenu.MenuText = $"Heal in {CurrentArea.HealAtArea} for {CurrentArea.HealPrice * (Player.MaxHP - Player.CurrentHP)} gold?";

        }
        HealMenu.ShowMenu();
        while(HealMenu.UseMenu)
        {
            HealMenu.Key= Console.ReadKey();
            Step = HealMenu.EvaluateKey(HealMenu.Key);
            if(Step == "YES")
            {
                HealMenu.UseMenu = false;
                BuyHeal(CurrentArea.HealPrice * (Player.MaxHP - Player.CurrentHP));
            }
            else if (Step == "NO")
            {
                HealMenu.UseMenu = false;
            }
        }
    }
    private void BuyHeal(int HealPrice)
    {
        Console.WriteLine($"Healed at the {CurrentArea.HealAtArea} for {HealPrice} gold. ");
        Player.Gold -= CurrentArea.HealPrice * (Player.MaxHP - Player.CurrentHP);
        Player.CurrentHP = Player.MaxHP;
        Console.ReadKey();
        Console.Clear();
    }
    private void SaveGame()
    {

    }
    public void LoadPlayer()
    {

    }
    public void InitializeGame(bool IsNewGame)
    {
        if(IsNewGame)
        {
            CurrentArea = new Area("BladesEndHQ");
            StoryBoard = new StoryBoard("IntroDialogue");
            StoryBoard.RunDialogue();
        }
        else
        {
            //Below codes will need to be obtained from loading. Putting new game codes in for now.
            CurrentArea = new Area("BladesEndHQ");
            StoryBoard = new StoryBoard("IntroDialogue");
        }
        Console.Clear();
    }
    public void CreatePlayer()
    {
        PlayerChooseName(Player);
        PlayerChooseRace(Player);
        Player.AssignRaceBenefits();
        PlayerChooseClass(Player);
        PlayerAssignPoints(Player);
        Player.LoadSkillPoints(CalculateMod(Player.Intelligence), true);
        PlayerChooseSkills(Player);
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
            Menu.Key = Console.ReadKey();
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
                if(Player.Classes[0].Name == string.Empty)
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
        _player.Name = Player.Name;
        _player.Race = new Race(Player.Race.Name);
        _player.AssignRaceBenefits();
        _player.Classes[0] = new CharacterClass(Player.Classes[0].Name);
        Console.Clear();
        Menu = new Menu("AssignPoints", PointsToAssign);
        Menu.ShowMenu(true, false, _player, 1);
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
                                            _player.Classes[0] = new CharacterClass(Player.Classes[0].Name);
                                            Console.Clear();
                                            Menu = new Menu("AssignPoints", PointsToAssign);
                                            Menu.ShowMenu(true, false, _player, 1);
                                        }
                                    }
                                    else
                                    {
                                        Menu = new Menu("AssignPoints", PointsToAssign);
                                        Menu.ShowMenu(true, false, _player, 1);
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
                                          Menu.ShowMenu(true, false, _player, 2);
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
                                          Menu.ShowMenu(true, false, _player, 3);
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
                                          Menu.ShowMenu(true, false, _player, 4);
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
                                          Menu.ShowMenu(true, false, _player, 5);
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
                                         Menu.ShowMenu(true, false, _player, 6);
                                     }
                                     break;
            }
        }
    }
    private void PlayerChooseSkills(Player Player)
    {
        Console.Clear();
        int skillMax = Player.Classes.Sum(c=>c.ClassLevel)+3;
        int StartingPoints = Player.AvailableSkillPoints;
        Menu = new Menu("AssignSkills", CurrentArea, Player);
        Menu.ShowMenu(false, true, Player, 1);
        while(Menu.UseMenu)
        {
            Menu.Key= Console.ReadKey();
            Step = Menu.EvaluateKey(Menu.Key);
            if(Step != string.Empty)
            {
                 if(Player.Skills[Convert.ToInt32(Step)].Points != skillMax)
                {
                    Player.UseSkillPoint(Convert.ToInt32(Step));
                }
                if(Player.AvailableSkillPoints == 0)
                {
                    ConfirmAssignSkills(Player);
                    if(Step == "YES")
                    {
                        Menu.UseMenu = false;
                    }
                    else
                    {
                        Player.AvailableSkillPoints = StartingPoints;
                        foreach(Skill skill in Player.Skills)
                        {
                            skill.Points=0;
                        }
                        Menu = new Menu("AssignSkills", CurrentArea, Player);
                        Menu.ShowMenu(false, true, Player, 1);
                    }
                }
                else
                {
                    Menu = new Menu("AssignSkills", CurrentArea, Player);
                    Menu.ShowMenu(false, true, Player, Convert.ToInt32(Step)+1);
                }
            }
        }
    }
    private void ConfirmAssignSkills(Player _player)
    {
        Console.Clear();
        Menu YesNoMenu = new Menu("YesNo");
        _player.ShowSkills();
        Console.WriteLine("");
        YesNoMenu.MenuText = "Confirm point distribution?";
        YesNoMenu.ShowMenu();
        while(YesNoMenu.UseMenu)
        {
            YesNoMenu.Key= Console.ReadKey();
            Step = YesNoMenu.EvaluateKey(YesNoMenu.Key);
            if(Step == "YES" || Step == "NO")
            {
                YesNoMenu.UseMenu = false;
            }
            else
            {
                Console.Clear();
                _player.ShowSkills();
                Console.WriteLine("");
                YesNoMenu.MenuText = "Confirm point distribution?";
                YesNoMenu.ShowMenu();
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
                    case "CHOOSEFIGHTER" : Player.Classes[0] = new CharacterClass("Fighter");
                                           Player.EquipStartingGear();
                                           break;
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
    public int CalculateMod(int stat)
    {
        return (int)Math.Floor(Convert.ToDouble(((stat-10)/2)));
    }
    private void Fight(List<Enemy> Enemies)
    {
        List<string> FightOrder = Initiative(Enemies);
        while(Enemies.Any(e=>e.CurrentHP >0) && Player.CurrentHP > 0)
        {
            for(int i=0; i<=FightOrder.Count(); i++)
            {
                Console.ReadKey();
                if(i == FightOrder.Count())
                {
                    i=0;
                }
                if(FightOrder[i] == "Player")
                {
                    Menu FightMenu = new Menu("Fight", CurrentArea, Player, Enemies);
                    FightMenu.ShowMenu();
                    while(FightMenu.UseMenu)
                    {
                        FightMenu.Key = Console.ReadKey();
                        Step = FightMenu.EvaluateKey(FightMenu.Key);
                        if(Step != string.Empty)
                        {
                            Console.Clear();
                            Console.WriteLine($"{Player.Name} attacks {Enemies[Convert.ToInt32(Step)].Name}!");
                        }
                    }
                }
                else if(Enemies[Convert.ToInt32(FightOrder[i])].IsDisabled)
                {
                    Console.Clear();
                    Console.WriteLine($"{Enemies[Convert.ToInt32(FightOrder[i])].Name} is disabled and cannot attack!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{Enemies[Convert.ToInt32(FightOrder[i])].Name} attacks!");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            
        }
    }
    private List<string> Initiative(List<Enemy> Enemies)
    {
        List<string> FightOrder = new List<string>();
        int PlayerInititative = Dice.d20() + CalculateMod(Player.Dexterity);
        List<string> BeforePlayer = new List<string>();
        List<string> AfterPlayer = new List<string>();
        int index = 0;
        foreach(Enemy enemy in Enemies)
        {
            if(Dice.d20() + CalculateMod(enemy.Dexterity) > PlayerInititative)
            {
                BeforePlayer.Add($"{index}");
            }
            else
            {
                AfterPlayer.Add($"{index}");
            }
            index++;
        }
        foreach(string enemy in BeforePlayer)
        {
            FightOrder.Add(enemy);
        }
        FightOrder.Add("Player");
        foreach(string enemy in AfterPlayer)
        {
            FightOrder.Add(enemy);
        }
        return FightOrder; //this doesn't ACTUALLY determine the correct fight order. Enemies aren't organize by
        //initiative roll, only whether or not they are before the player. Logid tbd.
    }
}