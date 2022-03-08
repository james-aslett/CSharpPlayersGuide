int manticoreHP = 10;
int cityHP = 15;
int roundNumber = 1;

int manticoreLocation;
int canonRange;

do
{
    Console.WriteLine("Player 1, how far away from the city to you want to station the Manticore? Enter a number between 1-100");
    manticoreLocation = Convert.ToInt32(Console.ReadLine());
}
while (manticoreLocation <1 | manticoreLocation >100);

Console.Clear();

Console.WriteLine("Player 2, it is your turn.");

for (int i = 0; i < manticoreLocation; i++)
{
    Console.WriteLine($"STATUS: Round {roundNumber} | City's health {cityHP} | Manticore's health {manticoreHP}");
    Console.WriteLine($"The canon is expected to deal {CalculateCanonDamage(roundNumber)} damage this round");

    do
    {
        Console.WriteLine("Enter the desired canon range, between 1-100");
        canonRange = Convert.ToInt32(Console.ReadLine());
    }
    while (canonRange < 1 | canonRange > 100);

    Console.WriteLine(TargetAttemptResponse(canonRange, manticoreLocation));

    //if DIRECT HIT then reduce Manticore HP by 1, else reduce city by 1
    if (canonRange == manticoreLocation) manticoreHP -= 1;
    else cityHP -= 1;


    //advance to next round

    //loop until manticore / city's health reaches 0 - end game and dislay outcome

}

int CalculateCanonDamage(int roundNumber)
{
    if (roundNumber % 3 == 0 && roundNumber % 5 == 0) return 10;
    else if (roundNumber % 3 == 0 ^ roundNumber % 5 == 0) return 3;
    else return 1;
}

string TargetAttemptResponse(int canonRange, int manticoreLocation)
{
    if (canonRange > manticoreLocation) return "That round OVERSHOT the target";
    else if (canonRange < manticoreLocation) return "That found FELL SHORT of the target";
    else return "That round was a DIRECT HIT!";
}


//NOTES:
//use different colours for different types of message
//this could take some time, don't worry!
//use methods to focus on solving one problem at a time

