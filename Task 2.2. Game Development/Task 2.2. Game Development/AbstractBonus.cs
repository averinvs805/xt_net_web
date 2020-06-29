using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._Game_Development
{
    interface IUseable
    {
        public void Effect();
    }
    abstract class AbstractItem : AbstractEntity, IUseable
    {
        protected int points;

        public abstract void Effect();

        public AbstractItem(int pos_x, int pos_y, int points) : base(pos_x, pos_y)
        {
            this.points = points;
        }
    }
}
