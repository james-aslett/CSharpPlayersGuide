//THE IENUMERABLE<T> INTERFACE
//While List<T> might be the most versatile generic type, IEnumerable<T> might be the most foundational. This simple interface essentially defines what counts as a collection in .NET.

//IEnumerable<T> defines a mechanism that allows you to inspect items one at a time. This mechanism is the basis for a foreach loop. If a type implements IEnumberable<T>, you can use it in a foreach loop.

//IEnumberable<T> is anything that can provide an 'enumerator', and the definition looks something like this:
public interface IEnumberable<T>
{
    IEnumerator<T> GetEnumerator();
}

//But what's an enumerator? It is a thing that lets you look at items in a set, one at a time, with the ability to start over. It is defined roughly like this:
public interface IEnumerator<T>
{
    T Current { get; }
    bool MoveNext();
    void Reset();
}

//The Current property lets you see the current item. The MoveNext method advances to the next item and returns whether there even is another item. Reset starts over from the beginning. Almost nobody uses an IEnumerator<T> directly. They let the foreach loop deal with it. Consider this code:
List<string> fruits = new List<string> { "apple", "banana", "corn", "durian" };

foreach (string fruit in fruits)
    Console.WriteLine(fruit);

//That is equivalent to:
List<string> fruits2 = new List<string> { "apple", "banana", "corn", "durian" };
IEnumerator<string> iterator = fruits2.GetEnumerator();

while (iterator.MoveNext())
{
    string fruit = iterator.Current;
    Console.WriteLine(fruit);
}

//List<T> and arrays both implement IEnumberable<T>, but dozens of other collection types also implement this interface. It is the basis for all collection types. You will see IEnumberable<T> everywhere.
