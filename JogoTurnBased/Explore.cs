﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    public class Explore
    {
        private int[] _playerStats { get; set; }
        private string _name { get; set; }
        string MessageDungeonFound = "Você encontrou uma dungeon!";
        string MessageDungeonExplore = "Explorando a dungeon...";
        Experience exp = new();
        Random random = new();
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
            int RandomFind = random.Next(0, 101);
            if ( RandomFind >= 1 && RandomFind <= 50 )
            {
                // Combat
                Combat battle = new();
                battle.GetStatsBeforeCombat(name, PlayerStats);
                battle.CombatStart();
                PlayerStats = battle.ReturnStatsAfterCombat();

                // Player Retry
                if ( IsPlayerDead( battle.status ) && PlayerStats[0] <= 0 )
                {
                    goto Retry;
                }

                // Exp
                PlayerStats[4] = exp.GainEXP(PlayerStats[4], battle.mExp);
                exp.LevelUp(PlayerStats);

                // Loop
                return ContinueDungeon(name, PlayerStats);

                // Death
                Retry:
                return PlayerStats;
            }
            else if ( RandomFind > 50 && RandomFind <= 75 )
            {
                // Items
                FoundItems();
                exp.LevelUp(PlayerStats);

                // Loop
                return ContinueDungeon(name, PlayerStats);
            }
            else
            {
                // Loop
                return ContinueDungeon(name, PlayerStats, "Você encontrou nada.");
            }
        }

        #region Continue Dungeon
        private int[] ContinueDungeon(string name, int[] PlayerStats)
        {
            Cmmds.List("explore");
            Cmmds.InsertText();
            ExploreDungeon(name, PlayerStats);
            return PlayerStats;
        }

        private int[] ContinueDungeon(string name, int[] PlayerStats, string message)
        {
            Console.WriteLine(message);
            Cmmds.List("explore");
            Cmmds.InsertText();
            ExploreDungeon(name, PlayerStats);
            return PlayerStats;
        }
        #endregion

        #region Items Related Methods
        private int FoundItems()
        {
            int ExpReturn = random.Next(0, 11);
            HPpotion();
            return ItemsReturn(ExpReturn);
        }

        private void HPpotion()
        {
            void Found()
            {
                if ( _playerStats[0] + 5 > _playerStats[6] )
                {
                    int resthp = _playerStats[6] - _playerStats[0];
                    _playerStats[0] += resthp;
                    Console.WriteLine($"Você achou uma poção de HP! bebeu, e recuperou {resthp} de HP");
                }
                else
                {
                    Console.WriteLine("Você achou uma poção de HP! bebeu, e recuperou 5 de HP");
                    _playerStats[0] += 5;
                }
            }

            if (random.Next(0, 11) <= 5)
            {
                Found();
            }
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
            return _playerStats[4] += exp;
        }
        #endregion

        #region Is Player Dead Method
        private bool IsPlayerDead(int status)
        {
            switch (status)
            {
                default:
                    return true;

                case 0:
                    return false;

                case 1:
                    return false;
            }
        }
        #endregion
    }
}
