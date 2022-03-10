Season current = Season.Summer;

if (current == Season.Summer || current == Season.Winter)
    Console.WriteLine("Happy, solstice!");
else
    Console.WriteLine("Happy equinox!");

//enums MUST go after any other code, or in a separate file

//the first item is the default
enum Season { Winter, Spring, Summer, Fall }