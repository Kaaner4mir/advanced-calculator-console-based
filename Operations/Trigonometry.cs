public enum SymbolsOfTrigonomtry
{
    Sine,
    Cosine,
    Tangent,
    Cotangent,
    Secant,
    Cosecant
}

class Trigonometry
{
    public static void TrigonometricOperations()
    {
        try
        {
            Console.Clear();
            Menu.TrigonometryMenu();

            short inputVal = Utils.GetInput<short>("\n 👉 Please enter the operation you wish to perform numerically: ");

            if (inputVal < 1 || inputVal > 6)
                throw new Exception("An invalid transaction");

            double degree = Utils.GetInput<double>("\n ➡️ Enter the degree: ");
            double radian = DegreeToRadian(degree);

            SymbolsOfTrigonomtry operationType = (SymbolsOfTrigonomtry)(inputVal - 1);

            double result = operationType switch
            {
                SymbolsOfTrigonomtry.Sine => Math.Sin(radian),
                SymbolsOfTrigonomtry.Cosine => Math.Cos(radian),
                SymbolsOfTrigonomtry.Tangent => Math.Tan(radian),
                SymbolsOfTrigonomtry.Cotangent => 1.0 / Math.Tan(radian),
                SymbolsOfTrigonomtry.Secant => 1.0 / Math.Cos(radian),
                SymbolsOfTrigonomtry.Cosecant => 1.0 / Math.Sin(radian),
                _ => throw new Exception("Unknown operation")
            };

            ShowResult(degree, result, operationType);
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ Error => {ex.Message}", ConsoleColor.Red);
        }
    }

    public static double DegreeToRadian(double degree)
    {
        return degree * (Math.PI / 180);
    }

    public static void ShowResult(double degree, double result, SymbolsOfTrigonomtry operationType)
    {
        string symbol = operationType switch
        {
            SymbolsOfTrigonomtry.Sine => "sin",
            SymbolsOfTrigonomtry.Cosine => "cos",
            SymbolsOfTrigonomtry.Tangent => "tan",
            SymbolsOfTrigonomtry.Cotangent => "cot",
            SymbolsOfTrigonomtry.Secant => "sec",
            SymbolsOfTrigonomtry.Cosecant => "csc",
            _ => "?"
        };

        Utils.WriteColored($"\n ✅ {symbol}({degree}°) = {result}", ConsoleColor.Green);
    }
}
