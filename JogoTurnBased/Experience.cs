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
            //Random RandomExp = new();
            int totalExp = PlayerExp + MonsterExp;
            return totalExp; // Valor exp definido do monstro.
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
            //int final;
            NewTry:
            switch (stats)
            {
                case "HP":
                case "Hp":
                case "hp":
                    playerStats[0] =+ randomStat.Next(0, 16);
                    Console.WriteLine($"Você upou HP, e aumentou para {playerStats[0]}");
                    return playerStats;

                case "DANO":
                case "Dano":
                case "dano":
                    playerStats[1] =+ randomStat.Next(0, 6);
                    Console.WriteLine($"Você upou Dano, e aumentou para {playerStats[1]}");
                    return playerStats;

                case "ESQUIVA":
                case "Esquiva":
                case "esquiva":
                    playerStats[2] =+ randomStat.Next(0, 6);
                    Console.WriteLine($"Você upou Esquiva, e aumentou para {playerStats[2]}");
                    return playerStats;

                case "CURA":
                case "Cura":
                case "cura":
                    playerStats[3] =+ randomStat.Next(0, 6);
                    Console.WriteLine($"Você upou Cura, e aumentou para {playerStats[3]}");
                    return playerStats;

                default:
                    Console.WriteLine("Digite corretamente o status!");
                    stats = Console.ReadLine();
                    goto NewTry; // talvez não funcione
            }
        }

        public int[] LevelUp(int[] PlayerStats)
        {
            if(CheckLevelUp(PlayerStats[4], PlayerStats[5]) == true)
            {
                Console.WriteLine($"Você upou para o nível: {Points}, e agora pode upar um stat!");
                Console.WriteLine($"Escolha um dos status para upar: " +
                    $"HP: {PlayerStats[0]}, " +
                    $"Dano: {PlayerStats[1]}, " +
                    $"Esquiva: {PlayerStats[2]} e " +
                    $"Cura: {PlayerStats[3]}.");

                string ChooseStats = Console.ReadLine();
                ChooseStats.ToLower();

                PlayerStats[5] += PlayerStats[5]; // duplica o mínimo de exp requerido para upar.

                Console.WriteLine($"Sua experiência até o próximo nível: {PlayerStats[4]}/{PlayerStats[5]}");

                return LevelUpStats(ChooseStats, PlayerStats); // retorna os stats do player.
            }
            return PlayerStats;
        }


        //public void LevelUpPoints(int HP, int Attack, int Dodge, int Heal, int PlayerExp, int PlayerLevelUpMin)
        //{
        //    if (CheckLevelUp(PlayerExp, PlayerLevelUpMin) == true)
        //    {
        //        Console.WriteLine($"Você upou de nível, e tem agora a quantidade de pontos: {Points}");
        //        Points--;
        //        Console.WriteLine($"Escolha um dos status para upar: HP: {HP}, Dano: {Attack}, Esquiva: {Dodge} e Cura: {Heal}.");
        //        string ChooseStats = Console.ReadLine();
        //        LevelUpStats(ChooseStats, HP, Attack, Dodge, Heal);
        //    }
        //}
    }
}
