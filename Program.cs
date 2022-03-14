//define variable of type ChestState
ChestState currentChestState = ChestState.Locked;

//INFINITE LOOP START

Console.WriteLine($"The chest is {currentChestState}. What do you want to do?");

string userInput = Console.ReadLine();

if (CheckActionAllowed(currentChestState, userInput))
{
    currentChestState = SetChestState(currentChestState, userInput);
    Console.WriteLine($"Now chest state is {currentChestState}");
}
else
    //loop again
    Console.WriteLine("Not allowed");


ChestState SetChestState(ChestState currentChestState, string input)
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

//INFINITE LOOP END

//define enum for chest state
enum ChestState { Open, Closed, Locked }