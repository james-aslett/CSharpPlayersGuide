//Create a Sheep class in the IField namespace (fully qualified name of IField.Sheep)
//Create a Pig class in the IField namespace (fully qualified name of IField.Pig)
//Create a Cow class in the McDroid namespace (fully qualified name of McDroid.Cow)
//Create a Pig class in the McDroid namespace (fully qualified name of McDroid.Pig)
//For your main method, add using directives for both IField and McDroid namespaces. Make new instances of all four classes. There are no conflicts with sheep and cow, so make sure you can create new instances of thoese with new Sheep() and new Cow(). Resolve the conflicting Pig classes with either an alias or fully qualified names

using IField;
using McDroid;

Sheep Sheep = new Sheep();
Cow Cow = new Cow();
IField.Pig IPig = new IField.Pig();
McDroid.Pig McPig = new McDroid.Pig();

namespace IField
{
    public class Sheep { }

    public class Pig { }
}

namespace McDroid
{
    public class Cow { }

    public class Pig { }
}
