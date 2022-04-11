Color babyPink = new(255, 204, 229);
Color specificColor = Color.White;
Console.WriteLine($"My babyPink color has the following values: R {babyPink.R} | G {babyPink.G} | B {babyPink.B}");
Console.WriteLine($"My specific color has the following values: R {specificColor.R} | G {specificColor.G} | B {specificColor.B}");

public class Color
{
    //properties for R/G/B
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    //Constructor to create a color
    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    //properties for custom color, of type Color (new Color(int, int, int))
    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Green { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);
}



