//In your main program, create a basic Sword instance made out of iron and with no gemstone:
Sword original = new Sword(Material.Iron, 5, 0.25f, Gemstone.None);
//Then create two variations using with expressions:
Sword fancy = original with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };
Sword ultraLong = original with { Material = Material.Bronze, Length = 8, Gemstone = Gemstone.Bitstone };

//Display all three sword instances with code like Console.WriteLine(original):
Console.WriteLine(original);
Console.WriteLine(fancy);
Console.WriteLine(ultraLong);

//Swords can be made out of the following: wood, bronze, iron, steel, binarium. Create an enumeration to represent material type:
public enum Material { Wood, Bronze, Iron, Steel, Binarium }
//Gemstones can be attached to a sword. Types: emerald, amber, sapphire, diamond, bitstone, none. Create an emumeration to represent a gemstone type:
public enum Gemstone { Emerald, Amber, Sapphire, Diamond, Bitstone, None }
//Create a Sword record with a material, gemstone, length, and crossguard width:
public record Sword(Material Material, float Length, float CrossguardWidth, Gemstone Gemstone);