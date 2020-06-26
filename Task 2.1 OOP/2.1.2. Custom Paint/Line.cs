using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    #region Line
    public class Line : AbstractShape
    {
        int length;
        public Line(int x, int y, int length) : base(x, y)
        {
            Length = length;
        }

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

        public override string ToString()
        {
            return "Линия создана! \n" + "Длина: " + length + "\n" + "Координаты точки начала: " + X + " " + Y;
        }
    }
    #endregion
}
