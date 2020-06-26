using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    #region Ring
    public class Ring : Circle
    {
        private double inner_rad;

        public Ring(int x, int y, double outerRadius, double inRadius) : base(x, y, outerRadius)
        {
            InnerRadius = inRadius;
        }

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

        public virtual void FindInnerCircumference()
        {
            InnerCircumference = 2 * Math.PI * InnerRadius;
        }

        public void FindArea()
        {
            Area = Math.PI * (Math.Pow(OuterRadius, 2) - Math.Pow(InnerRadius, 2));
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
}
