using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    #region Triangle
    public class Triangle : AbstractShape
    {
        private int side_A, side_B, side_C;

        public Triangle(int x, int y, int sideA, int sideB, int sideC) : base(x, y)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public int area { get; set; }
        public int perimeter { get; set; }

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
}
