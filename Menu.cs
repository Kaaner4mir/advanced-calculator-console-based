class Menu
{
    public static void MainMenu()
    {
        var mainMenuItems = new (string text, ConsoleColor Color)[]
        {
            ( " 🧮 Elementary Operations", ConsoleColor.White),
            ( $" {new string('-',40)}",ConsoleColor.White),
            ( " 1. Addition", ConsoleColor.DarkMagenta),
            ( " 2. Subtraction", ConsoleColor.Magenta),
            ( " 3. Multiplication", ConsoleColor.DarkBlue),
            ( " 4. Division", ConsoleColor.Blue),

            ( "\n 🔢 Advanced Mathematical Operations", ConsoleColor.Blue),
            ( $" {new string('-',40)}",ConsoleColor.White),
            ( " 5. Exponentiation", ConsoleColor.DarkCyan),
            ( " 6. Root", ConsoleColor.Cyan),
            ( " 7. Factorial", ConsoleColor.DarkGreen),
            ( " 8. Modulo", ConsoleColor.Green),

            ( "\n 📐 Trigonometric & Logarithmic Functions", ConsoleColor.DarkYellow),
            ( $" {new string('-',40)}",ConsoleColor.White),
            ( " 9. Trigonometric Functions", ConsoleColor.DarkYellow),
            ( " 10. Logarithmic Functions", ConsoleColor.Yellow),

            ( "\n 💾 Memory & Exit Operations", ConsoleColor.DarkRed),
            ( $" {new string('-',40)}",ConsoleColor.White),
            ( " 11. Memory Operations", ConsoleColor.DarkRed),
            ( " 12. Exit", ConsoleColor.Red),
        };

        foreach (var item in mainMenuItems)
        {
            Utils.WriteColored(item.text, item.Color);
        }
    }
}