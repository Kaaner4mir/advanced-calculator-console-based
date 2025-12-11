class Menu
{
    public static void MainMenu()
    {
        var mainMenuItems = new (string text, ConsoleColor Color)[]
        {
            ( "<< Operations >>\n", ConsoleColor.Cyan),
            ( " 1. Addition", ConsoleColor.White),
            ( " 2. Subtraction", ConsoleColor.Yellow),
            ( " 3. Multiplication", ConsoleColor.Red),
            ( " 4. Division", ConsoleColor.Green),
        };

        foreach (var item in mainMenuItems)
        {
            Utils.WriteColored(item.text, item.Color);
        }
    }
}