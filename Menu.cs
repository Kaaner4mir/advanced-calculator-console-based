class Menu
{
    /// <summary>
    /// Displays the main menu of available calculator operations to the console, organized by category and color-coded
    /// for clarity.
    /// </summary>
    /// <remarks>The menu includes elementary operations, advanced mathematical functions, trigonometric and
    /// logarithmic functions, as well as memory and exit options. Each menu item is displayed with a distinct color to
    /// enhance readability and user experience.</remarks>
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
            ( " 10.Logarithmic Functions", ConsoleColor.Yellow),

            ( "\n 💾 Memory & Exit Operations", ConsoleColor.DarkRed),
            ( $" {new string('-',40)}",ConsoleColor.White),
            ( " 11.Memory Operations", ConsoleColor.DarkRed),
            ( " 12.Exit", ConsoleColor.Red),
        };

        foreach (var item in mainMenuItems)
        {
            Utils.WriteColored(item.text, item.Color);
        }
    }

    /// <summary>
    /// Displays a menu of available trigonometric operations in the console with color-coded formatting.
    /// </summary>
    /// <remarks>The menu includes options for sine, cosine, tangent, cotangent, secant, and cosecant
    /// functions. Each menu item is displayed in a distinct color to enhance readability.</remarks>
    public static void TrigonometryMenu()
    {
        var trigonometryMenuItems = new (string text, ConsoleColor Color)[]
        {
             ( " 🧮 Trigonometric Operations", ConsoleColor.Magenta),
             ( $" {new string('-',40)}",ConsoleColor.White),
             ( " 1. Sine (sin)",ConsoleColor.DarkBlue),
             ( " 2. Cosine (cos)",ConsoleColor.DarkCyan),
             ( " 3. Tangent (tan)",ConsoleColor.DarkGreen),
             ( " 4. Cotangent (cot)",ConsoleColor.DarkYellow),
             ( " 5. Secant (sec)",ConsoleColor.DarkRed),
             ( " 6. Cosecant (csc)",ConsoleColor.White),
        };

        foreach (var item in trigonometryMenuItems)
        {
            Utils.WriteColored(item.text, item.Color);
        }
    }

    /// <summary>
    /// Displays the memory operations menu in the console with color-coded options.
    /// </summary>
    /// <remarks>The menu includes options for memory-related actions such as Memory Plus, Memory Minus,
    /// Memory Recall, Memory Clear, and Memory Store.  Each menu item is displayed in a distinct color to enhance
    /// readability in the console.</remarks>
    public static void MemoryMenu()
    {
        var memoryMenuItems = new (string text, ConsoleColor Color)[]
        {
             ( " 💾 Memory Operations", ConsoleColor.Magenta),
             ( $" {new string('-',20)}",ConsoleColor.White),
             ( " 1. Memory Plus",ConsoleColor.DarkBlue),
             ( " 2. Memory Minus",ConsoleColor.DarkCyan),
             ( " 3. Memory Recall",ConsoleColor.DarkGreen),
             ( " 4. Memory Clear",ConsoleColor.DarkYellow),
             ( " 5. Memory Store",ConsoleColor.DarkRed),
        };

        foreach (var item in memoryMenuItems)
        {
            Utils.WriteColored(item.text, item.Color);
        }
    }

    /// <summary>
    /// Displays a menu of logarithm operation options in the console with color-coded formatting.
    /// </summary>
    /// <remarks>The menu includes options for base-10 logarithm, natural logarithm, and logarithm with a
    /// custom base.  Each menu item is displayed in a distinct color to enhance readability in the console.</remarks>
    public static void LogarithmMenu()
    {
        var memoryMenuItems = new (string text, ConsoleColor Color)[]
        {
             ( " 💾 Logarithm Operations", ConsoleColor.Magenta),
             ( $" {new string('-',25)}",ConsoleColor.White),
             ( " 1. Log Base10",ConsoleColor.DarkBlue),
             ( " 2. Natural Logarithm",ConsoleColor.DarkCyan),
             ( " 3. Log Custom Base",ConsoleColor.DarkGreen),
        };

        foreach (var item in memoryMenuItems)
        {
            Utils.WriteColored(item.text, item.Color);
        }
    }
}