Console.Clear();
Game Game = new Game();
Menu Menu = new Menu("MainMenu");
Menu.ShowMenu();
while(Menu.UseMenu)
{
    Menu.Key= Console.ReadKey();
    Game.Step = Menu.EvaluateKey(Menu.Key);
}
Game.EvaluatePlay();
Console.Clear();
Game.PlayGame();
