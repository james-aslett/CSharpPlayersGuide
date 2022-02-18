Console.WriteLine("Hello. Please enter the width of the triangle.");
string widthText = Console.ReadLine();
float width = Convert.ToSingle(widthText);

Console.WriteLine("The width is " + width + ". Now enter the height.");
string heightText = Console.ReadLine();
float height = Convert.ToSingle(heightText);

float area = (width * height) / 2;
Console.WriteLine("Great! The area of a triangle with a base size of " + width + " and a height of " + height + " is " + area);