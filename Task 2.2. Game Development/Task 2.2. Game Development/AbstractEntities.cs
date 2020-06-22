using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._Game_Development
{
    #region Entity
    abstract class AbstractEntity
    {
        protected int pos_x, pos_y;

        public AbstractEntity(int pos_x, int pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }
    }
    #endregion

    #region Character
    abstract class AbstractCharacter : AbstractEntity
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
    #endregion

    #region Enemy
    abstract class AbstractEnemy : AbstractCharacter
    {
        public override void Move() { }
        public override void Attack() { }
        public override void Hurt() { }

        public AbstractEnemy(int pos_x, int pos_y, int health) : base(pos_x, pos_y, health) { }
    }
    #endregion

    #region Bonus
    abstract class AbstractBonus : AbstractEntity
    {
        protected int points;

        public abstract void Effect();

        public AbstractBonus(int pos_x, int pos_y, int points) : base(pos_x, pos_y)
        {
            this.points = points;
        }
    }
    #endregion
}
