using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._Game_Development
{
    interface IMovable
    {
        public void Move();
    }

    interface IHurtable
    {
        public void Hurt();
    }

    interface IAttacker
    {
        public void Attack();
    }

    abstract class AbstractCharacter : AbstractEntity, IMovable, IHurtable, IAttacker
    {

        protected int id, health, damage;

        public abstract void Move();
        public abstract void Attack();
        public abstract void Hurt();

        public AbstractCharacter(int pos_x, int pos_y, int health) : base(pos_x, pos_y)
        {
            if (health > 0)
            {
                this.health = health;
            }
        }
    }
}
