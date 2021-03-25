using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            double allArea = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.Write("第" + (i + 1) + "个图形：");
                shape sp = ShapeFactory.generateRandomShape(i);
                allArea += sp.getArea();
                Console.WriteLine("this area=" + sp.getArea());
                Console.WriteLine("allArea=" + allArea);
            }
            Console.WriteLine("十个图形总面积（含不合法图形）为：" + allArea);
        }
    }
}

    public interface shape
    {
        public abstract double getArea();
        public abstract bool isValid();
    }
    class rectangle : shape
    {
        private double width
        {
            set; get;
        }
        private double length
        {
            set;
            get;
        }
        public double area
        {
            get { return getArea(); }
        }

        public rectangle(double l, double w)
        {
            this.length = l;
            this.width = w;
        }
        public double getArea()
        {
            if (!isValid())
            {
                Console.WriteLine("形状不合法");
            }
            return length * width;
        }
        public bool isValid()
        {
            return length > 0 && width > 0;
        }
    }

    class square : shape
    {
        double side { set; get; }
        public double area
        {
            get { return getArea(); }
        }
        public square(double s)
        {
            this.side = side;
        }
        public double getArea()
        {
            if (!isValid())
            {
                Console.WriteLine("形状不合法");
            }
            return side * side;
        }
        public bool isValid()
        {
            return side > 0;
        }
    }
    class triangle : shape
    {
        double a;
        double b;
        double c;
        public triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public double area
        {
            get { return getArea(); }
        }
        public double getArea()
        {
            if (!isValid())
            {
                Console.WriteLine("形状不合法");
            }
            double p = 0.5 * (a + b + c);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public bool isValid()
        {
            return a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a;
        }
    }
    
    class ShapeFactory
    {
        public static shape generateRandomShape(int seed)
        {
            Random rd = new Random(seed);
            int key = rd.Next(0, 3);
            shape shape = null;
            Console.Write(key);
            switch (key)
            {
                case 0:
                    shape = new square(rd.NextDouble() + rd.Next(0, 10));
                    Console.WriteLine("正方形"); break;
                case 1:
                    shape = new triangle(rd.NextDouble() + rd.Next(2, 5), rd.NextDouble() + rd.Next(2, 5), rd.NextDouble() + rd.Next(2, 5));
                    Console.WriteLine("三角形"); break;
                case 2:
                    shape = new rectangle(rd.NextDouble() + rd.Next(0, 10), rd.NextDouble() + rd.Next(0, 10));
                    Console.WriteLine("矩形"); break;
            }
            return shape;
        }
    }




