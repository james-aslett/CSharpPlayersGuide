Console.WriteLine("Welcome to Tortuga's Emporium. Please enter your name.");
string userName = Console.ReadLine();
Console.WriteLine("The following items are available:");

int i = 0;

do
{
    i++;
    Console.WriteLine($"{i} - {GetItem(i)}");
}
while (i < 7);


Console.WriteLine("What item do you want to see the price of?");
int choice = Convert.ToInt32(Console.ReadLine());

string item = GetItem(choice);

int price = item switch
{
    "Rope" => 10,
    "Torches " => 15,
    "Climbing Equipment" => 25,
    "Clean Water" or "Food Supplies" => 1,
    "Machete" => 20,
    "Canoe" => 200,
    _ => 0
};

if (userName == "James") price /= 2;

Console.WriteLine($"{GetItem(choice)} {CostPluraliser(item)} {price} gold");

static string GetItem(int choice)
{
    string item = choice switch
    {
        1 => "Rope",
        2 => "Torches",
        3 => "Climbing Equipment",
        4 => "Clean Water",
        5 => "Machete",
        6 => "Canoe",
        7 => "Food Supplies",
        _ => "Unknown"
    };
    return item;
}

static string CostPluraliser(string item)
{
    if (item == "Torches" | item == "Food Supplies") return "cost";
    else return "costs";
}