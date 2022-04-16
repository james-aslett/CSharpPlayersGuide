//STEPS:
//Define a PasswordValidator class that can be given a password and validate it
//Make Main method loop forever, asking for a password and reporting whether the password is allowed using an instance of the PasswordValidator class

while (true)
{
    Console.WriteLine("Please enter a password between 6-13 characters. Must not contain 'T' or '&' and must contain one upper character, lower character and number");
    PasswordValidator pw = new PasswordValidator(Console.ReadLine());
    if (pw.IsPasswordValid == false)
    {
        Console.WriteLine("Sorry, that password is invalid. Try again.");
    }
    else
    {
        Console.WriteLine("Lovely job, that password is accepted!");
    }
}

public class PasswordValidator
{
    private string _password;
    public bool IsPasswordValid = false;

    public PasswordValidator(string password)
    {
        _password = password;
        ValidatePassword(password);
    }

    public string? GetString(string input)
    {
        Console.WriteLine($"{input} ");
        return Console.ReadLine();
    }

    public bool ValidatePassword(string password)
    {
        int allowedChars = 0;

        if (password.Length < 6 | password.Length > 13)
        {
            return IsPasswordValid;
        }

        foreach (char c in password)
        {
            if (char.IsUpper(c) = 'T' | char.IsSymbol(c) = '&')
            {
                return IsPasswordValid;
            }
            else if (char.IsUpper(c) | char.IsLower(c) | char.IsDigit(c))
            {
                allowedChars++;
            }
        }

        if (allowedChars == 3)
        {
            return IsPasswordValid = true;
        }
        else
        {
            return IsPasswordValid;
        }
    }
}
