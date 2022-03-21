//declare array
int[] myIntArray = new int[10]; //will hold 10 int values

//assign a value to spot 4 in the array
myIntArray[4] = 99;

//print spot 6 to console
Console.WriteLine(myIntArray[4]);

//access array from end (starts at 1 from the back)
int lastValue = myIntArray[^1];

//use range operator to get a range
int[] firstThreeValues = myIntArray[0..3];

//write out all values of array
int[] scores = new int[10];

foreach (int score in scores)
    Console.WriteLine(score);


