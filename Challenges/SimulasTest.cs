ChestState currentChestState = ChestState.Locked;

while (true)
{
    Console.WriteLine($"The chest is {currentChestState.ToString().ToLower()}. What do you want to do?");
    string userInput = Console.ReadLine();

    if (CheckActionAllowed(currentChestState, userInput))
    {
        currentChestState = SetChestState(userInput);
        Console.WriteLine($"You {userInput} the chest.");
    }
    else Console.WriteLine("You cannot do this. Try again.");
    Console.WriteLine();
}

ChestState SetChestState(string input)
{
    if (input == "close" || input == "unlock") return ChestState.Closed;
    else if (input == "lock") return ChestState.Locked;
    else return ChestState.Open;
}

bool CheckActionAllowed(ChestState state, string input)
{
    if (input == "close" && state == ChestState.Open
        || input == "lock" && state == ChestState.Closed
        || input == "open" && state == ChestState.Closed
        || input == "unlock" && state == ChestState.Locked)
        return true;
    else return false;
}
enum ChestState { Open, Closed, Locked }