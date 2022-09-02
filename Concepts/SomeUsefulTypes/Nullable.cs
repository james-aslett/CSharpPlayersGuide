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
int? maybeNumber2 = 3;
int? another2 = null;

//Nullable<T> is a convenient way to represent values when the value may be missing. But remember, this is different from null references.

//Interestingly, operators on the underlying type work on the nullable counterparts:
maybeNumber2 += 2;

//Unfortunately, that only applies to operators, not methods or properties. If you want to invoke a method or property on a nullable value, you must call the Value property to get a copy of the value first.

//VALUETUPLE STRUCTS
//We have seen many examples where the C# language makes it easy to work with some common type. As we just saw, int? is the same as Nullable<int>, and even int itself is simply the Int32 struct. Tuples also have this treatment and are a shorthand way to use the ValueTuple generic structs. We saw how to do the following in Level 17:
(string, int, int) score = ("R2-D2", 12420, 15);

//That is a shorthand version of this:
ValueTuple<string, int, int> scoreLonghang = new ValueTuple<string, int, int>("R2-D2", 12420, 15);

//Most C# programmers prefer the first, simpler syntax, but sometimes the name ValueTuple leaks out, and it is worth knowing the two are the same thing when it does.
