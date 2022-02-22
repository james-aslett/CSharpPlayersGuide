string name1 = Console.ReadLine();
string name2 = Console.ReadLine();
string name3 = Console.ReadLine();
//this code reserves 20 characters for the name's display. If length < 20 then it adds whitespace before it to achieve the desired width
Console.WriteLine($"#1: {name1,20}");
Console.WriteLine($"#2: {name2,20}");
//if you want whitespace after the word, use a negative number:
Console.WriteLine($"#3: {name3,-20} - 2");