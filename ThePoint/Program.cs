/*
Question: Are your X and Y  properties immutable? Why did you choose what you did?

My Answer: I initially added a private set to the properties but once i
realized there was no place in the class that actually needed to modify 
them after construction then i removed it and went with immutable properties 
instead.
 */

using System;

namespace ThePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(2, 3);
            Point p2 = new Point(-4, 0);
            Point p3 = new Point();
            
            Console.WriteLine($"({p1.PositionX},{p1.PositionY})");
            Console.WriteLine($"({p2.PositionX},{p2.PositionY})");
            Console.WriteLine($"({p3.PositionX},{p3.PositionY})");
        }
    }

    class Point
    {
        public float PositionX { get; }
        public float PositionY { get;  }

        public Point(float positionX, float positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public Point()
        {
            PositionX = 0;
            PositionY = 0;
        }
    }
}