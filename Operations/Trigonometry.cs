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
    /// <summary>
    /// Displays a menu for trigonometric operations, prompts the user for input, and calculates the result of the
    /// selected trigonometric function for a specified angle in degrees.
    /// </summary>
    /// <remarks>This method interacts with the user via the console to select a trigonometric operation (such
    /// as sine, cosine, tangent, cotangent, secant, or cosecant), accepts an angle in degrees, computes the result, and
    /// displays it. If the user provides invalid input or selects an unsupported operation, an error message is
    /// shown.</remarks>
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

    /// <summary>
    /// Converts an angle from degrees to radians.
    /// </summary>
    /// <param name="degree">The angle, in degrees, to convert.</param>
    /// <returns>The equivalent angle measured in radians.</returns>
    public static double DegreeToRadian(double degree)
    {
        return degree * (Math.PI / 180);
    }

    /// <summary>
    /// Displays the result of a trigonometric operation for a specified angle in degrees.
    /// </summary>
    /// <remarks>The result is displayed in the console with a colored output, showing the operation symbol,
    /// the angle in degrees, and the computed value.</remarks>
    /// <param name="degree">The angle, in degrees, for which the trigonometric operation was performed.</param>
    /// <param name="result">The computed result of the trigonometric operation.</param>
    /// <param name="operationType">The type of trigonometric operation that was performed. Must be a valid value of <see
    /// cref="SymbolsOfTrigonomtry"/>.</param>
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
