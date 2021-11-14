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
        private int LevelUpStats(string stats, int HP, int Attack, int Dodge, int Heal)
        {
            Random randomStat = new();
            int final;
            TryAgain:
            switch (stats)
            {
                case "HP":
                case "Hp":
                case "hp":
                    final = HP + randomStat.Next(0, 16);
                    Console.WriteLine($"Você upou HP, e aumentou {final}");
                    return final;

                case "DANO":
                case "Dano":
                case "dano":
                    final = Attack + randomStat.Next(0, 6);
                    Console.WriteLine($"Você upou Dano, e aumentou {final}");
                    return final;

                case "ESQUIVA":
                case "Esquiva":
                case "esquiva":
                    final = Dodge + randomStat.Next(0, 6);
                    Console.WriteLine($"Você upou Esquiva, e aumentou {final}");
                    return final;

                case "CURA":
                case "Cura":
                case "cura":
                    final = Heal + randomStat.Next(0, 6);
                    Console.WriteLine($"Você upou Cura, e aumentou {final}");
                    return final;

                default:
                    Console.WriteLine("Digite corretamente o status!");
                    goto TryAgain;
            }
        }
        /// <summary>
        /// Método em que o jogador consegue upar algum de seus status.
        /// </summary>
        /// <param name="HP"></param>
        /// <param name="Attack"></param>
        /// <param name="Dodge"></param>
        /// <param name="Heal"></param>
        /// <returns></returns>
        public void LevelUpPoints(int HP, int Attack, int Dodge, int Heal, int PlayerExp, int PlayerLevelUpMin)
        {
            if (CheckLevelUp(PlayerExp, PlayerLevelUpMin) == true)
            {
                Console.WriteLine($"Você upou de nível, e tem agora a quantidade de pontos: {Points}");
                Console.WriteLine($"Escolha um dos status para upar: HP: {HP}, Dano: {Attack}, Esquiva: {Dodge} e Cura: {Heal}.");
                string ChooseStats = Console.ReadLine();
                LevelUpStats(ChooseStats, HP, Attack, Dodge, Heal);
                Points--;
            }
        }
    }
}
