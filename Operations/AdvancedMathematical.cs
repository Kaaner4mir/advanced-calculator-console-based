public enum SymbolsOfAdvancedMathematical
{
    Exponentiation,
    Root,
    Factorial,
    Modulo
}

class AdvancedMathematical
{
    /// <summary>
    /// Performs an exponentiation operation using the specified operation type and function.
    /// </summary>
    /// <remarks>This method prompts the user to input the base and exponent values. If the operation is
    /// undefined for the given inputs, the method returns <see cref="double.NaN"/>. If an exception occurs during
    /// execution, the method returns <see langword="null"/>.</remarks>
    /// <param name="operationType">The type of advanced mathematical operation to perform. Must be <see
    /// cref="SymbolsOfAdvancedMathematical.Exponentiation"/> for exponentiation.</param>
    /// <param name="operation">A function that takes two <see cref="double"/> values representing the base and exponent, and returns the result
    /// of the operation.</param>
    /// <returns>The result of the exponentiation as a <see cref="double"/> value, or <see langword="null"/> if an error occurs.
    /// Returns <see cref="double.NaN"/> if the operation is mathematically undefined (such as zero raised to a negative
    /// or zero exponent, or a negative base with a non-integer exponent).</returns>
    public static double? Exponentiation(SymbolsOfAdvancedMathematical operationType, Func<double, double, double> operation)
    {
        try
        {
            double baseNum = Utils.GetInput<double>("\n ➡️ Enter the base number: ");
            double exponent = Utils.GetInput<double>(" ➡️ Enter the exponent: ");

            if (operationType == SymbolsOfAdvancedMathematical.Exponentiation)
            {
                if ((baseNum == 0 && exponent < 0) || (baseNum == 0 && exponent == 0) || (baseNum < 0 && exponent % 1 != 0))
                {
                    Utils.WriteColored("\n ⛔ Undefined!", ConsoleColor.Red);
                    return double.NaN;
                }
            }

            double result = operation(baseNum, exponent);

            return ShowResult(result, baseNum, exponent, operationType);
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ An error has occurred in basic operation: {ex.Message}", ConsoleColor.Red);
            return null;
        }
    }

    /// <summary>
    /// Calculates the result of a root operation using the specified operation type and function.
    /// </summary>
    /// <remarks>This method prompts the user to enter the root degree and radicand, then applies the provided
    /// operation function to compute the result. If the operation is undefined for the given inputs, the method returns
    /// <see cref="double.NaN"/>. If an exception occurs during execution, the method returns <see
    /// langword="null"/>.</remarks>
    /// <param name="operationType">The type of advanced mathematical operation to perform. Typically specifies the root operation to be applied.</param>
    /// <param name="operation">A function that takes the root degree and radicand as input and returns the computed result. The function should
    /// implement the logic for the desired root calculation.</param>
    /// <returns>The result of the root operation as a <see cref="double"/> value, or <see langword="null"/> if an error occurs
    /// during the calculation. Returns <see cref="double.NaN"/> if the operation is mathematically undefined (for
    /// example, an even root of a negative number or a non-positive root degree).</returns>
    public static double? Root(SymbolsOfAdvancedMathematical operationType, Func<double, double, double> operation)
    {
        try
        {
            double rootDegree = Utils.GetInput<double>("\n ➡️ Enter the root degree: ");
            double radicand = Utils.GetInput<double>(" ➡️ Enter the radicand: ");

            if (operationType == SymbolsOfAdvancedMathematical.Root)
            {
                if ((radicand < 0 && rootDegree % 2 == 0) || (rootDegree <= 0))
                {
                    Utils.WriteColored("\n ⛔ Undefined!", ConsoleColor.Red);
                    return double.NaN;
                }
            }

            double result = operation(rootDegree, radicand);

            return ShowResult(result, rootDegree, radicand, operationType);
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ An error has occurred in advanced operation: {ex.Message}", ConsoleColor.Red);
            return null;
        }
    }

    /// <summary>
    /// Calculates the factorial of a user-supplied non-negative integer.
    /// </summary>
    /// <remarks>The method prompts the user to enter a number at runtime. The input must be a non-negative
    /// integer; otherwise, the method displays an error and returns <see langword="null"/>.</remarks>
    /// <param name="operationType">The type of advanced mathematical operation to perform. This parameter determines how the result is displayed or
    /// processed, but does not affect the factorial calculation itself.</param>
    /// <returns>The factorial of the entered number as a 64-bit integer, or <see langword="null"/> if an error occurs (such as
    /// invalid input).</returns>
    public static long? Factorial(SymbolsOfAdvancedMathematical operationType)
    {
        try
        {
            long result = 1;

            long number = Utils.GetInput<long>("\n ➡️ Enter the number whose factorial value you want to find: ");

            if (number < 0)
                throw new Exception("The number entered cannot be negative!");

            if (number % 1 != 0)
                throw new Exception("The number entered cannot be a decimal number!");

            for (long i = number; i > 0; i--)
                result *= i;

            return Convert.ToInt64(ShowResult(result, number, 0, operationType));
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ An error has occurred in advanced operation => {ex.Message}", ConsoleColor.Red);
            return null;
        }
    }

    /// <summary>
    /// Performs a modular arithmetic operation using the specified operation type and function, prompting the user for
    /// input values.
    /// </summary>
    /// <remarks>This method prompts the user to enter the dividend and divisor values via the console. If the
    /// divisor is zero, the method displays an error and returns <see langword="null"/>. Any exceptions encountered
    /// during input or calculation are caught, and an error message is displayed to the user.</remarks>
    /// <param name="operationType">The type of advanced mathematical operation to perform. This value determines how the result is displayed or
    /// labeled.</param>
    /// <param name="operation">A function that defines the operation to perform on the user-provided dividend and divisor. The function should
    /// accept two <see cref="double"/> values (dividend and divisor) and return the computed result as a <see
    /// cref="double"/>.</param>
    /// <returns>The result of the operation as a <see cref="double"/> if successful; otherwise, <see langword="null"/> if an
    /// error occurs (such as invalid input or division by zero).</returns>
    public static double? Modulo(SymbolsOfAdvancedMathematical operationType, Func<double, double, double> operation)
    {
        try
        {
            double dividend = Utils.GetInput<double>("\n ➡️ Enter the dividend number: ");
            double divisor = Utils.GetInput<double>(" ➡️ Enter the divisor number: ");

            if (divisor == 0)
                throw new Exception("The divisor cannot be 0!");

            double result = operation(dividend, divisor);

            return ShowResult(result, dividend, divisor, operationType);
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ An error has occurred in advanced operation => {ex.Message}", ConsoleColor.Red);
            return null;
        }
    }

    /// <summary>
    /// Displays the result of an advanced mathematical operation in a formatted manner and returns the computed value.
    /// </summary>
    /// <remarks>The method writes a formatted message to the console, displaying the operation and its result
    /// using a symbol that corresponds to the specified <paramref name="operationType"/>. For factorial operations,
    /// only <paramref name="baseNum"/> and the result are shown; for other operations, both <paramref name="baseNum"/>
    /// and <paramref name="exponent"/> are included in the output.</remarks>
    /// <param name="result">The computed result of the mathematical operation to display.</param>
    /// <param name="baseNum">The base number used in the operation. For factorial, this represents the operand; for other operations, it is
    /// the base value.</param>
    /// <param name="exponent">The exponent or secondary operand used in the operation. This parameter is ignored for factorial operations.</param>
    /// <param name="operationType">The type of advanced mathematical operation performed. Determines the formatting and symbol used in the output.</param>
    /// <returns>The same value as <paramref name="result"/>, representing the outcome of the specified mathematical operation.</returns>
    public static double ShowResult(double result, double baseNum, double exponent, SymbolsOfAdvancedMathematical operationType)
    {
        string symbol = operationType switch
        {
            SymbolsOfAdvancedMathematical.Exponentiation => "^",
            SymbolsOfAdvancedMathematical.Root => "√",
            SymbolsOfAdvancedMathematical.Factorial => "!",
            SymbolsOfAdvancedMathematical.Modulo => "%",
            _ => "?"
        };

        if (operationType == SymbolsOfAdvancedMathematical.Factorial)
        {
            Utils.WriteColored($"\n ✅ {baseNum}{symbol} = {result}", ConsoleColor.Green);
            return result;
        }

        Utils.WriteColored($"\n ✅ {baseNum}{symbol}{exponent} = {result}", ConsoleColor.Green);
        return result;
    }

}

