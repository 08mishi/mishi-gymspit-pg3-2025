using System;

namespace GymSpit
{
    internal class Game
    {
        private Character characterOne;
        private Character characterTwo;
        private Die die;

        public Game(Character characterOne, Character characterTwo, Die die)
        {
            this.characterOne = characterOne;
            this.characterTwo = characterTwo;
            this.die = die;
        }

        public void Run(TextWriter output)
        {
            Console.WriteLine("Let the games begin!");

            characterOne.Reset();
            characterTwo.Reset();

            PrintStatus(output, characterOne);
            PrintStatus(output, characterTwo);
            Console.WriteLine();

            Character active = characterOne;
            Character nonActive = characterTwo;

            while (characterOne.Alive && characterTwo.Alive)
            {
                Console.WriteLine("{0}'s turn:", active.Name);
                Console.WriteLine("Choose action: (1) Attack, (2) Defense, (3) Wait");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PerformAttack(output, active, nonActive);
                        break;
                    case "2":
                        PerformDefense(output, active);
                        break;
                    case "3":
                        PerformWait(output, active);
                        break;
                    default:
                        Console.WriteLine("Invalid action. Attack instead.");
                        PerformAttack(output, active, nonActive);
                        break;
                }

                Console.WriteLine();
                PrintStatus(output, characterOne);
                PrintStatus(output, characterTwo);
                Console.WriteLine();

                Character tmp = active;
                active = nonActive;
                nonActive = tmp;
            }

            Console.WriteLine("GAME OVER!");
            if (characterOne.Alive || characterTwo.Alive)
            {
                Character winner = characterOne.Alive ? characterOne : characterTwo;
                Console.WriteLine("The winner is {0}!", winner.Name);
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        private void PerformAttack(TextWriter output, Character attacker, Character defender)
        {
            int roll = die.Roll();
            Console.WriteLine("{0} rolls for attack: {1}", attacker.Name, roll);

            if (roll == 1)
            {
                Console.WriteLine("CRITICAL MISS! {0} completely botches the attack!", attacker.Name);
                attacker.AttackComboBonus = 0;
                return;
            }

            if (defender.TryDodge())
            {
                Console.WriteLine("{0} dodges the attack!", defender.Name);
                attacker.AttackComboBonus = 0;
                return;
            }

            int totalAttackRoll = roll + attacker.GetAttackBonus();
            int defenderArmor = defender.GetTotalArmor();

            if (totalAttackRoll >= defenderArmor)
            {
                int damage = 5 + attacker.GetAttackBonus();

                if (roll == 20)
                {
                    damage *= 2;
                    Console.WriteLine("CRITICAL HIT! {0} deals {1} damage!", attacker.Name, damage);
                }
                else
                {
                    Console.WriteLine("{0} hits {1} for {2} damage!", attacker.Name, defender.Name, damage);
                }

                defender.TakeDamage(damage);
                
                attacker.AttackComboBonus++;
                Console.WriteLine("{0}'s combo bonus is now +{1}", attacker.Name, attacker.AttackComboBonus);

                if (attacker.ArmorBonus > 0)
                {
                    attacker.ArmorBonus--;
                    Console.WriteLine("{0}'s armor bonus reduced to {1}", attacker.Name, attacker.ArmorBonus);
                }
            }
            else
            {
                Console.WriteLine("{0} misses {1}!", attacker.Name, defender.Name);
                attacker.AttackComboBonus = 0;
            }
        }

        private void PerformDefense(TextWriter output, Character defender)
        {
            defender.ArmorBonus += 3;
            Console.WriteLine("{0} takes a defensive stance! Armor bonus is now +{1}", defender.Name, defender.ArmorBonus);
            defender.AttackComboBonus = 0;
        }

        private void PerformWait(TextWriter output, Character character)
        {
            Random rand = new Random();
            int healing = rand.Next(3, 9);
            character.Heal(healing);
            Console.WriteLine("{0} waits and recovers {1} HP!", character.Name, healing);
            character.AttackComboBonus = 0;
        }

        private void PrintStatus(TextWriter output, Character character)
        {
            output.WriteLine(
                "{0}: {1}, {2}/{3} HP, Armor: {4}+{5}, Combo: +{6}",
                character.Name,
                character.Alive ? "alive" : "DEAD",
                character.HitPoints,
                character.MaxHitPoints,
                character.Armor,
                character.ArmorBonus,
                character.AttackComboBonus
            );
        }
    }
}
