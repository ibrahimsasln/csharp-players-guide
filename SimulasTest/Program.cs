ChestState currentState = ChestState.Locked;
bool exit = false;

while (!exit)
{
    Console.Write($"The chest is {currentState}. What do you want to do? (0 for exit) ");
    string? newState = Console.ReadLine(); // string? -> if newState is null
    if (newState == null) continue;
    if (currentState == ChestState.Locked && newState == "unlock") currentState = ChestState.Closed;
    if (currentState == ChestState.Closed && newState == "open") currentState = ChestState.Open;
    if (currentState == ChestState.Open && newState == "close") currentState = ChestState.Closed;
    if (currentState == ChestState.Closed && newState == "lock") currentState = ChestState.Locked;
    if(newState == "0") exit = true;
}
enum ChestState
{
    Open,
    Closed,
    Locked
}

