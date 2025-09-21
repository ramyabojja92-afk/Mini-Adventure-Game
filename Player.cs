using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Adventure_Game
{
    internal class Player
    {
        public string Name;
        public string Class;
        public int HP;
        public int MaxHP;
        public int Damage;
        public int Gold;

        public Player(string name, string playerClass, int hp, int maxHp, int damage, int gold)
        {
            Name = name;
            Class = playerClass;
            HP = hp;
            MaxHP = maxHp;
            Damage = damage;
            Gold = gold;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"\nName: {Name} | Class: {Class}");
            Console.WriteLine($"HP: {HP}/{MaxHP} | Damage: {Damage} | Gold: {Gold}");
        }




        public void Heal(int amount)
        {
            HP = Math.Min(MaxHP, HP + amount);
        }

        public void Rest()
        {
            int healAmount = 30; 
            HP = Math.Min(MaxHP, HP + healAmount);
            Console.WriteLine($"You rest and recover {healAmount} HP. Current HP: {HP}/{MaxHP}");
        }
    }
}






