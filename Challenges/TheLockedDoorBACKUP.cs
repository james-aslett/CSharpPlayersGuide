//DOOR RULES:
//1: An open door can be closed
//2: A closed (but not locked) door can be opened
//3: A closed door can be locked
//4: A locked door can be unlocked, but numeric password is needed and will only unlock if the code provided matches the door's current passcode
//5: When a door is created, it must be given an initial passcode
//6: You should be able to change the passcode by supplying the current code and a new one. It should only change if the correct current code is given

//OBJECTIVES

DoorState currentDoorState = DoorState.Locked;
//Make your Main method ask the user for a starting passcode, then create a new Door instance
Console.WriteLine("Please create a four digit passcode");
int userPasscode = Convert.ToInt32(Console.ReadLine());
Door door = new(userPasscode);
Console.WriteLine("Please enter your current password");
int userPasscode2 = Convert.ToInt32(Console.ReadLine());
door.ChangePasscode(userPasscode2);

//Allow the user to attempt the four transitions (open, close, lock, unlock)
Console.WriteLine($"The door is currently {currentDoorState.ToString().ToLower()}. What do you want to do?");
string userDoorChange = Console.ReadLine();
//and change the code by typing in text commands

//Define a Door class that can keep track of whether it is locked, open or closed
public class Door
{
    public int CurrentPasscode { get; set; }


    //Build a constructor that requires the starting numeric passcode
    public Door(int passcode)
    {
        CurrentPasscode = passcode;
    }

    //Build a method that will allow you to change the passcode for an existing door by supplying the current passcode and a new passcode. Only change the passcode if
    //the current one is correct

    public bool ChangePasscode(int userInputCurrentPasscode)
    {
        if (userInputCurrentPasscode == CurrentPasscode)
        {
            Console.WriteLine("Correct. Please choose a new password");
            CurrentPasscode = Convert.ToInt32(Console.ReadLine());
            return true;
        }
        else
        {
            Console.WriteLine("That password didn't match.");
            return false;
        }
    }

    DoorState SetDoorState(string input)
    {
        if (input == "close" || input == "unlock") return DoorState.Closed;
        else if (input == "lock") return DoorState.Locked;
        else return DoorState.Open;
    }

    bool CheckActionAllowed(DoorState state, string input)
    {
        if (input == "close" && state == DoorState.Open
            || input == "lock" && state == DoorState.Closed
            || input == "open" && state == DoorState.Closed)
            return true;
        else if (input == "unlock" && state == DoorState.Locked)
            //call checkPassword - if okay then return true
            return true;
        else return false;
    }

}
//Create methods to perform the four transitions defined above

enum DoorState { Open, Closed, Locked }
