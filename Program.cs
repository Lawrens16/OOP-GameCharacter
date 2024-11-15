using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    abstract class GameCharacter
    {
        public string Name { get; }
        public int Level { get;  set; }
        public int Health { get;  set; }
        public int Mana { get;  set; }
        public int Strength { get;  set; }
        public int Intelligence { get;  set; }

        protected GameCharacter(string name, int level, int health, int mana, int strength, int intelligence)
        {
            Name = name;
            Level = level;
            Health = health;
            Mana = mana;
            Strength = strength;
            Intelligence = intelligence;
        }
        public abstract void Attack();
        public abstract void Defend();
        public abstract void LevelUp();



    }

    class Warrior : GameCharacter
    {
        public int Armor { get; set; } = 10;

        public Warrior(string name, int level, int health, int strength)
            : base(name, level, health, 0, strength, 0)
        {
        }

        public override void Attack()
        {
            int baseDamage = Strength * 2;
            Random rnd = new Random();
            bool criticalHit = rnd.Next(100) < 20; 
            int finalDamage = criticalHit ? baseDamage * 2 : baseDamage;    

            Console.WriteLine($"{Name} attacks and deals {finalDamage} damage{(criticalHit ? " with a critical hit!" : ".")}");
        }

        public override void Defend()
        {
            int damageReduction = Armor / 2;
            Random rnd = new Random();
            bool block = rnd.Next(100) < 15; 

            if (block)
            {
                Console.WriteLine($"{Name} blocks the attack completely!");
            }
            else
            {
                Console.WriteLine($"{Name} reduces the damage by {damageReduction}.");
            }
        }

        public override void LevelUp()
        {
            Level++;
            Strength += 5;
            Health += 20;
            Armor += 2;

            Console.WriteLine($"{Name} leveled up! Level: {Level}, Strength: {Strength}, Health: {Health}, Armor: {Armor}");
        }
    

    class Mage : GameCharacter
    {
        public int SpellPower { get; set; } = 10;

        public Mage(string name, int level, int health, int mana, int intelligence)
            : base(name, level, health, mana, 0, intelligence)
        {
        }

        public override void Attack()
        {
            int magicDamage = (Intelligence * 3) + SpellPower;
            Random random = new Random();
            bool burningEffect = random.Next(100) < 25; 

            Console.WriteLine($"{Name} casts a spell and deals {magicDamage} damage{(burningEffect ? ", applying a burning effect!" : ".")}");
        }

        public override void Defend()
        {
            int damageReduction = Mana / 4;
            Random random = new Random();
            bool evade = random.Next(100) < 20; 

            if (evade)
            {
                Console.WriteLine($"{Name} evades the attack completely!");
            }
            else
            {
                Console.WriteLine($"{Name} reduces the damage by {damageReduction}.");
            }
        }

        public override void LevelUp()
        {
            Level++;
            Intelligence += 5;
            Mana += 15;
            SpellPower += 3;

            Console.WriteLine($"{Name} leveled up! Level: {Level}, Intelligence: {Intelligence}, Mana: {Mana}, SpellPower: {SpellPower}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Warrior thor = new Warrior("Thor", 1, 100, 15);
            Mage merlin = new Mage("Merlin", 1, 80, 50, 20);

            Console.WriteLine($"Warrior: {thor.Name}, Level: {thor.Level}, Health: {thor.Health}, Strength: {thor.Strength}, Armor: {thor.Armor}");
            Console.WriteLine($"Mage: {merlin.Name}, Level: {merlin.Level}, Health: {merlin.Health}, Mana: {merlin.Mana}, Intelligence: {merlin.Intelligence}, SpellPower: {merlin.SpellPower}");

            Console.WriteLine("\n--- Actions ---");
            thor.Attack();
            thor.Defend();
            thor.LevelUp();

            merlin.Attack();
            merlin.Defend();
            merlin.LevelUp();

            Console.WriteLine("\n--- Updated State ---");
            Console.WriteLine($"Warrior: {thor.Name}, Level: {thor.Level}, Health: {thor.Health}, Strength: {thor.Strength}, Armor: {thor.Armor}");
            Console.WriteLine($"Mage: {merlin.Name}, Level: {merlin.Level}, Health: {merlin.Health}, Mana: {merlin.Mana}, Intelligence: {merlin.Intelligence}, SpellPower: {merlin.SpellPower}");
        }
    }
