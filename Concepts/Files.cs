﻿//Files

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

public record Score(string Name, int Points, int Level);

//And this method for creating an initial list of scores:

//List<Score> MakeDefaultScores()
//{
//    return new List<Score>()
//  {
//      new Score("R2-D2", 12420, 15);
//    new Score("C-3P0", 8543, 9);
//    new Score("GONK", -1, 1);
//};
//}

//After calling this method to get our scores, how would we write all this data to a file? WriteAllText needs a string, and we have a List<Score> containing many scores.

//We need a way to transform a complex object or a complex set of objects into something that can be placed into a file. This transformation is call serialization. The reverse is called deserialization. If we can serialize our scores into a string, we already know the rest.

//There is no shortage of ways to serialize these scores. Here is a simply way: the CSV format. CSV, short for "comma-separated values", is a simple format that puts each item on its own line. Commas separate the item's properties. In a CSV file, our scores might look like this:
//RD-D2, 12420, 15
//C-3P0, 8543, 9
//GONK, -1, 1

//File has a WriteAllLines method that may simplify our work. It requires a collection of string instead of just one. It we can turn each score into a string, we can use WriteAllLines to get them into a file:
//void SaveScores(List<Score> scores)
//{
//    List<string> scoreStrings = new List<string>();

//    foreach (Score score in scores)
//        scoreStrings.Add($"{score.name},{score.Points},{score.Level}");

//    File.WriteAllLines("Scores.csv", scoreStrings);
//}

//The line inside the foreach loop combines the name, score and level into a single string, separated by commas. We do that for each score and end up with one string per score.

//File.WriteAllLines can take it from there, so we hand it the file name and string collection, and the job is done.

//Deserializing the file back to a list of scores is harder. There is a File.ReadAllLines method that is a good starting point. It returns a string[] where each string was one line in the file.
//string[] scoreStrings = File.ReadAllLines("Scores.csv");

//We need to take each string and chop it up to reconstitute a Score object. Since we separated data elements with commas, we can use string's Split method to chop up the lines into its parts:
//string[] scoreString = "R2-D2, 12420, 15";
//string[] tokens = scoreString.Split(",");

//Split(",") gives us an array of string where the first item is "R2-D2", the second is "12420" and the third is "15". If we used a ; or | to separate values, we could have passed in a different argument to the Split method. Note that the delimiter - the character that marks the separation point between the elements - is not kept when you use Split in the way shown above, but there are overloads of Split that allow that to happen.

//My variable is called tokens because that is a common word for a chopped-up string's most fundamental elements.

//With those elements, we can create this method to load all the scores in the file:
//List<Score> LoadHighScores()
//{
//    string[] scoreStrings = File.ReadAllLines("Scores.csv");

//    List<Score> scores = new List<Score>();

//    foreach (string scoreString in scoreStrings)
//    {
//        string[] tokens = scoreString.Split(",");
//        Score score = new Score(tokens[0]),
//            Convert.ToInt32(tokens[1]),
//            Convert.ToInt32(tokens[2]);

//        scores.Add(score);
//    }

//    return scores;
//}

//I should mention that the code above works most of the time but could be more robust. For example, imagine that a user enters their name as "Bond, James". String can contain commas, but in our CSV file, the resulting line is "Bond, James, 2000, 16". Our deserialization code will end up with four tokens and try to use "Bond" as the name and "James" as the score, which fails. We could forbid commas in player names or automatically turn commas into something else. We could also reduce the likelihood of a problem by picking a more obscure delimiter, such as [some weird character I can't type!]. Few keyboards can easily type that, but it is not impossible. (The offical CSV format lets you put double-quote marks around strings that contain commas. This addresses the issue, but parsing that is trickier).

//Other String Parsing Methods
//File.ReadAllLines and string.Split are enough for the above problem, but there are other string methods that you might find helpful in similar situations. The Trim, TrimStart and TrimEnd methods allows you to slice off unnecessary characters at the beginning and end of strings. The string " Hello" has an undesirable space character before it. " Hello".Trim() will produce a string without the space. It removes all whitespace from the beginning and end of the word. TrimStart and TrimEnd only trim the named side. If you want to remove another character, you can use "$Hello".Trim('$'). Remember that these produce new strings with the requested modification. They do not change the original string. Strings are immutable.

//The Replace method lets you find a bit of text within another and replace it with something else. For example, if we want to turn all commas in a name to the - character, we could do this: name = name.Replace(",", "-");. "Bond, James" becomes "Bond- James", which our parsing code can safely handle. 

//The Join method combines multiple items separated by some special string or character. We could have used this when converting Score objects to strings: string.Join("|", score.Name, score.Points, score.Level);. This method uses the params keyword for its second argument.

//File System Manipulation
//Aside from reading and writing files, the File, Path, and Directory class has a handful of other methods for doing file system manipulation. Let's look at those:

//File has methods for copying files, moving files, and deleting files. They are all pretty self-explanatory:
//File.Copy("Scores.csv", "Scores-Backup.csv");
//File.Move("Scores.csv", "Backup/Scores.csv");
//File.Delete("Scores.csv");

//The Directory Classs
//What file does for files, Directory does for directories. (The words directory and folder are synonyms). For example, these methods move, create, and delete a directory:
//Directory.Move("Settings", "BackupSettings");
//Directory.CreateDirectory("Settings");
//File.Delete("Scores.csv");

//Delete requires that the directory be empty before deleting it. Otherwise, it results in an exception (System.IO.IOException). You could write code to remove every file in a directory yourself, but there is also an overload that allows you to force the deletion of everything inside it:
//Directory.Delete("Settings2, true); //Careful!

//This can be extremely dangerous. You can delete entire file systems instantly with a poorly written Directory.Delete. Use it with extreme caution!

//Directory also has several methods for exploring the contents of a directory. The names of these methods depend on whether you want results in a string[] (names start with Get) or an IEnumerable<string> (names start with Enumerate). The names also depend on whether you want files (names end with Files), subdirectories (names end with Directories), or both (names end with FileSystemEntries). Two examples are shown below:
//foreach (string directory in Directory.GetDirectories("Settings"))
//    Console.WriteLine(directory);
//foreach (string file in Directory.EnumerateFiles("Settings"))
//    Console.WriteLine(file);

//Some overloads allow you to supply a filter, enabling things like finding all files with an extension of .txt.

//The Path Class
//The static Path class has methods for working with file system paths, including combining paths, grabbing just the file name or extension from a file, and converting between absolute and relative paths. The code below illustrates all of these:
//Console.WriteLine(Path.Combine("C:/Users/RB/Desktop/", "Settings", "v2.2"));
//Console.WriteLine(Path.GetFileName("C:/Users/RB/Desktop/GrumpyCat.gif"));
//Console.WriteLine(Path.GetFileNameWithoutExtension("C:/Users/RB/Desktop/GrumpyCat.gif"));

//Console.WriteLine(Path.GetExtension("C:/Users/RB/Desktop/GrumpyCat.gif"));
//Console.WriteLine(Path.GetFullPath("ConsoleApp1.exe"));
//Console.WriteLine(Path.GetRelativePath(".", "C:/Users/RB/Desktop"));

//When I run these on my computer, I get the following output:

//C:\Users\RB\Desktop\Settings/v2.2
//GrumpyCat.gif
//GrumpyCat
//.gif
//C:\Users\RB\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net6.0\ConsoleApp1.exe\..\..\..\..\..\..\..\Desktop