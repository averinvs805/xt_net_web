using System;

namespace Task_2._2._Game_Development
{
    abstract class Entity
    {
        protected int pos_x, pos_y;

        public Entity(int pos_x, int pos_y)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
        }
    }

    abstract class Character : Entity
    {

        protected int health;

        public abstract void Move();
        public abstract void Damage();

        public Character(int pos_x, int pos_y, int health) : base(pos_x, pos_y) 
        {
            if (health > 0)
            {
                this.health = health;
            }
        }

        public void Hurt(int damage)
        {
            health -= damage;
        }
    }

    abstract class Bonus : Entity
    {
        protected int points;

        public Bonus(int pos_x, int pos_y, int points) : base (pos_x, pos_y)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
