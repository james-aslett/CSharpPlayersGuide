//THE GUID STRUCT
//Represents a globally unique identifier or GUID. You may find value in giving objects or items a unique identifier to track them independently from other similar objects in certain programs. This is especially true if you send information across a network, where you can't just use a simple reference. While you could use an int or long as unique numbers for these objects, it can be tough to ensure that each item has a truly unique number. This is especially true if different computers have to create the unique number. This is where the Guid struct comes in handy.

//The idea is that if you have enough possible choices, two people picking at random won't pick the same thing. If all of humanity had a beach party and each of us went and picked a grain of sand on the beach, the chance that any of us would pick the same gran is vanishingly small. The generation of new identifiers with the Guid struct is similar.

//To generate a new arbitrary identifier, you use the static Guid.NewGuid() method:
Guid id = Guid.NewGuid();

//Each Guid value is 16 bytes (4 times as many as an int), ensuring plenty of available choices. But NewGuid() is smarter than just picking a random number. It has smarts built in that ensure that other computers won't pick the same value and that multiple calls to NewGuid() won't even give you the same number again, maximising the chance of uniqueness.

//A Guid is just a collection of 16 bytes, but is is usually written in hexadecimal with dashes breaking it into smaller chunks like this: 10A24E2-3008-4678-AD86-FCCCDA8CE868. Once you know about GUIDs, you will see them pop up all over the place.

//If you already have a GUID and do not want to generate a new one, there are other constructors that you can use to build a new Guid value that represents it. For example:
Guid id2 = new Guid("10A24E2-3008-4678-AD86-FCCCDA8CE868");

//Just be careful about inadvertently reusing a GUID in situations that could cause conflicts. Copying and pasting GUIDs can lead to accidental reuse. Visual Studio has a tool to generate a random GUID under Tools > Create GUID, and you can find similar things online.