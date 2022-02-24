public static class Program
{
    public static void Main()
    {

        Console.WriteLine("Welcome to Tortuga's Emporium.");
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

        string response;

        response = choice switch
        {
            1 => "10",
            2 => "15",
            3 => "25",
            4 or 7 => "1",
            5 => "20",
            6 => "200",
            _ => "That item wasn't on the list."
        };
        string item = GetItem(choice);
        Console.WriteLine($"{GetItem(choice)} {CostPluraliser(item)} {response} gold");
    }
    public static string GetItem(int choice)
    {
        string item;
        item = choice switch
        {
            1 => "Rope",
            2 => "Torches",
            3 => "Climbing Equipment",
            4 => "Clean Water",
            5 => "Machete",
            6 => "Canoe",
            7 => "Food Supplies",
            _ => "That item wasn't on the list."
        };
        return item;
    }

    public static string CostPluraliser(string item)
    {
        if (item == "Torches" | item == "Food Supplies") return "cost";
        else return "costs";
    }
}