//SOME USEFUL TYPES

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

//THE DATETIME STRUCT
//Stores moments in time and allows you to get the current time. One way to create a DateTime value is with its constructors:
DateTime time1 = new DateTime(2022, 12, 31);
DateTime time2 = new DateTime(2022, 12, 31, 23, 59, 55);

//This creates a time at the start of 31 Dec 2022 and at 11:59:55 on 31 Dec 2022. There are a total of 12 constructors for Datetime.

//Perhaps even more useful are the static DateTime.Now and DateTime.UtcNow properties:
DateTime nowLocal = DateTime.Now;
DateTime nowUtc = DateTime.UtcNow;

//DateTime.Now is in your local time zone, as determined by your computer. DateTime.UtcNow gives you the current time in Coordinated Universal Time or UTC, which is essentially a wordwide time, not specific to time zones, daylight saving time, etc.

//A DateTime value has various properties to see the year, month, day, hour, minute, second and millisecond, among other things. The following illustrates some simple uses:
DateTime time = DateTime.Now;
if (time.Month == 10) Console.WriteLine("Happy Halloween!");
else if (time.Month == 4 && time.Day == 1) Console.WriteLine("April Fools!");

//There are also methods for getting new DateTime values relative to another. For example:
DateTime tomoroww = DateTime.Now.AddDays(1);

//The DateTime struct is very smart, handling many easy-to-forget edge cases, such as leap years and day-of-the-week calculations. When dealing with dates and times, this is your go-to struct to represent and get the current date and time.

//THE TIMESPAN STRUCT
//Represents a span of time. You can create values of the TimeSpan in one of two wats. Several constructors let you dictate the length of time:
TimeSpan timeSpan1 = new TimeSpan(1, 30, 0); //1 hour, 30 minutes, 0 seconds
TimeSpan timeSpan2 = new TimeSpan(2, 12, 0, 0); //2 days, 12 hours
TimeSpan timeSpan3 = new TimeSpan(0, 0, 0, 0, 500); //500 milliseconds
TimeSpan timeSpan4 = new TimeSpan(10); //10 'ticks' == 1 microsecond

//After reading the comments, most of these are straightforward, but the last one is notable. Internally, a TimeSpan keeps track of time in a unit called a tick, which is 0.1 microseconds or 100 nanoseconds. This is as fine-grained as a TimeSpan can get, but you rarely need more.

//The other way to create TimeSpans is with one of the various FromX methods:
TimeSpan aLittleWhile = TimeSpan.FromSeconds(3.5);
TimeSpan quiteAWhile = TimeSpan.FromHours(1.21);

//The whole collection includes FromTicks, FromMilliseconds, FromSeconds, FromHours, and FromDays.

//TimeSpan has two sets of properties worth mentioning. First is this set: Days, Hours, Minutes, Seconds, Milliseconds. These represent the various components of the TimeSpan, for example:
TimeSpan timeLeft = new TimeSpan(1, 30, 0);
Console.WriteLine($"{timeLeft.Days}d {timeLeft.Hours}h {timeLeft.Minutes}m");

//timeLeft.Minutes does not return 90, since 60 of those come from a full hour, represented by the Hours property.

//Another set of properties capture the entire timespan in the unit requested: TotalDays, TotalHours, TotalMinutes, TotalSeconds, TotalMilliseconds.
TimeSpan timeRemaining = new TimeSpan(1, 30, 0);
Console.WriteLine(timeRemaining.TotalHours);
Console.WriteLine(timeRemaining.TotalMilliseconds);

//This will display 1.5 | 90

//Both DateTime and TimeSpan have defined several operators (Level 41) for things like comparison (>, <, >=, <=), addition, and subtraction. Plus, the two structs play nice together:
DateTime eventTime = new DateTime(2022, 12, 4, 5, 29, 0); // 4 Dec 2022 at 5:29am
TimeSpan timeLeft2 = eventTime - DateTime.Now;
// 'TimeSpan.Zero' is no time at all
if (timeLeft2 > TimeSpan.Zero) Console.WriteLine($"{timeLeft2.Days}d {timeLeft2.Hours}h {timeLeft2.Minutes}m");
else Console.WriteLine("This event has passed");

//The second line shows that substracting one DateTime from another results in a TimeSpan that is the amount of time between the two. The if statement shows a comparison against the special TimeSpan.Zero value.