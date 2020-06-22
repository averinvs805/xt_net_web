using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    #region Circle
    public class Circle : AbstractShape
    {
        private double outer_rad;
        public double OuterRadius
        {
            get => outer_rad;

            set
            {
                if (value > 0)
                {
                    outer_rad = value;
                }
            }
        }

        public double OuterCircumference { get; set; }

        public Circle(int x, int y, double outerRadius) : base(x, y)
        {
            this.outer_rad = outerRadius;
        }

        public virtual void FindOuterCircumference()
        {
            OuterCircumference = 2 * Math.PI * OuterRadius;
        }

        public override string ToString()
        {
            FindOuterCircumference();
            return "Окружность создана! \n" + "Радиус: " + OuterRadius + "\n" + "длина: " + OuterCircumference + "\n" +
                "Координаты начальной точки: " + X + " " + Y;
        }
    }
    #endregion

    #region Ring
    public class Ring : Circle
    {
        private double inner_rad;
        public double InnerRadius
        {
            get => inner_rad;

            set
            {
                if (value > 0)
                {
                    inner_rad = value;
                }
            }
        }

        public double InnerCircumference { get; set; }

        public double Area { get; set; }

        public Ring(int x, int y, double outerRadius, double inRadius) : base(x, y, outerRadius)
        {
            this.InnerRadius = inRadius;
        }

        public virtual void FindInnerCircumference()
        {
            InnerCircumference = 2 * Math.PI * InnerRadius;
        }

        public void FindArea()
        {
            Area = Math.PI * (Math.Pow(OuterRadius, 2) -Math.Pow(InnerRadius, 2));
        }

        public override string ToString()
        {
            FindInnerCircumference();
            FindArea();

            return "Кольцо создано! \n" + "Внешний радиус: " + OuterRadius + "\n" + "Внутренний радиус: " + InnerRadius + "\n" +
                        "Площадь: " + Area + "\n" + "Координаты точки начала: " + X + " " + Y;
        }
    }
    #endregion

    #region Round
    public class Disk : Circle
    {
        double disk_area;
        protected double InnerArea
        {
            get => disk_area;

            set
            {
                if (value > 0)
                {
                    disk_area = value;
                }
            }
        }

        public Disk(int x, int y, double outerRadius) : base(x, y, outerRadius)
        {
            OuterRadius = outerRadius;
        }

        public void FindArea()
        {
            disk_area = Math.PI * Math.Pow(OuterRadius, 2);
        }

        public override string ToString()
        {
            FindArea();

            return "Круг создан! \n" + "Радиус: " + OuterRadius + "\n" +
                        "Площадь: " + disk_area + "\n" + "Координаты точки начала: " + X + " " + Y;
        }
    }
    #endregion

    #region Rectangle
    public class Rectangle : AbstractShape
    {
        int Area { get; set; }
        int Perimeter { get; set; }

        private int sideA, sideB;

        public int HorizontalSide
        {
            get => sideA;

            set
            {
                if (value > 0)
                {
                    sideA = value;
                }
            }
        }

        public int VerticalSide
        {
            get => sideB;

            set
            {
                if (value > 0)
                    sideB = value;
            }
        }

        public Rectangle(int x, int y, int hor_side, int vert_side) : base(x, y)
        {
            HorizontalSide = hor_side;
            VerticalSide = vert_side;
        }

        public void FindArea()
        {
            Area = HorizontalSide * VerticalSide;
        }

        public void FindPerimeter()
        {
            Perimeter = (HorizontalSide + VerticalSide) * 2;
        }

        public override string ToString()
        {
            FindArea();
            FindPerimeter();
            return "Прямоугольник создан! \n" + "Площадь: " + Area + "\n" + "Периметр: " + Perimeter + "\n" +
                        "Координаты начальной точки: " + X + " " + Y;
        }
    }
    #endregion

    #region Square
    public class Square : AbstractShape
    {
        double side_square;
        public double Side
        {
            get => side_square;

            set
            {
                if (value > 0)
                {
                    side_square = value;
                }
            }
        }

        public double Perimeter { get; set; }

        public double Area { get; set; }

        public Square(int x, int y, double sideSquare) : base(x, y)
        {
            Side = sideSquare;
        }

        public void FindPerimeter()
        {
            Perimeter = Side * 4;
        }

        public void FindArea()
        {
            Area = Math.Pow(Side, 2);
        }

        public override string ToString()
        {
            FindArea();
            FindPerimeter();

            return "Квадрат создан! \n" + "Площадь: " + Area + "\n" + "Периметр: " + Perimeter + "\n" +
                        "Координаты точки начала: " + X + " " + Y;
        }
    }
    #endregion

    #region Triangle
    public class Triangle : AbstractShape
    {
        int area { get; set; }
        int perimeter { get; set; }

        private int side_A, side_B, side_C;
        public int SideA
        {
            get => side_A;

            set
            {
                if (value > 0)
                {
                    side_A = value;
                }
            }
        }

        public int SideB
        {
            get => side_B;

            set
            {
                if (value > 0)
                {
                    side_B = value;
                }
            }
        }

        public int SideC
        {
            get => side_C;

            set
            {
                if (value > 0)
                {
                    side_C = value;
                }
            }
        }

        public Triangle(int x, int y, int sideA, int sideB, int sideC) : base(x, y)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public void FindArea()
        {
            area = (int)Math.Sqrt(perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - SideC));
        }

        public void FindPerimeter()
        {
            perimeter = SideA + SideB + SideC;
        }

        public override string ToString()
        {
            FindPerimeter();
            FindArea();
            return "Треугольник создан! \n" + "Площадь: " + area + "\n" + "Периметр: " + perimeter + "\n" +
                        "Координаты точки начала: " + X + " " + Y;
        }
    }
    #endregion

    #region Line
    public class Line : AbstractShape
    {
        int length;
        public int Length
        {
            get => length;

            set
            {
                if (value > 0)
                {
                    length = value;
                }
            }
        }

        public Line(int x, int y, int length) : base(x, y)
        {
            Length = length;
        }

        public override string ToString()
        {
            return "Линия создана! \n" + "Длина: " + length + "\n" + "Координаты точки начала: " + X + " " + Y;
        }
    }
    #endregion
}
