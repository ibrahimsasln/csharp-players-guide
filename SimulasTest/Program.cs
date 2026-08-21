ChestState currentState = ChestState.Locked;
bool exit = false;

while (!exit)
{
    Console.Write($"The chest is {currentState}. What do you want to do? (0 for exit) ");
    string? newState = Console.ReadLine(); // string? -> if newState is null
    if (newState == null) continue;
    if(newState == "0") exit = true;
    currentState = (currentState, newState) switch
    {
        (ChestState.Locked, "unlock") => ChestState.Closed,
        (ChestState.Closed, "open") => ChestState.Open,
        (ChestState.Closed, "lock") => ChestState.Locked,
        (ChestState.Open, "close") => ChestState.Closed,
        _ => currentState
    };
}
enum ChestState
{
    Open,
    Closed,
    Locked
}

