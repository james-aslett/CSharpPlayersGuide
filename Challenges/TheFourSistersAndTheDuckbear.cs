Console.WriteLine("Enter number of chocolate eggs.");
int eggs = Convert.ToInt32(Console.ReadLine());
int eggsEach = eggs / 4;
int remainder = eggs % 4;
Console.WriteLine("Each sisters gets " + eggsEach + ". The remainder to feed to the duckbear is " + remainder);

//input 1 - 0 each - 1 duckbear
//input 2 - 0 each - 2 duckbear
//input 3 - 0 each - 3 duckbear