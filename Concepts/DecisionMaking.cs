string input = Console.ReadLine();
int score = Convert.ToInt32(input);

//single statements do not require curly brackets - these are only required for block statements, however lots of devs use them everywhere for consistency
if (score == 100)
    Console.WriteLine("Perfect score!");

if (score == 10)
{
    Console.WriteLine("Rubbish!");
    Console.Beep();
}

//you don't always need to use relational operators within an if statement. So this code...
int playerScore = 45;
int pointsNeededToPass = 100;

bool levelComplete;

if (playerScore >= pointsNeededToPass)
    levelComplete = true;
else
    levelComplete = false;

if (levelComplete)
    Console.WriteLine("You've beaten the level!");

//can become this instead...
int playerScore2 = 45;
int pointsNeededToPass2 = 100;

bool levelComplete2 = playerScore2 >= pointsNeededToPass2;

if (levelComplete2)
    Console.WriteLine("You've beaten the level!");

//the useful thing here is that we've given a name to the score logic, which makes it easier to read what the code is doing