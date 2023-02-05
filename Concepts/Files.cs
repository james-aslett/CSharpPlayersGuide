//Files

//File-related types all live in the System.IO namespace
//File lets you read and write files: string[] lines = file.ReadAllLines("file.txt"); File.WriteAllText("file.txt", "content");
//File does manipulation (create, delete, move, files); Directory does the same with directories
//Path helps you combine parts of a file path or extract interesting elements out of it. The File class is a vital part of any file I/O
//You can also use streams to read and write files a little at a time
//Many file formats have a library you can reuse, so you do not have to do a lot of parsing yourself