using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2._Game_Development
{

    #region Player
    class Player : AbstractCharacter
    {
        string name;

        public override void Move() { }
        public override void Attack() { }
        public override void Hurt() { }
        public void TakeBonus() { }

        public Player(int pos_x, int pos_y, int health) : base(pos_x, pos_y, health) { }
    }
    #endregion

    #region Barbarian
    class Barbarian : AbstractEnemy
    {
        public override void Move() { }
        public override void Attack() { }
        public override void Hurt() { }
        public void Berserk() { }

        public Barbarian(int pos_x, int pos_y, int health) : base(pos_x, pos_y, health) { }

    }
    #endregion

    #region DarkMage
    class DarkMage : AbstractEnemy
    {
        public override void Move() { }
        public override void Attack() { }
        public override void Hurt() { }
        public void SpellCast() { }

        public DarkMage(int pos_x, int pos_y, int health) : base(pos_x, pos_y, health) { }
    }
    #endregion

    #region HealingPotion
    class HealingPotion : AbstractBonus
    {
        int healing_amount;

        public override void Effect() { }

        public HealingPotion(int pos_x, int pos_y, int points) : base(pos_x, pos_y, points) { }
    }
    #endregion
}
