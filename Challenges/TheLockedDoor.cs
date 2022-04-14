//PROGRAM
//What is the initial passcode? 1234
//The door is Closed. What do you want to do? (open, close, lock, unlock, change code) lock
//The door is Locked.What do you want to do? (open, close, lock, unlock, change code) unlock
//What is the passcode? - if matches then 'The door is Closed...', if not match then 'The door is Locked...'
//The door is Closed. What do you want to do? (open, close, lock, unlock, change code) change code
//What is the current passcode? 1234 (if matches then next time you unlock it'll change to Closed, if doesn't match then next time you unlock it'll stay on Locked)

int initialPasscode = GetInt("What is the initial passcode?");
Door door = new Door(initialPasscode);

while (true)
{
    Console.Write($"The door is {door.State.ToString().ToLower()}. What do you want to do? (open, close, lock, unlock, change code) ");
    string? command = Console.ReadLine(); //? means a nullable type

    switch (command)
    {
        case "open":
            door.Open();
            break;
        case "close":
            door.Close();
            break;
        case "lock":
            door.Lock();
            break;
        case "unlock":
            int guess = GetInt("What is the passcode?");
            door.Unlock(guess);
            break;
        case "change code":
            int currentCode = GetInt("What is the current passcode?");
            int newCode = GetInt("What do you want to change it to?");
            door.ChangeCode(currentCode, newCode);
            break;
    }
}

int GetInt(string text)
{
    Console.Write(text + " ");
    return Convert.ToInt32(Console.ReadLine());
}

public class Door
{
    private int _passcode;
    public DoorState State { get; private set; }

    public Door(int initialPasscode)
    {
        _passcode = initialPasscode;
        State = DoorState.Closed;
    }
    public void Close()
    {
        if (State == DoorState.Open) State = DoorState.Closed;
    }

    public void Open()
    {
        if (State == DoorState.Closed) State = DoorState.Open;
    }

    public void Lock()
    {
        if (State == DoorState.Closed) State = DoorState.Locked;
    }

    public void Unlock(int passcode)
    {
        if (State == DoorState.Locked && passcode == _passcode) State = DoorState.Closed;
    }

    public void ChangeCode(int oldPasscode, int newPasscode)
    {
        if (oldPasscode == _passcode) _passcode = newPasscode;
    }
}

public enum DoorState { Open, Closed, Locked }