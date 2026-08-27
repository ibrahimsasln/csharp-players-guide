using System;
using Microsoft.VisualBasic;

namespace TheColor
{
    class Program
    {
        static void Main(string[] args)
        {
            Color color1 = new Color();
            Console.WriteLine($"({color1.R}, {color1.G}, {color1.B})");

            Color color2 = Color.Blue;
            Console.WriteLine($"({color2.R}, {color2.G}, {color2.B})");

            Color color3 = new Color(2, 200, 20);
            Console.WriteLine($"({color3.R}, {color3.G}, {color3.B})");
        }
    }
    
    public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color() //default: White(255, 255, 255)
        {
            R = 255;
            G = 255;
            B = 255;
        }
    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color White  { get; } = new Color(255,  255,  255);
    public static Color Black  { get; } = new Color(  0,    0,    0);
    public static Color Red    { get; } = new Color(255,    0,    0);
    public static Color Orange { get; } = new Color(255,  165,    0);
    public static Color Yellow { get; } = new Color(255,  255,    0);
    public static Color Green  { get; } = new Color(  0,  128,    0);
    public static Color Blue   { get; } = new Color(  0,    0,  255);
    public static Color Purple { get; } = new Color(128,    0,  128);
}
}