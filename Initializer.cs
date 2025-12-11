using System.Text;

class Initializer
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Console.Title = "🧮 Advaned Calculator";
        try
        {
            while (true)
            {
                Console.Clear();
                Menu.MainMenu();

                short inputVal = Utils.GetInput<short>("\n👉 Please enter the operation you wish to perform numerically: ");

                switch (inputVal)
                {
                    case 1: Elementary.BasicOperation(OperationType.Addition, (val1, val2) => val1 + val2); break;
                    case 2: Elementary.BasicOperation(OperationType.Subtraction, (val1, val2) => val1 - val2); break;
                    case 3: Elementary.BasicOperation(OperationType.Multiplication, (val1, val2) => val1 * val2); break;
                    case 4: Elementary.BasicOperation(OperationType.Division, (val1, val2) => val1 / val2); break;
                }
                Utils.WaitingScreen();
            }
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n⛔ An error has occurred: {ex.Message}", ConsoleColor.Red);
        }

    }
}
