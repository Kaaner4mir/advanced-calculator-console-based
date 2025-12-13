public enum SymbolsOfLogarithm
{
    LogBase10,
    NaturalLogarithm,
    LogCustomBase
}

class Logarithm
{
    /// <summary>
    /// Displays a menu for logarithm operations and processes user input to perform the selected calculation.
    /// </summary>
    /// <remarks>This method interacts with the user via the console, allowing selection between base-10
    /// logarithm, natural logarithm, or logarithm with a custom base. It prompts for the necessary input values,
    /// validates them, computes the result, and displays the outcome. If invalid input is provided, an error message is
    /// shown.</remarks>
    public static void LogarithmOperations()
    {
        try
        {
            Console.Clear();
            Menu.LogarithmMenu();

            short inputVal = Utils.GetInput<short>("\n 👉 Please enter the logarithm operation: ");

            if (inputVal < 1 || inputVal > 3)
                throw new Exception("Invalid operation selected");

            SymbolsOfLogarithm operationType = (SymbolsOfLogarithm)(inputVal - 1);

            double result;

            switch (operationType)
            {
                case SymbolsOfLogarithm.LogBase10:
                    {
                        double x = Utils.GetInput<double>("\n ➡️ Enter the number: ");

                        ValidateNumber(x);

                        result = Math.Log10(x);
                    }
                    break;

                case SymbolsOfLogarithm.NaturalLogarithm:
                    {
                        double x = Utils.GetInput<double>("\n ➡️ Enter the number: ");

                        ValidateNumber(x);

                        result = Math.Log(x);
                    }
                    break;

                case SymbolsOfLogarithm.LogCustomBase:
                    {
                        double a = Utils.GetInput<double>("\n ➡️ Enter the base: ");
                        double b = Utils.GetInput<double>("\n ➡️ Enter the number: ");

                        ValidateBase(a);
                        ValidateNumber(b);

                        result = Math.Log(b) / Math.Log(a);
                    }
                    break;

                default:
                    throw new Exception("Unknown operation");
            }

            ShowResult(result, operationType);
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ Error => {ex.Message}", ConsoleColor.Red);
        }
    }

    private static void ValidateNumber(double x)
    {
        if (x <= 0)
            throw new Exception("The number must be positive for logarithm");
    }

    private static void ValidateBase(double a)
    {
        if (a <= 0 || a == 1)
            throw new Exception("Base must be positive and not equal to 1");
    }

    public static void ShowResult(double result, SymbolsOfLogarithm operationType)
    {
        string symbol = operationType switch
        {
            SymbolsOfLogarithm.LogBase10 => "log",
            SymbolsOfLogarithm.NaturalLogarithm => "ln",
            SymbolsOfLogarithm.LogCustomBase => "logₐ",
            _ => "?"
        };

        Utils.WriteColored($"\n ✅ Result ({symbol}) = {result}", ConsoleColor.Green);
    }
}
