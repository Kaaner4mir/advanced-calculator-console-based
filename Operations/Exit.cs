class Exit
{
    public static void ExitOperation()
    {
		try
		{
			Console.Clear();
			string inputVal = Utils.GetInput<string>(" 👉 Are you sure you want to exit (Y/N): ");

			if (inputVal.ToUpper() == "Y")
				Environment.Exit(0);
			else if (inputVal.ToUpper() == "N")
				return;
			else
				Utils.WriteColored("\n ❓ You have made an invalid transaction!", ConsoleColor.Red);
		}
		catch (Exception ex)
		{
            Utils.WriteColored($"\n ⛔ An error has occurred in advanced operation => {ex.Message}", ConsoleColor.Red);
		}
    }
}