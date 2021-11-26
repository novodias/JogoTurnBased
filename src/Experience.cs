using System;

namespace JogoTurnBased
{
    public class Experience
    {
        private int Points { get; set; } = 0;       
        /// <summary>
        /// Pega o valor definido no stats do player e retorna com exp definido.
        /// </summary>
        /// <param name="PlayerExp"></param>
        /// <returns></returns>
        public int GainEXP(int PlayerExp, int MonsterExp)
        {
            int totalExp;
            if (Points == 0 || Points == 1)
            {
                totalExp = PlayerExp + MonsterExp;
                return totalExp; // Valor exp definido do monstro.
            }
            else
            {
                totalExp = PlayerExp + (MonsterExp * Points); // Valor exp definido do monstro multiplicado pelo nível.
                return totalExp;
            }
        }

        /// <summary>
        /// Checa se o player upou com um metodo booleano
        /// </summary>
        /// <param name="PlayerExp"></param>
        /// <param name="PlayerLevelUpMin"></param>
        /// <returns></returns>
        private bool CheckLevelUp(int PlayerExp, int PlayerLevelUpMin)
        {
            if ( PlayerExp >= PlayerLevelUpMin )
            {
                Points++;
                return true;
            }
            return false;
        }

        private int[] LevelUpStats(string stats, int[] playerStats)
        {
            Random randomStat = new();
            NewTry:
            switch (stats)
            {
                case "HP":
                case "Hp":
                case "hp":
                    playerStats[6] += randomStat.Next(1, 16);
                    Console.WriteLine(MessageClass.SendMessage("HpMax", "exp"), playerStats[6]);
                    return playerStats;

                case "DANO":
                case "Dano":
                case "dano":
                case "damage":
                    playerStats[1] += randomStat.Next(1, 6);
                    Console.WriteLine(MessageClass.SendMessage("Attack", "exp"), playerStats[1]);
                    return playerStats;

                case "ESQUIVA":
                case "Esquiva":
                case "esquiva":
                case "dodge":
                    playerStats[2] += randomStat.Next(1, 6);
                    Console.WriteLine(MessageClass.SendMessage("Dodge", "exp"), playerStats[2]);
                    return playerStats;

                case "CURA":
                case "Cura":
                case "cura":
                case "heal":
                    playerStats[3] += randomStat.Next(1, 6);
                    Console.WriteLine(MessageClass.SendMessage("Heal", "exp"), playerStats[3]);
                    return playerStats;

                default:
                    Console.WriteLine(MessageClass.SendMessage("NewTry", "exp"));
                    stats = Console.ReadLine();
                    goto NewTry;
            }
        }

        public int[] LevelUp(int[] PlayerStats)
        {
            if(CheckLevelUp(PlayerStats[4], PlayerStats[5]) == true)
            {
                Console.WriteLine(MessageClass.SendMessage("LevelUp", "exp"), Points);
                Console.WriteLine(MessageClass.SendMessage("Choose", "exp"), PlayerStats[6], PlayerStats[1], PlayerStats[2], PlayerStats[3]);

                string ChooseStats = Console.ReadLine();
                ChooseStats.ToLower();

                PlayerStats[5] += PlayerStats[5];

                Console.WriteLine(MessageClass.SendMessage("ExpTotal", "exp"), PlayerStats[4], PlayerStats[5]);

                return LevelUpStats(ChooseStats, PlayerStats); // retorna os stats do player após upar.
            }
            Console.WriteLine(MessageClass.SendMessage("ExpTotal", "exp"), PlayerStats[4], PlayerStats[5]);
            return PlayerStats; // retorna os stats originais do player.
        }
    }
}
