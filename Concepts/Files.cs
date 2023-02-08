//Files

//File-related types all live in the System.IO namespace
//File lets you read and write files: string[] lines = file.ReadAllLines("file.txt"); File.WriteAllText("file.txt", "content");
//File does manipulation (create, delete, move, files); Directory does the same with directories
//Path helps you combine parts of a file path or extract interesting elements out of it. The File class is a vital part of any file I/O
//You can also use streams to read and write files a little at a time
//Many file formats have a library you can reuse, so you do not have to do a lot of parsing yourself

//Many programs benefit from saving information in a file and later retrieving it. For example, you might want to save settings for a program into a configuration file. Or maybe you want to save high scores to a file so that the player's previous scores remain when you close and reopen the game.

//The Base Class Library contains several classes that make this easy. We will look at how to read and write data to a file in this level.

//All of the classes we discuss in this level live in the System.IO namespace. This namespace is automatically included in modern C# projects, but if you're using older code, you will need to use fully qualified names or add a using System.IO; directive.

//The File Class
//The File class is the key class for workinh with files. It allows us to get information about a file and read and write its contents. To illustrate how the File class works, let's look at a small Message in a Bottle program, which asks the user for a message to display the next time the program runs. That message is placed in a file. When the program starts, it shows the messsage from before; if it can find one.

//We can start by getting the text from the user. This uses only things familiar to us:

//Console.Write("What do you want me to tell you next time? ");
//string? message = Console.ReadLine();

//The File class is static and thus contains only static methods. WriteAllText will take a string and write it to a file. You supply the path to the destination file, as well as the text itself:

//File.WriteAllText("Message.txt", message);

//This alone creates a functioning program, even though it does not do everything we set out to do. If we run it, our program asks for text, makes a file called Message.txt, and places the user's text into it.

//Where exactly does that file get created? WriteAllText - and every method in the File class that asks for a path - can work with both absolute and relative paths. An absolute path describes the whole directory structure from the root to the file. For example, I could do this to write a file on my desktop:
//File.WriteAllText("C:/Users/RB/Desktop/Message.txt", message);

//A relative path leaves off most of the path and lets you describe the part beyond the current working directory. (You can also use ".." in a path to go up a directory from the current one in a relative path.) When your C# program runs in Visual Studio, the current working directory is in the same location as your compiled code. For example, it might be under your project folder under \bin\Debug\net6.0\ or something similar.

//If you hunt down this file, you can open it up in Notepad or another program and see that it created the file and added your text to it.

//We wanted to open this file and display the last message, so let's do that with the following:

//string previous = File.ReadAllText("Message.txt");
//Console.WriteLine("Last time, you said this: " + previous);

//Console.Write("What do you want me to tell you next time? ");
//string? message = Console.ReadLine();
//File.WriteAllText("Message.txt", message);

//ReadAllText opens the named file and reads the text it contains, returning a string. The code above then displays that in the console window.

//There is one problem with the code above. If we run it this way and the Message.txt file does not exist, it will crash. We can check to see if a file exists before trying to open it:

//if (File.Exists("Message.txt"))
//{
//    string previous = File.ReadAllText("Message.txt");
//    Console.WriteLine("Last time, you said this: " + previous);
//}

//That creates a more robust program that works even if the file does not exist yet.

//String manipulation
//ReadAllText and WriteAllText are simple but powerful. You can save almost any data to a file and pull it out later with those two methods alone. You just need a way to turn what you want into a string and then parse the string to get your data back.

//Let's look at a more complex problem: saving a collection of scores. Suppose we have this record:

//public record Score(string Name, int Points, int Level);

//And this method for creating an initial list of scores:

//List<Score> MakeDefaultScores()
//{
//  return new List<Score>()
//  {
//      new Score("R2-D2", 12420, 15);
//      new Score("C-3P0", 8543, 9);
//      new Score("GONK", -1, 1);
//  };
//}

//After calling this method to get our scores, how would we write all this data to a file? WriteAllText needs a string, and we have a List<Score> containing many scores.

//We need a way to transform a complex object or a complex set of objects into something that can be placed into a file. This transformation is call serialization. The reverse is called deserialization. If we can serialize our scores into a string, we already know the rest.

//There is no shortage of ways to serialize these scores. Here is a simply way: the CSV format. CSV, short for "comma-separated values", is a simple format that puts each item on its own line. Commas separate the item's properties. In a CSV file, our scores might look like this:
//RD-D2, 12420, 15
//C-3P0, 8543, 9
//GONK, -1, 1

