using CardClient.Services;
using CardCore.Base;
using CardCore.Interfaces;

IUserInteraction userInteraction = new ConsoleUserInteraction();

var _Game = new Game(userInteraction);
_Game.Start();

bool exitRequested = false;

while (!exitRequested)
{
    Console.WriteLine("Actions: Resolve Chain (r), Activate Arcanaut Astral Compass (a), Get current chain link (g), Exit (e)");
    string response = Console.ReadLine();

    if (response.Equals("r", StringComparison.OrdinalIgnoreCase))
    {
        _Game.Resolve();
    }
    else if (response.Equals("a", StringComparison.OrdinalIgnoreCase))
    {
        _Game.ActivateRunickCalling();
    }
    else if (response.Equals("g", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine(_Game.GetCurrentChainLink());
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