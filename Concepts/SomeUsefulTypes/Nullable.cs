//THE NULLABLE STRUCT
//The Nullable<T> struct lets you pretend that a value type can take on a null value. It does this by attaching a bool HasValue property to the original value. This property indicates whether the value should be considered legitimate. One way to work with Nullable<T> is like so:
Nullable<int> maybeNumber = new Nullable<int>(3);
Nullable<int> another = new Nullable<int>();

//The first creates a Nullable<int> where the value is considered legitimate and whose value is 3, while the second is a Nullable<int> where the value is missing.

//Nullable<T> does not create true null references. It must use value types and is a value type itself. The bytes are still allocated (plus an extra byte for the Boolean HasValue property). It is just that the current content isn't considered valid.

//For any nullable struct, you can use its HasValue and Value properties to check if the value is legitimate or is to be considered missing, and if it is legitimate, to retrieve the actual value:
if (maybeNumber.HasValue)
    Console.WriteLine($"The number is {maybeNumber.Value}");
else
    Console.WriteLine("The missing is missing.");

//But C# provides syntax to make working with Nullable<T> easy. You can use int? instead of Nullable<int>. You can also automatically convert from the underlying type to the nullable type (for example, to convert a plain int to a Nullable<int> and even convert from the literal null. Thus, most C# programmers will use the following instead: