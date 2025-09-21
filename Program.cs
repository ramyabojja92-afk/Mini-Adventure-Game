using System;

namespace Mini_Adventure_Game
{
    
    
        


    
        internal class Program
        {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure!");

            
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.WriteLine("Choose a class: Warrior / Mage");
            string playerClass = Console.ReadLine();

            
            int playerHP = 50;
            int playerMaxHP = 100;
            int playerDamage = 20;
            int playerGold = 1;

            Player player = new Player(playerName, playerClass, playerHP, playerMaxHP, playerDamage, playerGold);

            // Enemies value
            Enemy[] enemies = new Enemy[]
            {
                new Enemy("Goblin", 10, 15, 1),
                new Enemy("Skeleton", 15, 20, 0),
                new Enemy("Rat", 5, 10, 1),
                new Enemy("Bandit", 12, 18, 2)
                };
                
            // Main Loop
                bool running = true;
                while (running && player.HP > 0)
                {
                    Console.WriteLine("=== Main Menu ===");
                    Console.WriteLine("1) Adventure  2) Rest  3) Status  4) Quit");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Choose an enemy to fight (0.Goblin,1.Skeleton,2.Rat,3.Bandit): ");
                            if (!int.TryParse(Console.ReadLine(), out int enemyIndex) ||
                             enemyIndex < 0 || enemyIndex >= enemies.Length)
                            { 

                            Console.WriteLine("Invalid choice.");
                                break;
                            }
                            Battle(player, enemies[enemyIndex]);
                            break;

                        case "2":
                            player.Rest();
                            break;

                        case "3":
                            player.PrintStatus();
                            break;

                        case "4":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }

                if (player.HP <= 0)
                    Console.WriteLine("You died... Game Over.");
                else
                    Console.WriteLine("Thanks for playing!");
            }

            static void Battle(Player player, Enemy enemy)
            {
                Console.WriteLine($"You face {enemy.Name} (HP: {enemy.HP}, Damage: {enemy.Damage})");

                while (player.HP > 0 && enemy.HP > 0)
                {
                    Console.WriteLine("Choose action: 1) Attack  2) Heal  3) Run");
                    string action = Console.ReadLine();

                    if (action == "1")
                    {
                        enemy.HP = player.Damage;
                        Console.WriteLine($"You deal {player.Damage} damage to {enemy.Name}");
                    }
                    else if (action == "2")
                    {
                        player.Heal(20); 
                    }
                    else if (action == "3")
                    {
                        Console.WriteLine("You run away!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid action.");
                        continue;
                    }

                    // Enemy attacks back if still alive
                    if (enemy.HP > 0)
                    {
                        player.HP = enemy.Damage;
                        Console.WriteLine($"{enemy.Name} deals {enemy.Damage} damage to you!");
                    }
                }

                if (player.HP > 0)
                {
                    Console.WriteLine($"You defeated {enemy.Name}! You gain {enemy.GoldReward} gold.");
                    player.Gold += enemy.GoldReward;
                }
            }
        }
    }

    








    

                
            
                 
                            
                         
                         
                        
                   
        
    
    
               
                       
                  
                
            







       
      
                   