public enum OperationType
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

class Elementary
{
    public static double? BasicOperation(OperationType operationType, Func<double, double, double> operation)
    {
        try
        {
            double val1 = Utils.GetInput<double>("\n➡️ Enter the first number: ");
            double val2 = Utils.GetInput<double>("➡️ Enter the second number: ");

            if (operationType == OperationType.Division)
            {
                if (val1 == 0 && val2 == 0)
                {
                    Utils.WriteColored("\n⛔ Undefined!", ConsoleColor.Red);
                    return double.NaN;
                }

                if (val2 == 0)
                {
                    Utils.WriteColored("\n⛔ The divisor cannot be 0!", ConsoleColor.Red);
                    return double.NaN;
                }
            }

            double result = operation(val1, val2);

            return ShowResult(result, val1, val2, operationType);
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n⛔ An error has occurred: {ex.Message}", ConsoleColor.Red);
            return null;
        }
    }

    public static double ShowResult(double result, double val1, double val2, OperationType operationType)
    {
        string symbol = operationType switch
        {
            OperationType.Addition => "+",
            OperationType.Subtraction => "-",
            OperationType.Multiplication => "*",
            OperationType.Division => "/",
            _ => "?"
        };

        Utils.WriteColored($"\n✅ {val1} {symbol} {val2} = {result}", ConsoleColor.Green);
        return result;
    }
}
