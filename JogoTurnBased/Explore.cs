using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    public class Explore
    {
        // sem uso no momento.
        string MessageDungeonFound = "Você encontrou uma dungeon!";
        string MessageDungeonExplore = "Explorando a dungeon...";
        public void FoundDungeon(int exp)
        {
            Console.WriteLine(MessageDungeonFound);
            ExploreDungeon(exp);
        }

        private int ExploreDungeon(int exp)
        {
            Console.WriteLine(MessageDungeonExplore);
            Random random = new();
            int RandomFind = random.Next(0, 101);
            if ( RandomFind >= 1 && RandomFind <= 50 )
            {
                // Combate
                return exp; // TODO
            }
            else if ( RandomFind > 50 && RandomFind <= 75 )
            {
                return FoundItems();
            }
            else
            {
                Console.WriteLine("Você encontrou nada.");
                return ExploreDungeon(exp);
            }
        }

        private int FoundItems()
        {
            Random randomExp = new();
            int ExpReturn = randomExp.Next(0, 11);
            return ItemsReturn(ExpReturn);
        }

        private int ItemsReturn(int randomExp)
        {
            int exp;
            string item;

            void BigChungus() { exp = 2;    item = "Big Chungus";           }
            void Thanos() {     exp = 5;    item = "Thanos em T pose";      }
            void Amogus() {     exp = 10;   item = "Sus Amogus dourado";    }

            if( randomExp >= 1 && randomExp <= 5 )
            {
                BigChungus(); // retorna 2
            }
            else if ( randomExp > 5 && randomExp < 10 )
            {
                Thanos(); // retorna 5
            }
            else
            {
                Amogus(); // retorna 10
            }

            Console.WriteLine($"Você encontrou um {item}! e ganhou +{exp} de exp");
            return exp;
        }
    }
}
