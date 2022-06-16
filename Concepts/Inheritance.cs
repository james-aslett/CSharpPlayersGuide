//The object class is the base class of everything, and everything is a specialization of the object class.

//create instance of the object class and use object as a type for a variable:
object thing = new object();

//the object class doesn't have many responsibilities, so creating instances of it is rare.
//it has several methods, including ToString and Equals:
Console.WriteLine(thing.ToString()); //by default, ToString will display the full name of the object's type