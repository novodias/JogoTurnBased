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
        public void FoundDungeon()
        {
            Console.WriteLine(MessageDungeonFound);
            ExploreDungeon();
        }

        private int ExploreDungeon()
        {
            Console.WriteLine(MessageDungeonExplore);
            Random random = new();
            int RandomFind = random.Next(0, 101);
            if ( RandomFind >= 1 && RandomFind <= 50 )
            {
                // Combate
                return 0; // TODO
            }
            else if ( RandomFind > 50 && RandomFind <= 75 )
            {
                return FoundItems();
            }
            else
            {
                Console.WriteLine("Você encontrou nada.");
                return ExploreDungeon();
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

            void BigChungus() { exp = 2;    Console.WriteLine("Você encontrou um big chungus! e ganhou +2 de exp.");         }
            void Thanos() {     exp = 5;    Console.WriteLine("Você encontrou o Thanos em T pose! e ganhou +5 de exp.");     }
            void Amogus() {     exp = 10;   Console.WriteLine("Você encontrou sus amogus dourado! e ganhou +10 de exp.");    }

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

            return exp;
        }
    }
}
