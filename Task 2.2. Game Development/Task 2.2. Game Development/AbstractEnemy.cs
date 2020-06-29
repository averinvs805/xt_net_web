using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._Game_Development
{
    interface IAIControllable
    {

    }
    abstract class AbstractEnemy : AbstractCharacter, IAIControllable
    {
        public override void Move() { }
        public override void Attack() { }
        public override void Hurt() { }

        public AbstractEnemy(int pos_x, int pos_y, int health) : base(pos_x, pos_y, health) { }
    }
}
