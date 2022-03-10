ChestState currentState = ChestState.Locked;




//infinite loop
Console.WriteLine($"The chest is {ChestState.Locked}. What do you want to do?");
string userResponse = Console.ReadLine();
SetChestState(userResponse);


void SetChestState(string response)
{
    if (response == "lock") currentState = ChestState.Locked;
    else if (response == "unlock") currentState = ChestState.Unlocked;
    else if (response == "open") currentState = ChestState.Open;
    else currentState = ChestState.Closed;
}















enum ChestState { Locked, Unlocked, Open, Closed }