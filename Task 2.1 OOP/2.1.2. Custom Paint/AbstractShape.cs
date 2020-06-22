using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    public abstract class AbstractShape
    {
        private int x, y;

        protected int X
        {
            get => x;

            set
            {
                if (value > 0)
                {
                    x = value;
                }
            }
        }

        protected int Y
        {
            get => y;

            set
            {
                if (value > 0)
                {
                    y = value;
                }
            }
        }

        protected AbstractShape(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
