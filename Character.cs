using System;

namespace GymSpit
{
    public class Character
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Armor { get; set; }
        public int Agility { get; set; }
        public bool Alive { get; set; }

        public int ArmorBonus { get; set; }

        public int AttackComboBonus { get; set; }

        public Character(string name, int maxHitPoints, int armor, int agility)
        {
            Name = name;
            MaxHitPoints = maxHitPoints;
            HitPoints = maxHitPoints;
            Armor = armor;
            Agility = agility;
            Alive = true;
            ArmorBonus = 0;
            AttackComboBonus = 0;
        }

        public void Reset()
        {
            HitPoints = MaxHitPoints;
            Alive = true;
            ArmorBonus = 0;
            AttackComboBonus = 0;
        }

        public int GetTotalArmor()
        {
            return Armor + ArmorBonus;
        }

        public int GetAttackBonus()
        {
            return AttackComboBonus;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
            if (HitPoints < 0) HitPoints = 0;
            if (HitPoints == 0) Alive = false;
        }

        public void Heal(int amount)
        {
            HitPoints += amount;
            if (HitPoints > MaxHitPoints) HitPoints = MaxHitPoints;
        }

        public bool TryDodge()
        {
            Random rand = new Random();
            int dodgeRoll = rand.Next(1, 21);
            return dodgeRoll > Agility;
        }
    }
}
