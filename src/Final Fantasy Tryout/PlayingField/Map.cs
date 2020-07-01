using Final_Fantasy_Tryout.ArmorInfo;
using Final_Fantasy_Tryout.BattleLogic;
using Final_Fantasy_Tryout.Inventory;
using Final_Fantasy_Tryout.PlayerInfo;
using Final_Fantasy_Tryout.Spells;
using Final_Fantasy_Tryout.Units;
using Final_Fantasy_Tryout.Units.EnemyUnits;
using Final_Fantasy_Tryout.Units.PlayerInfo;
using System;
using System.Collections.Generic;

namespace Final_Fantasy_Tryout.PlayingField
{
    public class Map
    {
        public void Generate(Unit player)
        {
            var enemyInventory = new PlayerInventory();
            var playerMovement = new PlayerMovement();
            Battle battle = new Battle();
            EnemyUnit enemy = new EnemyUnit("Enemy","","",1
                , 0, 0, 0, 0, 0, 0, 0
                , 0, 0, 0, 0,enemyInventory);
            enemy.BeastSetClass(enemy);
            
            if (player.Level < enemy.Level)
            {
                enemy.XP = enemy.XPCap;
                enemy.LevelUp(enemy);
                Console.WriteLine(enemy.GetInfo(enemy));
            }

            string[][] mapArray = new string[12][];
            
            string playerIcon = "◄☺►";

            for (int i = 0; i < mapArray.Length; i++)
            {
                List<string> singleLine = new List<string>(){ " ║ ", "[ ]", "[ ]" ,"[ ]","[ ]"
                        , "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]"
                        , "[ ]", "[ ]", "[ ]", "[ ]", " ║ " };
                if (i == 0)
                {
                    singleLine.Clear();
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 0)
                        {
                            singleLine.Add(" ╔ ");
                        }
                        else if (j == 19)
                        {
                            singleLine.Add(" ╗");
                        }
                        else
                        {
                            singleLine.Add("═══");
                        }
                    }
                }
                if (i == 11)
                {
                    singleLine.Clear();
                    for (int j = 0; j < 20; j++)
                    {
                        if (j == 0)
                        {
                            singleLine.Add(" ╚ ");
                        }
                        else if (j == 19)
                        {
                            singleLine.Add(" ╝ ");
                        }
                        else
                        {
                            singleLine.Add("═══");
                        }
                    }
                }

                mapArray[i] = new string[singleLine.Count];
                for (int j = 0; j < singleLine.Count; j++)
                {
                    mapArray[i][j] = singleLine[j];
                }
            }

            playerMovement.X = 10;
            playerMovement.Y = 6;

            var rngX = new Random();
            int battleNumber = rngX.Next();

            while (battleNumber != 1)
            {
                battleNumber = rngX.Next(0, 5);
                var command = Console.ReadKey().Key;

                if (playerMovement.X > 1 && playerMovement.Y > 1 && playerMovement.X < 18 && playerMovement.Y < 10)
                {
                    playerMovement.Movement(command, playerMovement.X, playerMovement.Y);
                }
                if (playerMovement.X < 2) //left
                {
                    if (command == ConsoleKey.LeftArrow)
                    {
                        Console.WriteLine("Cannot move there!");
                    }
                    else
                    {
                        playerMovement.Movement(command, playerMovement.X, playerMovement.Y);
                    }
                }
                else if (playerMovement.X == 18) //right
                {

                    if (command == ConsoleKey.RightArrow)
                    {
                        Console.WriteLine("Cannot move there!");
                    }
                    else
                    {
                        playerMovement.Movement(command, playerMovement.X, playerMovement.Y);
                    }
                }
                else if (playerMovement.Y <= 1) //up
                {
                    if (command == ConsoleKey.UpArrow)
                    {
                        Console.WriteLine("Cannot move there!");
                    }

                    else
                    {
                        playerMovement.Movement(command, playerMovement.X, playerMovement.Y);
                    }
                }
                else if (playerMovement.Y == 10) //down

                    if (command == ConsoleKey.DownArrow)
                    {
                        Console.WriteLine("Cannot move there!");
                    }
                    else
                    {
                        playerMovement.Movement(command, playerMovement.X, playerMovement.Y);
                    }

                mapArray[playerMovement.Y][playerMovement.X] = playerIcon;

                for (int i = 0; i < mapArray.Length; i++)
                {
                    for (int k = 0; k < mapArray[i].Length; k++)
                    {
                        Console.Write("{0} ", mapArray[i][k]);
                    }
                    Console.WriteLine();
                }
                mapArray[playerMovement.Y][playerMovement.X] = "[ ]";
              
                if (battleNumber == 1)
                {
                    battle.BattleInitiation(player, enemy);
                }
            }
        }
    }
}
