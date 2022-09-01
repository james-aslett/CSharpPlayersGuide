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