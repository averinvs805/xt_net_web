using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    #region Rectangle
    public class Rectangle : AbstractShape
    {
        private int sideA, sideB;

        public Rectangle(int x, int y, int hor_side, int vert_side) : base(x, y)
        {
            HorizontalSide = hor_side;
            VerticalSide = vert_side;
        }

        public int Area { get; set; }
        public int Perimeter { get; set; }

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
}
