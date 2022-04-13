//PROGRAM
//What is the initial passcode? 1234
//The door is Closed. What do you want to do? (open, close, lock, unlock, change code) lock
//The door is Locked.What do you want to do? (open, close, lock, unlock, change code) unlock
//What is the passcode? - if matches then 'The door is Closed...', if not match then 'The door is Locked...'
//The door is Closed. What do you want to do? (open, close, lock, unlock, change code) change code
//What is the current passcode? 1234 (if matches then next time you unlock it'll change to Closed, if doesn't match then next time you unlock it'll stay on Locked)

int initialPasscode = GetInt("What is the initial passcode?");
Door door = new(initialPasscode);

while (true)
{
    Console.Write($"The door is {door.State.ToString().ToLower()}. What do you want to do? (open, close, lock, unlock, change code) ");
    string? command = Console.ReadLine();

}

int GetInt(string text)
{
    Console.Write(text + " ");
    return Convert.ToInt32(Console.ReadLine());
} 

public class Door
{
    public int _passcode;
    public DoorState _doorstate;

    public Door(int passcode)
    {
        _passcode = passcode;
    }
    public DoorState ManipulateDoor(string input)
    {
        if (input == "close" || input == "unlock") _doorstate = DoorState.Closed;
        else if (input == "lock") _doorstate = DoorState.Locked;
        else _doorstate = DoorState.Open;
    }
}


public enum DoorState { Open, Closed, Locked }