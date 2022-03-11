//make a variable whose type is new ChestState enum
ChestState currentChestState = ChestState.Locked;

//infinite loop
Console.WriteLine($"The chest is {ChestState.Locked}. What do you want to do?");
string userResponse = Console.ReadLine();
SetChestState(currentChestState, userResponse); //set the chest state based on user response
//then check state against allowed rules



//method to manipulate chest 
void ManipulateChest(ChestState currentChestState)
{
    //pass currentChestState in (which was set from user input in SetChestState

    //if currentChestC
}











//set chest state from user response
void SetChestState(ChestState currentChestState, string response)
{
    if (response == "close" || response == "unlock") currentChestState = ChestState.Closed;
    else if (response == "lock") currentChestState = ChestState.Locked;
    else currentChestState = ChestState.Open;
}

//define enumeration for state of chest
enum ChestState { Open, Closed, Locked }

