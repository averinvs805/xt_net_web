using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._Game_Development
{
    class HealingPotion : AbstractItem
    {
        int healing_amount;

        public override void Effect() { }

        public HealingPotion(int pos_x, int pos_y, int points) : base(pos_x, pos_y, points) { }
    }
}
