using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine($"Você upou o HP máximo, e aumentou para {playerStats[6]}");
                    return playerStats;

                case "DANO":
                case "Dano":
                case "dano":
                    playerStats[1] += randomStat.Next(1, 6);
                    Console.WriteLine($"Você upou Dano, e aumentou para {playerStats[1]}");
                    return playerStats;

                case "ESQUIVA":
                case "Esquiva":
                case "esquiva":
                    playerStats[2] += randomStat.Next(1, 6);
                    Console.WriteLine($"Você upou Esquiva, e aumentou para {playerStats[2]}");
                    return playerStats;

                case "CURA":
                case "Cura":
                case "cura":
                    playerStats[3] += randomStat.Next(1, 6);
                    Console.WriteLine($"Você upou Cura, e aumentou para {playerStats[3]}");
                    return playerStats;

                default:
                    Console.WriteLine("Digite corretamente o status!");
                    stats = Console.ReadLine();
                    goto NewTry;
            }
        }

        public int[] LevelUp(int[] PlayerStats)
        {
            if(CheckLevelUp(PlayerStats[4], PlayerStats[5]) == true)
            {
                Console.WriteLine($"Você upou para o nível: {Points}, e agora pode upar um stat!");
                Console.WriteLine($"Escolha um dos status para upar: " +
                    $"HP máximo: {PlayerStats[6]}, " +
                    $"Dano: {PlayerStats[1]}, " +
                    $"Esquiva: {PlayerStats[2]} e " +
                    $"Cura: {PlayerStats[3]}.");

                string ChooseStats = Console.ReadLine();
                ChooseStats.ToLower();

                PlayerStats[5] += PlayerStats[5];

                Console.WriteLine($"Sua experiência até o próximo nível: {PlayerStats[4]}/{PlayerStats[5]}");

                return LevelUpStats(ChooseStats, PlayerStats); // retorna os stats do player após upar.
            }
            Console.WriteLine($"Sua experiência até o próximo nível: {PlayerStats[4]}/{PlayerStats[5]}");
            return PlayerStats; // retorna os stats originais do player.
        }
    }
}
