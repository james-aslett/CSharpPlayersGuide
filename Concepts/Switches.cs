
//switch statement - has can use same path for multiple arms, use break to signal that flow of execution should end
int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
        Console.WriteLine("One");
        break;
    //mutiple cases for same arm
    case 2:
    case 3:
        Console.WriteLine("Two or three");
        break;
    default:
        Console.WriteLine("I do not know that one");
        break;
}


//switch expression - each arm must have its own path. Use _ instead of default
string response;

response = choice switch
{
    1 => "One",
    2 => "Two",
    3 => "Three",
    _ => "I do not know that one"
};