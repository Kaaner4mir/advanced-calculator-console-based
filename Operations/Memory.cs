using System.ComponentModel;
using System.Reflection;

/// <summary>
/// Specifies the set of standard messages that represent the outcome of common operations.
/// </summary>
/// <remarks>The <see cref="Message"/> enumeration defines values for indicating the result of actions such as
/// adding, subtracting, recalling, clearing, or storing data. These values can be used to communicate operation status
/// in user interfaces, logs, or APIs.</remarks>
public enum Message
{
    [Description("Successfully added")]
    add,

    [Description("Successfully subtracted")]
    subtract,

    [Description("Successfully recalled")]
    recall,

    [Description("Successfully cleared")]
    clear,

    [Description("Successfully stored")]
    store,
}

/// <summary>
/// Provides extension methods for working with enumeration (enum) values.
/// </summary>
/// <remarks>This class contains static methods that extend the functionality of enum types, enabling additional
/// operations such as retrieving custom descriptions.</remarks>
public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var type = value.GetType();
        var field = type.GetField(value.ToString());

        if (field == null)
            return value.ToString(); 

        var attribute = field.GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description ?? value.ToString();
    }
}

class Memory
{
    static double _memory = 0;

    /// <summary>
    /// Displays the memory operations menu and processes user input to perform memory-related actions.
    /// </summary>
    /// <remarks>This method presents a menu of available memory operations to the user, prompts for a
    /// selection, and executes the corresponding action.  Supported operations typically include adding to memory,
    /// subtracting from memory, recalling the stored value, clearing memory, and storing a new value.  If the user
    /// enters an invalid selection, an error message is displayed. Any exceptions encountered during execution are
    /// caught and reported to the user.</remarks>
    public static void MemoryOperations()
    {
        try
        {
            Console.Clear();
            Menu.MemoryMenu();

            short inputVal = Utils.GetInput<short>("\n 👉 Please enter the operation you wish to perform numerically: ");

            switch (inputVal)
            {
                case 1: MemoryAdd(); break;
                case 2: MemorySubtract(); break;
                case 3: MemoryRecall(); break;
                case 4: MemoryClear(); break;
                case 5: MemoryStore(); break;
                default:
                    Utils.WriteColored("\n ⛔ Invalid selection!", ConsoleColor.Red);
                    break;
            }
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ An error has occurred in advanced operation => {ex.Message}", ConsoleColor.Red);
        }
    }

    public static void MemoryAdd()
    {
        double number = Utils.GetInput<double>("\n ➡️ Enter the number you want to add to memory: ");
        _memory += number;

        ShowResult(Message.add);
    }

    public static void MemorySubtract()
    {
        double number = Utils.GetInput<double>("\n ➡️ Enter the number you want to subtract from memory: ");
        _memory -= number;

        ShowResult(Message.subtract);
    }

    public static void MemoryRecall()
    {
        ShowResult(Message.recall);
    }

    public static void MemoryClear()
    {
        _memory = 0;
        ShowResult(Message.clear);
    }

    public static void MemoryStore()
    {
        double number = Utils.GetInput<double>("\n ➡️ Enter the number you want to store in memory: ");
        _memory = number;

        ShowResult(Message.store);
    }

    /// <summary>
    /// Displays the result message with a description in green text in the console.
    /// </summary>
    /// <param name="message">The <see cref="Message"/> object containing the result information to display. Must not be <see
    /// langword="null"/>.</param>
    public static void ShowResult(Message message)
    {
        Utils.WriteColored($"\n ✅ {message.GetDescription()} <=> Memory = {_memory}", ConsoleColor.Green);
    }
}
