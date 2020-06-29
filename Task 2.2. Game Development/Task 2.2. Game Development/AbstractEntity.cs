using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._Game_Development
{
    abstract class AbstractEntity
    {
        protected int pos_x, pos_y;

        public AbstractEntity(int pos_x, int pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }
    }
}
