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
        private int[] _playerStats { get; set; }
        private string _name { get; set; }
        string MessageDungeonFound = "Você encontrou uma dungeon!";
        string MessageDungeonExplore = "Explorando a dungeon...";
        public void FoundDungeon(string name, int[] getstats)
        {
            _name = name;
            _playerStats = getstats;
            Console.WriteLine(MessageDungeonFound);
            ExploreDungeon(_name, _playerStats);
        }

        private int[] ExploreDungeon(string name, int[] PlayerStats)
        {
            Console.WriteLine(MessageDungeonExplore);
            Experience exp = new();
            Random random = new();
            int RandomFind = random.Next(0, 101);
            if ( RandomFind >= 1 && RandomFind <= 50 )
            {
                // Combate
                Combat battle = new();
                battle.GetStatsBeforeCombat(name, PlayerStats);
                battle.CombatStart();
                PlayerStats = battle.ReturnStatsAfterCombat();
                PlayerStats[4] = exp.GainEXP(PlayerStats[4], battle.mExp);
                exp.LevelUp(PlayerStats);
                return ContinueDungeon(name, PlayerStats);
            }
            else if ( RandomFind > 50 && RandomFind <= 75 )
            {
                FoundItems();
                return ContinueDungeon(name, PlayerStats);
            }
            else
            {
                return ContinueDungeon(name, PlayerStats, "Você encontrou nada.");
            }
        }

        #region Continue Dungeon
        private int[] ContinueDungeon(string name, int[] PlayerStats)
        {
            Cmmds cmmds = new();
            cmmds.cmmdsInExplore();
            cmmds.InsertText("");
            ExploreDungeon(name, PlayerStats);
            return PlayerStats;
        }

        private int[] ContinueDungeon(string name, int[] PlayerStats, string message)
        {
            Console.WriteLine(message);
            Cmmds cmmds = new();
            cmmds.cmmdsInExplore();
            cmmds.InsertText("");
            ExploreDungeon(name, PlayerStats);
            return PlayerStats;
        }
        #endregion

        #region Items Related Methods
        private int FoundItems()
        {
            Random randomExp = new();
            int ExpReturn = randomExp.Next(0, 11);
            return ItemsReturn(ExpReturn);
        }

        private int ItemsReturn(int GetRandomExp)
        {
            int exp;
            string item;

            void BigChungus() { exp = 2;    item = "Big Chungus";           }
            void Thanos() {     exp = 5;    item = "Thanos em T pose";      }
            void Amogus() {     exp = 10;   item = "Sus Amogus dourado";    }

            if( GetRandomExp >= 1 && GetRandomExp <= 5 )
            {
                BigChungus(); // retorna 2
            }
            else if ( GetRandomExp > 5 && GetRandomExp < 10 )
            {
                Thanos(); // retorna 5
            }
            else
            {
                Amogus(); // retorna 10
            }

            Console.WriteLine($"Você encontrou um {item}! e ganhou +{exp} de exp");
            return _playerStats[4] =+ exp;
        }
        #endregion
    }
}
