using System;
using Microsoft.VisualBasic;

namespace ProjeAdi
{
    class Program
    {
        static void Main(string[] args)
        {
            Color color = new Color("Red");
            Console.WriteLine($"({color.R}, {color.G}, {color.B})");
        }
    }
    
    class Color
    {
        public float R { get;}
        public float G { get;}
        public float B { get;}

        public Color() // default: Black(0, 0, 0)
        {
            R = 0;
            G = 0;
            B = 0;
        }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Color(string i)
        {
            switch (i)
            {
                case "Red":
                R = 255;
                break;

                case "Green":
                G = 255;
                break;

                case "Blue":
                B = 255;
                break;
            }

        }

    }
}