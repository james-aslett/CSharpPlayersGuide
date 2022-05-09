int initialPasscode = GetInt("What is the initial passcode?");
Door door = new Door(initialPasscode);

while (true)
{
    Console.Write($"The door is {door.State.ToString().ToLower()}. What do you want to do? (open, close, lock, unlock, change code) ");
    string? command = Console.ReadLine(); //? means a nullable type
    bool success;
    switch (command.ToLower())
    {
        case "open":
            success = door.Open();
            if (success) Console.WriteLine("That worked!");
            else Console.WriteLine("That didn't do anything.");
            break;
        case "close":
            success = door.Close();
            if (success) Console.WriteLine("That worked!");
            else Console.WriteLine("That didn't do anything.");
            break;
        case "lock":
            success = door.Lock();
            if (success) Console.WriteLine("That worked!");
            else Console.WriteLine("That didn't do anything.");
            break;
        case "unlock":
            int guess = GetInt("What is the passcode?");
            success = door.Unlock(guess);
            if (success) Console.WriteLine("That worked!");
            else Console.WriteLine("The password entered was incorrect.");
            break;
        case "change code":
            int currentCode = GetInt("What is the current passcode?");
            int newCode = GetInt("What do you want to change it to?");
            success = door.ChangeCode(currentCode, newCode);
            if (success) Console.WriteLine("That worked! You changed the passcode!");
            else Console.WriteLine("Your current passcode didn't match. Try again.");
            break;
        default:
            Console.WriteLine("Unrecognised command.");
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
    public bool Close()
    {
        if (State == DoorState.Open)
        {
            State = DoorState.Closed;
            return true;
        }
        return false;
    }

    public bool Open()
    {
        if (State == DoorState.Closed)
        {
            State = DoorState.Open;
            return true;
        }
        return false;
    }

    public bool Lock()
    {
        if (State == DoorState.Closed)
        {
            State = DoorState.Locked;
            return true;
        }
        return false;
    }

    public bool Unlock(int passcode)
    {
        if (State == DoorState.Locked && passcode == _passcode)
        {
            State = DoorState.Closed;
            return true;
        }
        return false;
    }

    public bool ChangeCode(int oldPasscode, int newPasscode)
    {
        if (oldPasscode == _passcode)
        {
            _passcode = newPasscode;
            return true;
        }
        return false;
    }
}

public enum DoorState { Open, Closed, Locked }
