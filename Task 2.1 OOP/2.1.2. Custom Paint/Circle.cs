using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    #region Circle
    public class Circle : AbstractShape
    {
        private double outer_rad;

        public Circle(int x, int y, double outerRadius) : base(x, y)
        {
            OuterRadius = outerRadius;
        }

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
}
