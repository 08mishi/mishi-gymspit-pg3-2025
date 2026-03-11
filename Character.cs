using System;

namespace GymSpit
{
    public class Character
    {
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public string Name { get; set; }
        public int Armor { get; set; }
        public bool Alive { get; set; }

        public Character(string name, int maxHitPoints, int armor)
        {
            Name = name;
            MaxHitPoints = maxHitPoints;
            HitPoints = maxHitPoints;
            Armor = armor;
            Alive = true;
        }

        public void Reset()
        {
            HitPoints = MaxHitPoints;
            Alive = true;
        }

        public void TakeTurn()
        {
            // Logic for taking a turn in the game goes here.
            Console.WriteLine(Name + " takes their turn.");
        }
    }
}