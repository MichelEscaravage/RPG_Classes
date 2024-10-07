using System;
using System.Numerics;

public abstract class Character
{
    public string Naam { get; set; }
    public int Niveau { get; set; }
}

public class Player : Character
{
    public int ExperiencePoints { get; set; }

    public Player(string name, int niveau, int experiencePoints)
    {
        Naam = name;
        Niveau = niveau;
        ExperiencePoints = experiencePoints;
    }

    public override string ToString()
    {
        return $"Player: {Naam}, Niveau: {Niveau}, ExperiencePoints: {ExperiencePoints}";
    }
}


public class Enemy : Character
{
    public int AttackPower { get; set; }

    public Enemy(string name, int niveau, int attackPower)
    {
        Naam = name;
        Niveau = niveau;
        AttackPower = attackPower;
    }

    public override string ToString()
    {
        return $"Naam: {Naam}, AttackPower: {AttackPower}";
    }
}

public static class Game
{
    public static void Battle(Player player, Enemy enemy)
    {
        if (enemy.AttackPower > player.Niveau)
        {
            EnemyWins(player, enemy);
            Thread.Sleep(1000);
            Console.Clear();
            Environment.Exit(0);
        }
        else if (enemy.AttackPower < player.Niveau)
        {
            PlayerWins(player, enemy);
            Thread.Sleep(1000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Its a tie! BOOO");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    public static bool EnemyWins(Player player, Enemy enemy)
    {
        Console.WriteLine("The enemy has won");

        return true;
    }

    public static bool PlayerWins(Player player, Enemy enemy)
    {
        Console.WriteLine("The player has won");
        player.ExperiencePoints += 10;
        return true;
    }

    public static void LevelUpCheck(Player player)
    {
        if (player.ExperiencePoints >= 100)
        {
            player.Niveau += 1;
        }
    }
}

public class Program
{
    public static void Main()
    {

        Player player1 = new Player("Joost", 20, 0);
        Enemy Firstenemy = new Enemy("Sietze", 20, 10);

        /*Game.Battle(player1, Firstenemy);*/

        List<Enemy> enemyList = new List<Enemy>();
        List<Player> playerList = new List<Player>();

        enemyList.Add(new Enemy("test1", 10, 10));
        enemyList.Add(new Enemy("test2", 10, 20));
        enemyList.Add(new Enemy("test3", 10, 30));
        enemyList.Add(new Enemy("test4", 10, 40));

        while (true)
        {
            Console.WriteLine("Welcome!" +
                "\nChoose your battle!" +
                "\n1. Fight all enemies in order" +
                "\n2. Choose an enemy" +
                $"\n\n\n{player1}");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Console.Clear();
                foreach (Enemy enemy in enemyList)
                {
                    Enemy currentEnemy = enemy;

                    Game.Battle(player1, enemy);

                    if (currentEnemy.AttackPower > player1.Niveau)
                    {
                        Console.WriteLine("YOU DIED");
                        break;
                    }
                }
            }
            else if (choice == "2")
            {
                int i = 0;
                Console.Clear();
                Console.WriteLine("Choose an enemy");
                foreach (Enemy enemy in enemyList)
                {
                    i++;
                    Console.WriteLine($"{i} {enemy}");
                }
                string choice2 = Console.ReadLine();
                Console.Clear();
                switch (choice2)
                {
                    case "1":
                        Enemy enemy1 = enemyList[0];
                        Game.Battle(player1, enemy1);
                        Game.LevelUpCheck(player1);
                        break;
                    case "2":
                        Enemy enemy2 = enemyList[1];
                        Game.Battle(player1, enemy2);
                        Game.LevelUpCheck(player1);
                        break;
                    case "3":
                        Enemy enemy3 = enemyList[2];
                        Game.Battle(player1, enemy3);
                        Game.LevelUpCheck(player1);
                        break;
                    case "4":
                        Enemy enemy4 = enemyList[3];
                        Game.Battle(player1, enemy4);
                        Game.LevelUpCheck(player1);
                        break;
                }
            }
        }
    }
}