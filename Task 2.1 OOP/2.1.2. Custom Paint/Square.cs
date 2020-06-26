using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    #region Square
    public class Square : AbstractShape
    {
        double side_square;

        public Square(int x, int y, double sideSquare) : base(x, y)
        {
            Side = sideSquare;
        }

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
}
