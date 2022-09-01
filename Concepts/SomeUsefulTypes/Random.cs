//RANDOM
//Generates random numbers. These start with an initial value called a seed. If you reuse the same seed you will get the same random-looking sequence again. Minecraft generates a world based on a seed. Sometimes you want a specific random world, and by telling Minecraft to use a specific seed, you can get the same world again. But most of the time, you want a random seed to get a unique world.

//The System.Random class is the starting point for anything involving randomness. It is a simple class that is easy to learn how to use:
Random random = new Random();
Console.WriteLine(random.Next());

//The Random() constructor is initialized with an arbiturary seed value, which means you will not see the same sequence come up ever again with another Random object or by rerunning the program.

//Random's most basic method is the Next() method. Next picks a random non-negative int with equal chances of each. You are just as likely to get 7 as 1,844,349,103. Such a large range is rarely useful, so a couple of overloads of Next give you more control. Next(int) lets you pick the ceiling:
Console.WriteLine(random.Next(6));

//random.Next(6) will give you 0, 1, 2, 3, 4, or 5 (but not 6) as possible choices, with equal chances of each. It is common to add 1 to this result so that the range is 1 through 6 instead of 0 through 5. For example:
Console.WriteLine($"Rolling a six-sided die: {random.Next(6) + 1}");

//The third overload of Next allows you to name the minimum value as well:
Console.WriteLine(random.Next(18, 22));

//This will randomly pick from the values 18, 19, 20, and 21 (but not 22). If you want floating-point values instead of integers, you can use NextDouble():
Console.WriteLine(random.NextDouble());

//This will give you a double in the range of 0.0 to 1.0 (strictly speaking, 1.0 won't ever come up, but 0.9999999 can). You can stretch this out over a larger range with some simple arithmetic. The following will produce random numbers in the range 0 to 10:
Console.WriteLine(random.NextDouble() * 10);

//And this will produce random numbers in the range -10 to +10:
Console.WriteLine(random.NextDouble() * 20 - 10);

//The Random class also has a constructor that lets you pass in a specific seed:
Random random2 = new Random(3445);
Console.WriteLine(random2.Next());

//This code will always display the same output because the seed is always 3445, which lets you recreate a random sequence of numbers.