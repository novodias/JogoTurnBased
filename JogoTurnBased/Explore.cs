﻿using System;
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
        string MessageDungeonFound = "Você encontrou uma dungeon!";
        string MessageDungeonExplore = "Explorando a dungeon...";
        public void FoundDungeon(int[] getstats)
        {
            _playerStats = getstats;
            Console.WriteLine(MessageDungeonFound);
            ExploreDungeon(_playerStats);
        }

        private int ExploreDungeon(int[] PlayerStats)
        {
            Console.WriteLine(MessageDungeonExplore);
            Random random = new();
            Cmmds cmmds = new();
            int RandomFind = random.Next(0, 101);
            if ( RandomFind >= 1 && RandomFind <= 50 )
            {
                // Combate
                cmmds.cmmdsInExplore();
                cmmds.InsertText("");
                return ExploreDungeon(PlayerStats);
            }
            else if ( RandomFind > 50 && RandomFind <= 75 )
            {
                FoundItems();
                cmmds.cmmdsInExplore();
                cmmds.InsertText("");
                return ExploreDungeon(PlayerStats);
            }
            else
            {
                Console.WriteLine("Você encontrou nada.");
                cmmds.cmmdsInExplore();
                cmmds.InsertText("");
                return ExploreDungeon(PlayerStats);
            }
        }

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
    }
}
