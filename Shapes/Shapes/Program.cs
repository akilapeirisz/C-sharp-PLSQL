using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape1 = new Rectangle(new Point(5.5, 6.1), new Point(10.3, 0), new Color(20, 50, 30));
            Shape shape2 = new Rectangle(3, 10,13, 6, new Color(152, 75, 65));
            Shape shape3 = new Circle(new Point(3, 10), 7, new Color(48, 45, 65));
            Shape shape4 = new Circle(13, 6, 14, new Color(96, 150, 56));

            Shape[] shapes = { shape1, shape2, shape3, shape4 };

            DrawShapes(shapes);
            Console.ReadKey();
        }

        static void DrawShapes(Shape[] shapes)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }
        }
    }

    class Point
    {
        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        override public string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

    class Color
    {
        private int r;

        public int R
        {
            get { return r; }
            set {
                if (value >= 0 && value < 256)
                {
                    r = value;
                }
            }
        }

        private int g;

        public int G
        {
            get { return g; }
            set {
                if (value >= 0 && value < 256)
                {
                    g = value;
                }
            }
        }

        private int b;

        public int B
        {
            get { return b; }
            set {
                if (value >= 0 && value < 256)
                { 
                    b = value; 
                }
            }
        }

        public Color(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }

    abstract class Shape
    {
        private Color color;

        internal Color Color
        {
            get { return color; }
            set
            {
                if (value != null)
                {
                    color = value;
                }
                else
                {
                    Console.WriteLine("Color cannot be set to Null");
                }
            }
        }

        public Shape(Color color)
        {
            if (color != null)
            {
                this.color = color;
            }
            else
            {
                Console.WriteLine("Color cannot be set to Null");
            }
        }

        abstract public void Draw();
        abstract public double Area();
    }

    class Rectangle : Shape
    {
        private Point top_left;
        private Point bottom_right;

        public Rectangle(Point top_left, Point bottom_right, Color color)
            : base(color)
        {
            this.top_left = top_left;
            this.bottom_right = bottom_right;
        }

        public Rectangle(int x1, int y1, int x2, int y2, Color color)
            : base(color)
        {
            this.top_left = new Point(x1, y1);
            this.bottom_right = new Point(x2, y2);
        }

        public override void Draw()
        {
            Console.WriteLine("A rectangle is being drawn.");
            Console.WriteLine(ToString());
        }

        public override double Area()
        {
            double width = top_left.X - bottom_right.X;
            double height = top_left.Y - bottom_right.Y;
            double area = width * height;
            return Math.Abs(area);
        }

        public override string ToString()
        {
            string rect = "Top left point : " + top_left.X + ", " + top_left.Y;
            rect += "\nBottom right point : " + bottom_right.X + ", " + bottom_right.Y;
            rect += "\nColor (r, g, b) : (" + base.Color.R + ", " + base.Color.G + ", " + base.Color.B + ")";
            rect += "\nArea : " + Area();

            return rect;
        }
    }

    class Circle : Shape
    {
        private Point centroid;
        private int radius;
        private const double PI = 3.14159;

        public Circle(Point centroid, int radius, Color color)
            : base(color)
        {
            this.centroid = centroid;
            this.radius = radius;
        }

        public Circle(int x, int y, int radius, Color color)
            : base(color)
        {
            this.centroid = new Point(x, y);
            this.radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine("A circle is being drawn.");
            Console.WriteLine(ToString());
        }

        public override double Area()
        {
            double area = PI * Math.Pow(radius,2);
            return area;
        }

        public override string ToString()
        {
            string rect = "Centroid : " + centroid.X + ", " + centroid.Y;
            rect += "\nRadius : " + radius;
            rect += "\nColor (r, g, b) : (" + base.Color.R + ", " + base.Color.G + ", " + base.Color.B + ")";
            rect += "\nArea : " + Area();

            return rect;
        }
    }
}
