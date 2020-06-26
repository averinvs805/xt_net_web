using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    #region Round
    public class Disk : Circle
    {
        double disk_area;

        public Disk(int x, int y, double outerRadius) : base(x, y, outerRadius)
        {
            OuterRadius = outerRadius;
        }

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
}
