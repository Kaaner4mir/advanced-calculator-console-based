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

                short inputVal = Utils.GetInput<short>("\n 👉 Please enter the operation you wish to perform numerically: ");

                switch (inputVal)
                {
                    case 1: Elementary.BasicOperation(SymbolsOfElementary.Addition, (val1, val2) => val1 + val2); break;
                    case 2: Elementary.BasicOperation(SymbolsOfElementary.Subtraction, (val1, val2) => val1 - val2); break;
                    case 3: Elementary.BasicOperation(SymbolsOfElementary.Multiplication, (val1, val2) => val1 * val2); break;
                    case 4: Elementary.BasicOperation(SymbolsOfElementary.Division, (val1, val2) => val1 / val2); break;
                    case 5: AdvancedMathematical.Exponentiation(SymbolsOfAdvancedMathematical.Exponentiation, (val1, val2) => Math.Pow(val1, val2)); break;
                    case 6: AdvancedMathematical.Root(SymbolsOfAdvancedMathematical.Root, (val1, val2) => Math.Pow(val2, 1.0 / val1)); break;
                    case 7: AdvancedMathematical.Factorial(SymbolsOfAdvancedMathematical.Factorial); break;
                    case 8: AdvancedMathematical.Modulo(SymbolsOfAdvancedMathematical.Modulo, (val1, val2) => val1 % val2); break;
                    case 9: Trigonometry.TrigonometricOperations(); break;
                    case 10: Logarithm.LogarithmOperations(); break;
                    case 11: Memory.MemoryOperations(); break;
                    case 12: Exit.ExitOperation(); break;
                    default: Utils.WriteColored("\n ❓ You have made an invalid transaction!"); break;
                }
                Utils.WaitingScreen();
            }
        }
        catch (Exception ex)
        {
            Utils.WriteColored($"\n ⛔ An error has occurred: {ex.Message}", ConsoleColor.Red);
        }

    }
}
