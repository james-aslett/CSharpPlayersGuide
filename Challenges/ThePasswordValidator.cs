PasswordValidator validator = new PasswordValidator();

while (true)
{
    Console.Write("Please enter a password between 6-13 characters. Must not contain 'T' or '&' and must contain one upper character, lower character and number. ");
    string? password = Console.ReadLine();
    if (string.IsNullOrEmpty(password)) break; // If the user enters a null/empty password (Ctrl+Z) then end program
    ValidationResult result = validator.IsValid(password);
    if (result == ValidationResult.Success) Console.WriteLine("Great! Password accepted!");
    else if (result == ValidationResult.TooShort) Console.WriteLine("Password is too short. Must be at least 6 characters.");
    else if (result == ValidationResult.TooLong) Console.WriteLine("Password is too long. Must be 13 characters maximum.");
    else if (result == ValidationResult.NeedsUpperCase) Console.WriteLine("Password must contain an upper case letter.");
    else if (result == ValidationResult.NeedsLowerCase) Console.WriteLine("Password must contain a lower case letter.");
    else if (result == ValidationResult.NeedsNumber) Console.WriteLine("Password must contain a number.");
    else if (result == ValidationResult.ContainsUpperCaseT) Console.WriteLine("Password cannot contain 'T'.");
    else if (result == ValidationResult.ContainsAmpersand) Console.WriteLine("Password cannot contain '&'.");
}

public class PasswordValidator
{
    public ValidationResult IsValid(string password)
    {
        if (password.Length < 6) return ValidationResult.TooShort;
        if (password.Length > 13) return ValidationResult.TooLong;

        int uppercaseCount = 0;
        int lowercaseCount = 0;
        int numberCount = 0;
        int capitalTCount = 0;
        int ampersandCount = 0;

        foreach (char letter in password)
        {
            if (char.IsUpper(letter)) uppercaseCount++;
            if (char.IsLower(letter)) lowercaseCount++;
            if (char.IsDigit(letter)) numberCount++;
            if (letter == 'T') capitalTCount++;
            if (letter == '&') ampersandCount++;
        }

        if (uppercaseCount == 0) return ValidationResult.NeedsUpperCase;
        if (lowercaseCount == 0) return ValidationResult.NeedsLowerCase;
        if (numberCount == 0) return ValidationResult.NeedsNumber;
        if (capitalTCount > 0) return ValidationResult.ContainsUpperCaseT;
        if (ampersandCount > 0) return ValidationResult.ContainsAmpersand;

        return ValidationResult.Success;
    }
}

public enum ValidationResult { Success, TooShort, TooLong, NeedsUpperCase, NeedsLowerCase, NeedsNumber, ContainsUpperCaseT, ContainsAmpersand }
