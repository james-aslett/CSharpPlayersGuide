//sets console background and text colour
Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
//sets console title
Console.Title = "Hello, World!";
//clear all text from console. If you don't use this, the background colour won't be applied to entire screen
Console.Clear();
//same as WriteLine but doesn't jump to next line.
Console.Write("Press any key and the key input will display");
//same as ReadLine but only reads a single key press. If you use it like this then the key input will display in console:
Console.ReadKey();
//...but you can pass true in as parameter to prevent this:
Console.Write("Press any key and the key input will not display");
Console.ReadKey(true);

//audible beep (first argument = frequency, second = duration)
//plays Happy Birthday
Thread.Sleep(2000);
Console.Beep(264, 125);
Thread.Sleep(250);
Console.Beep(264, 125);
Thread.Sleep(125);
Console.Beep(297, 500);
Thread.Sleep(125);
Console.Beep(264, 500);
Thread.Sleep(125);
Console.Beep(352, 500);
Thread.Sleep(125);
Console.Beep(330, 1000);
Thread.Sleep(250);
Console.Beep(264, 125);
Thread.Sleep(250);
Console.Beep(264, 125);
Thread.Sleep(125);
Console.Beep(297, 500);
Thread.Sleep(125);
Console.Beep(264, 500);
Thread.Sleep(125);
Console.Beep(396, 500);
Thread.Sleep(125);
Console.Beep(352, 1000);
Thread.Sleep(250);
Console.Beep(264, 125);
Thread.Sleep(250);
Console.Beep(264, 125);
Thread.Sleep(125);
Console.Beep(2642, 500);
Thread.Sleep(125);
Console.Beep(440, 500);
Thread.Sleep(125);
Console.Beep(352, 250);
Thread.Sleep(125);
Console.Beep(352, 125);
Thread.Sleep(125);
Console.Beep(330, 500);
Thread.Sleep(125);
Console.Beep(297, 1000);
Thread.Sleep(250);
Console.Beep(466, 125);
Thread.Sleep(250);
Console.Beep(466, 125);
Thread.Sleep(125);
Console.Beep(440, 500);
Thread.Sleep(125);
Console.Beep(352, 500);
Thread.Sleep(125);
Console.Beep(396, 500);
Thread.Sleep(125);
Console.Beep(352, 1000);