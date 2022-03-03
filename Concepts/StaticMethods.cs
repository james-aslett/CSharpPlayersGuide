//In the below example, you can access the text string (the scope of which is the Main method) within the DisplayText method

string text = Console.ReadLine();

DisplayText();

void DisplayText()
{
    Console.WriteLine(text);
}

//but in this example, we've added static to the method. Static prevents you from using variables within the containing method. It can be used as a safety precaution

DisplayText2();

static void DisplayText2()
{
    Console.WriteLine(text);
}
