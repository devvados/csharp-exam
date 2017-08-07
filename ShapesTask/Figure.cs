using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesTask
{
    abstract class Figure
    {
        public abstract double Square();
    }

    class Rectangle : Figure
    {
        double _length, _width;

        public double Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public Rectangle()
        {
            Random rand = new Random();
            Length = rand.Next(3, 10);
            Width = rand.Next(5, 15);
        }

        public override double Square()
        {
            return Length * Width;
        }
    }

    class Triangle : Figure
    {
        Random rand;
        double _a, _b, _c;

        public double A
        {
            get
            {
                return _a;
            }

            set
            {
                _a = value;
            }
        }

        public double B
        {
            get
            {
                return _b;
            }

            set
            {
                _b = value;
            }
        }

        public double C
        {
            get
            {
                return _c;
            }

            set
            {
                _c = value;
            }
        }

        public Triangle()
        {
            rand = new Random();
            do
            {
                RandomizeDimensions(rand);
            }
            while (!CheckTriangle());
        }

        public void RandomizeDimensions(Random r)
        {
            A = r.Next(3, 10);
            B = r.Next(3, 10);
            C = r.Next(3, 10);
        }

        public bool CheckTriangle()
        {
            bool exists = false;
            if ((A + B > C) && (A + C > B) && (B + C > A))
                exists = true;
            return exists;
        }

        public double FindPerimeter()
        {
            return (A + B + C) / 2;
        }

        public override double Square()
        {
            double p = this.FindPerimeter();

            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
