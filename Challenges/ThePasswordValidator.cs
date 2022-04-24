//STEPS:
//Define a PasswordValidator class that can be given a password and validate it
//Make Main method loop forever, asking for a password and reporting whether the password is allowed using an instance of the PasswordValidator class

PasswordValidator validator = new PasswordValidator();

while (true)
{
    Console.Write("Please enter a password between 6-13 characters. Must not contain 'T' or '&' and must contain one upper character, lower character and number. ");
    string? password = Console.ReadLine();

    if (password == null) break; // If the user enters a null password (Ctrl+Z) then let's be done.
                                 // An alternative could be to make 'IsValid' handle null or to fall
                                 // back to some default string like the empty string ("") instead.
                                 // This challenge doesn't specifically call out dealing with null,
                                 // and it isn't easy to get a null in there in the first place. If
                                 // you ignored this possibility, that's fine too.

    if (validator.IsValid(password))
    {
        Console.WriteLine("Lovely job, that password is accepted! ");
    }
    else
    {
        Console.WriteLine("Sorry, that password is invalid. Try again. ");
    }
}

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        if (password.Length < 6) return false;
        if (password.Length > 13) return false;
        if (!ContainsUpper(password)) return false;
        if (!ContainsLower(password)) return false;
        if (!ContainsDigit(password)) return false;
        if (Contains(password, 'T')) return false;
        if (Contains(password, '&')) return false;

        return true;

    }

    private static bool ContainsUpper(string password)
    {
        foreach (char letter in password)
        {
            if (char.IsUpper(letter))
            {
                return true;
            }
        }
        return false;
    }

    private static bool ContainsLower(string password)
    {
        foreach (char letter in password)
        {
            if (char.IsLower(letter))
            {
                return true;
            }
        }
        return false;
    }

    private static bool ContainsDigit(string password)
    {
        foreach (char letter in password)
        {
            if (char.IsDigit(letter))
            {
                return true;
            }
        }
        return false;
    }

    private static bool Contains(string password, char input)
    {
        foreach (char letter in password)
        {
            if (letter == input)
            {
                return true;
            }
        }
        return false;
    }
}
