ChestState currentState = ChestState.Locked;

while (true)
{
    Console.Write($"The chest is {currentState}. What do you want to do? (open, close, lock or exit for 0) ");
    string? userAction = Console.ReadLine(); // string? -> if newState is null
    if (userAction == null) continue;
    if(userAction == "0") break;
    
    ChestState previousState = currentState;
    
    // switch expression with tuples to apply user action
    currentState = (currentState, userAction) switch
    {
        (ChestState.Locked, "unlock") => ChestState.Closed,
        (ChestState.Closed, "open") => ChestState.Open,
        (ChestState.Closed, "lock") => ChestState.Locked,
        (ChestState.Open, "close") => ChestState.Closed,
        _ => currentState
    };

    if(currentState == previousState) Console.WriteLine("Try different action");
}
enum ChestState
{
    Open,
    Closed,
    Locked
}

