using CardCore.Base;

Console.WriteLine("Hello, World!");

var _Game = new Game();
_Game.Start();

bool exitRequested = false;

while (!exitRequested)
{
    Console.WriteLine("Actions: resolve (r), activate runick calling (a), exit (e)");
    string response = Console.ReadLine();

    if (response.Equals("r", StringComparison.OrdinalIgnoreCase))
    {
        // Perform the action you want
        _Game.Resolve();
    }
    else if (response.Equals("a", StringComparison.OrdinalIgnoreCase))
    {
        _Game.ActivateRunickCalling();
    }
    else if (response.Equals("e", StringComparison.OrdinalIgnoreCase))
    {
        exitRequested = true;
    }
    else
    {
        Console.WriteLine("Invalid response. Please enter action letter.");
    }
}

Console.WriteLine("Exiting the program...");