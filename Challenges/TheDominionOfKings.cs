int estates = AskForNumber("Welcome. Please enter the number of estates you own.");
int duchies = AskForNumber($"You have {estates} estates. Please enter the number of duchies you own.");

var duchiesFeedback = duchies < 2 ? "Is that all? Oh well. " : "Nice; impressive. ";
Console.WriteLine(duchiesFeedback + "And lastly, please enter the number of provinces you own.");

int provinces = Convert.ToInt32(Console.ReadLine());

int totalScore = estates + (duchies * 3) + (provinces * 6);
Console.WriteLine("Your total score is " + totalScore);

int AskForNumber(string text)
{
    Console.WriteLine(text);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

//e 5 d 5 p 5 = 50
//e 7 d 11 p 16 = 136