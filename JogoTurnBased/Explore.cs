using System;

namespace JogoTurnBased
{
    public class Explore
    {
        private int[] _playerStats { get; set; }
        private string _name { get; set; }
        Experience exp = new();
        Random random = new();
        public void FoundDungeon(string name, int[] getstats)
        {
            _name = name;
            _playerStats = getstats;
            Console.WriteLine(MessageClass.SendMessage("MesDungeonFound", "explore"));
            ExploreDungeon(_name, _playerStats);
        }

        private int[] ExploreDungeon(string name, int[] PlayerStats)
        {
            Console.WriteLine(MessageClass.SendMessage("MesDungeonExplore", "explore"));
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
                return ContinueDungeon(name, PlayerStats, MessageClass.SendMessage("ConDungeonFoundNothing", "explore"));
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
                    Console.WriteLine(MessageClass.SendMessage("HpPotionFound01", "explore"), resthp);
                }
                else
                {
                    Console.WriteLine(MessageClass.SendMessage("HpPotionFound02", "explore"));
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

            void BigChungus() { exp = 2;    item = MessageClass.SendMessage("BigChungus", "explore");           }
            void Thanos() {     exp = 5;    item = MessageClass.SendMessage("ThanosT", "explore");      }
            void Amogus() {     exp = 10;   item = MessageClass.SendMessage("SusAmogusD", "explore");    }

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

            Console.WriteLine(MessageClass.SendMessage("ItemAndExp", "explore"), item, exp);
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
