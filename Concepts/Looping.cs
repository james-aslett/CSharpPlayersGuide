//while loop - if condition is false initially then will never run
int x = 1;

while (x <= 5)
{
    Console.WriteLine(x);
    x++;
}

//an example using while (true)
while (true)
{ 
    Console.WriteLine("Think of a number");
    string input = Console.ReadLine();

    if (input == "quit")
        break; //will jump out of loop to 'Nice number' line

    int number = Convert.ToInt32(input);

    if (number == 12)
    {
        Console.WriteLine("I don't like that number. Choose another.");
        continue; //will jump to start of loop again
    }
    Console.WriteLine("Nice number.");
}

//do/while loop - evaluates condition at END of loop, so will always run at least once
int playersNumber;

do
{
    Console.WriteLine("Enter a number between 0 and 10: ");
    string playerResponse = Console.ReadLine();
    playersNumber = Convert.ToInt32(playerResponse);
}
while (playersNumber < 0 || playersNumber > 10);

//for loop
for (int y =1; y <= 5; y++)
    Console.WriteLine(y);




