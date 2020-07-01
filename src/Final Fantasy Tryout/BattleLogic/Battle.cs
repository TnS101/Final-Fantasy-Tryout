using Final_Fantasy_Tryout.PlayingField;
using Final_Fantasy_Tryout.Units;
using System;

namespace Final_Fantasy_Tryout.BattleLogic
{
    public class Battle
    {
        public Battle()
        {
            
        }

        public void BattleInitiation(Unit player, Unit enemy)
        {
            var battleOptions = new BattleOptions(player);
            Console.Clear();
            Console.WriteLine($"You were attacked by a wild beast!({enemy.ClassType} , Level : {enemy.Level}" +
                $", Rarity : {enemy.RarityType})!");
            Console.WriteLine();
            Console.WriteLine("What are you going to do?");

            Console.WriteLine("1. Attack[1] "); Console.WriteLine("2. Defend[2] ");
            Console.WriteLine("3. Spell[3] "); Console.WriteLine("4. Run[4] ");
            Console.WriteLine();
            int turnCheck = 0;
            while (enemy.CurrentHP > 0)
            {
                if (turnCheck % 2 == 0)
                {
                    var action = Console.ReadKey().Key;
                    if (action == ConsoleKey.NumPad1)
                    {
                        battleOptions.Attack(player, enemy);
                    }
                    else if (action == ConsoleKey.NumPad2)
                    {
                        battleOptions.Defend(player);
                    }
                    else if (action == ConsoleKey.NumPad3)
                    {
                        battleOptions.SpellCast(player,enemy,player.Spells);
                    }
                    else if (action == ConsoleKey.NumPad4)
                    {
                        battleOptions.Escape(player);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Action!Try again!");
                        continue;
                    }
                    battleOptions.HealthRegenerate(player);
                    battleOptions.ManaRegenerate(player);
                    turnCheck++;
                    Console.WriteLine("---->ENEMY TURN<----");
                    Console.WriteLine();
                }

                else if (turnCheck % 2 != 0)
                {
                    var enemyAction = new Random();
                    int enemyActionNumber = enemyAction.Next(0, 3);

                    if (enemyActionNumber == 0)
                    {
                        battleOptions.Attack(enemy, player);
                    }
                    else if (enemyActionNumber == 1)
                    {
                        battleOptions.Defend(enemy);
                    }
                    else
                    {
                        battleOptions.SpellCast(enemy, player, enemy.Spells);
                    }
                    battleOptions.HealthRegenerate(enemy);
                    battleOptions.ManaRegenerate(enemy);
                    turnCheck++;
                    Console.WriteLine("---->PLAYER TURN<----");
                    Console.WriteLine();
                    Console.WriteLine("1. Attack[1] "); Console.WriteLine("2. Defend[2] ");
                    Console.WriteLine("3. Spell[3] "); Console.WriteLine("4. Run[4] ");
                    Console.WriteLine();
                }
            }
            if (player.CurrentHP <= 0)
            {
                return;
            }

            battleOptions.EndOfBattle(player);

            Map map = new Map();
            map.Generate(player);
        }
    }
}
