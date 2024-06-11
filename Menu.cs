public class Menu
{
    public string MenuText { get; set; }
    public List<string> MenuOptions { get; set; } = new List<string>();
    public List<string> MenuMethods { get; set; } = new List<string>();
    public bool UseMenu { get; set; }
    public int SelectedOption { get; set; } = 1;
    public ConsoleKeyInfo Key {get; set; }
    public Menu(string MenuType)
    {
        switch(MenuType)
        {
            case "MainMenu" : LoadMainMenu(); break;
            default : LoadMainMenu(); break;
        }
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
    public void ShowMenu()
    {
        Console.WriteLine(MenuText);
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
            return EvaluateMethod();
        }
        return string.Empty;
    }
    private string EvaluateMethod()
    {
        string MethodTag = MenuMethods[SelectedOption-1];
        switch(MethodTag)
        {
            case "EXIT" : ExitMenu(); return MethodTag;
            case "NEWGAME" : ExitMenu(); return MethodTag;
            default : ExitMenu(); return MethodTag;
        }
    }
    public void ExitMenu()
    {
        UseMenu = false;
        SelectedOption = 1;
        MenuOptions = new List<string>();
        MenuText = string.Empty;
    }
}