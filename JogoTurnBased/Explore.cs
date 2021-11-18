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
            if ( ExpReturn >= 1 && ExpReturn <= 5 )
            {
                Console.WriteLine("Você encontrou um big chungus! e ganhou +2 de exp.");
                return 2;
            }
            else if (ExpReturn > 5 && ExpReturn < 10)
            {
                Console.WriteLine("Você encontrou o Thanos em T pose! e ganhou +5 de exp.");
                return 5;
            }
            else
            {
                Console.WriteLine($"Você encontrou sus amogus dourado! e ganhou +10 de exp.");
                return 10;
            }
        }
    }
}
