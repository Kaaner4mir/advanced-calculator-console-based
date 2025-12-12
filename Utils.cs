class Utils
{
    /// <summary>
    /// Prompts the user for input, displays the specified message in the given console color, and converts the entered
    /// value to the specified type.
    /// </summary>
    /// <remarks>The method repeatedly prompts the user until a valid, non-empty value is entered and
    /// successfully converted to the specified type.  If <typeparamref name="T"/> is an enumeration type, the input is
    /// parsed as an enum value. For other types, the input is converted using <see cref="Convert.ChangeType(object,
    /// Type)"/>.  If the input is invalid or cannot be converted, an error message is displayed and the user is
    /// prompted again.</remarks>
    /// <typeparam name="T">The type to which the user input will be converted. This can be any type supported by <see
    /// cref="Convert.ChangeType(object, Type)"/> or an enumeration type.</typeparam>
    /// <param name="message">The message to display to the user as a prompt for input.</param>
    /// <param name="color">The <see cref="ConsoleColor"/> to use when displaying the prompt message. The default is <see
    /// cref="ConsoleColor.White"/>.</param>
    /// <returns>The value entered by the user, converted to type <typeparamref name="T"/>.</returns>
    public static T GetInput<T>(string message, ConsoleColor color = ConsoleColor.White)
    {
        while (true)
        {
            WriteColored(message, color, false);
            string? text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                WriteColored("\n ⚠️ Input cannot be empty!", ConsoleColor.Red);
                continue;
            }

            try
            {
                if (typeof(T).IsEnum)
                {
                    if (Enum.TryParse(typeof(T), text, out object? result))
                    {
                        return (T)result;
                    }
                    else
                    {
                        WriteColored($"\n ⚠️ Please enter a valid {typeof(T).Name} value!", ConsoleColor.Red);
                        continue;
                    }
                }
                else
                {
                    return (T)Convert.ChangeType(text, typeof(T));
                }
            }
            catch (FormatException)
            {
                WriteColored($"\n ⚠️ Please enter a valid {typeof(T).Name} value!", ConsoleColor.Red);
            }
            catch (OverflowException)
            {
                WriteColored($"\n ⚠️ The entered value is too large or too small for {typeof(T).Name}!", ConsoleColor.Red);
            }
            catch (Exception exc)
            {
                WriteColored($"\n ⚠️ An unexpected error occurred: {exc.Message}", ConsoleColor.Red);
            }
        }
    }

    /// <summary>
    /// Writes the specified text to the console in the given foreground color.
    /// </summary>
    /// <param name="text">The text to display in the console. If <see langword="null"/>, no output is written.</param>
    /// <param name="color">The foreground color to use when displaying the text. The default is <see cref="ConsoleColor.White"/>.</param>
    /// <param name="newLine"><see langword="true"/> to append a line terminator after the text; <see langword="false"/> to write the text
    /// without a line terminator. The default is <see langword="true"/>.</param>
    public static void WriteColored(string text, ConsoleColor color = ConsoleColor.White, bool newLine = true)
    {
        Console.ForegroundColor = color;
        if (newLine) Console.WriteLine(text);
        else Console.Write(text);
        Console.ResetColor();
    }

    /// <summary>
    /// Displays a waiting message in the specified color and pauses execution until a key is pressed.
    /// </summary>
    /// <param name="color">The color to use for the waiting message. The default is <see cref="ConsoleColor.DarkYellow"/>.</param>
    public static void WaitingScreen(ConsoleColor color = ConsoleColor.DarkYellow)
    {
        Console.CursorVisible = false;
        WriteColored("\n ⏳ Press any key to continue ...", color);
        Console.ReadKey(intercept: true);
        Console.CursorVisible = true;
    }

}