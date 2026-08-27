/*
Objectives:
- Define a new Point class with properties for X and Y.
- Add a constructor to create a point from a spesific x- and y-coordinate.
- Add a parameterless constructor to create a point at the origin (0,0).
- In your main method, create a point at (2,3) and another at (-4,0). 
- Display these points on the console window in the format (x,y) to illustrate that the class works.

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