using System;

namespace BasicEnemyInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Enemy skeleton = new Skeleton();
            Enemy ghost = new Ghost();
            Enemy boss = new Boss();


            //Test Skeleton
            Console.WriteLine("Testing Skeleton");
            skeleton.Attack();
            skeleton.TakeDamage(20);
            skeleton.TakeDamage(80);         
            Console.WriteLine();

            //Test Ghost
            Console.WriteLine("Testing Ghost");
            for(int i = 0; i < 10; i++)
            {
                ghost.TakeDamage(10);  //Test miss chance
            }
            Console.WriteLine();

            //Test Boss
            Console.WriteLine("Testing Boss");
            for (int i = 0; i < 10; i++)
            {
                boss.Attack();  //Test random attack
            }
        }
    }

    public class Enemy
    {
        public int Health { get; protected set; } = 100;
        public int Damage { get; protected set; } = 10;

        public virtual void Attack()
        {
            Console.WriteLine($"Enemy attacks and deals {Damage} damage.");
        }

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"Enemy takes {amount} damage. Remaining health: {Health}");

            if(Health <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Console.WriteLine("Enemy has died.");
        }
    }


    public class Skeleton : Enemy
    {
        //No overrides, uses base class stuff
    }

    public class Ghost : Enemy
    {
        private static readonly Random random = new Random();

        public override void TakeDamage(int amount)
        {
            if(random.Next(2) == 0) //50% chance to miss
            {
                Console.WriteLine("Attack missed! Ghost takes no damage.");
            }
            else
            {
                base.TakeDamage(amount);
            }
        }
    }

    public class Boss : Enemy
    {
        private static readonly Random random = new Random();

        public Boss()
        {
            Damage = 20; //Boss deals more damage than other enemies
        }

        public override void Attack()
        {
            int attackType = random.Next(1, 4);
            switch (attackType)
            {
                case 1:
                    Console.WriteLine("Boss performs a heavy slam, dealing 30 damage!");
                    break;
                case 2:
                    Console.WriteLine("Boss unleashes a lightning strike, dealing 20 damage over time!");
                    break;
                case 3:
                    Console.WriteLine("Boss summons minions to attack!");
                    break;
            }
        }
    }

}
