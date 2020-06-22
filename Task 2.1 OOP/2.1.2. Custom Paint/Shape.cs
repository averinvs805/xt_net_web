using System;
using System.Collections.Generic;
using System.Text;

namespace _2._1._2._Custom_Paint
{
    public abstract class Shape
    {
        protected int x, y;

        protected Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
