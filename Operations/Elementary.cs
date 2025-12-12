public enum SymbolsOfElementary
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

class Elementary
{
    /// <summary>
    /// Performs a basic arithmetic operation on two user-provided numbers using the specified operation type and
    /// delegate.
    /// </summary>
    /// <remarks>This method prompts the user to enter two numbers and applies the specified operation. For
    /// division, it checks for division by zero and returns <see langword="null"/> if the operation is invalid. Any
    /// errors encountered during input or calculation are reported, and <see langword="null"/> is returned.</remarks>
    /// <param name="operationType">The type of arithmetic operation to perform. Determines the operation's symbol and may affect input validation
    /// (for example, division checks for zero divisors).</param>
    /// <param name="operation">A delegate that defines the operation to apply to the two input numbers. The delegate should accept two <see
    /// cref="double"/> values and return the result as a <see cref="double"/>.</param>
    /// <returns>The result of the operation as a <see cref="double"/> if successful; otherwise, <see langword="null"/> if an
    /// error occurs or the operation is undefined (such as division by zero).</returns>
    public static double? BasicOperation(SymbolsOfElementary operationType, Func<double, double, double> operation)
    {
        try
        {
            double val1 = Utils.GetInput<double>("\n ➡️ Enter the first number: ");
            double val2 = Utils.GetInput<double>(" ➡️ Enter the second number: ");

            if (operationType == SymbolsOfElementary.Division)
            {
                if (val1 == 0 && val2 == 0)
                    throw new Exception("Undefined!");

                if (val2 == 0)
                    throw new Exception("The divisor cannot be 0!");
            }

            double result = operation(val1, val2);

            return ShowResult(result, val1, val2, operationType);
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ An error has occurred in basic operation => {ex.Message}", ConsoleColor.Red);
            return null;
        }
    }

    /// <summary>
    /// Displays the result of an elementary arithmetic operation in the console and returns the result.
    /// </summary>
    /// <remarks>The result is displayed in the console with a green checkmark and the corresponding
    /// arithmetic expression.  This method does not perform any calculation; it only formats and outputs the provided
    /// values.</remarks>
    /// <param name="result">The computed result of the arithmetic operation to display.</param>
    /// <param name="val1">The first operand used in the arithmetic operation.</param>
    /// <param name="val2">The second operand used in the arithmetic operation.</param>
    /// <param name="operationType">The type of arithmetic operation performed. Determines the symbol shown in the output.</param>
    /// <returns>The value of <paramref name="result"/>.</returns>
    public static double ShowResult(double result, double val1, double val2, SymbolsOfElementary operationType)
    {
        string symbol = operationType switch
        {
            SymbolsOfElementary.Addition => "+",
            SymbolsOfElementary.Subtraction => "-",
            SymbolsOfElementary.Multiplication => "*",
            SymbolsOfElementary.Division => "/",
            _ => "?"
        };

        Utils.WriteColored($"\n ✅ {val1} {symbol} {val2} = {result}", ConsoleColor.Green);
        return result;
    }

}
