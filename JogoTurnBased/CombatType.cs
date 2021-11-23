using System;

namespace JogoTurnBased
{
    public class CombatType
    {
        public int PlayerHP {get; set;}
        public int MonstersHP {get; set;}
        Random RandomMiss = new Random();

        // TODO: Um method void que retorna valor aleatório 
        private int RandomNumber(int number1, int number2)
        {
            return RandomMiss.Next(number1, number2);
        }
        //

        /// <summary>
        /// Retorna o HP depois do ataque
        /// </summary>
        /// <param name="HP"></param>
        /// <param name="Attack"></param>
        /// <returns></returns>
        public int HPCheck(int HP, int Attack)
        {
            int FinalHP = HP - Attack;
            return FinalHP;
        }

        // ATAQUE
        /// <summary>
        /// Pega o valor definido do status do Player/Monster e retorna entre (Ataque - 4 a Ataque + 1) 
        /// </summary>
        /// <param name="Attack"></param>
        /// <param name="infoAttacker"></param>
        /// <returns></returns>
        public int Attack(int Attack, string infoAttacker)
        {
            int CriticalDMG = RandomMiss.Next(Attack - 4, Attack + 1);
            if(CriticalDMG == Attack)
            {
                int DamageInfo = CriticalDMG * 2;
                Console.WriteLine(infoAttacker + " acertou um dano crítico: " + DamageInfo);
                return DamageInfo;
            }
            else 
            {
                int DamageInfo = RandomMiss.Next(Attack - 4, Attack + 1);
                if (DamageInfo <= 0)
                {
                    Console.WriteLine(infoAttacker + " deu: 1");
                    return 1;
                }
                Console.WriteLine(infoAttacker + " deu: " + DamageInfo);
                return DamageInfo;
            }
        }

        public int Dodge(int Attack, int infoDodge, string infoAttacker)
        {
            int ChanceToDodge = RandomMiss.Next(1, 101);
            if(ChanceToDodge <= infoDodge)
            {
                Attack = 0;
                Console.WriteLine(infoAttacker + " desviou do ataque!");
                return Attack;
            }
            return Attack;
        }

        // HEAL
        /// <summary>
        /// Cria um numéro aleatório de 1 a HealStat + 1, se for menor que 3 ou igual, cura. Caso contrário, retornará 0.
        /// </summary>
        /// <param name="HP"></param>
        /// <param name="HealStat"></param>
        /// <returns></returns>
        public int Heal(int HealStat, int HP, int MaxHP)
        {
            int MissRnd = RandomMiss.Next(0, 11);
            if ( MissRnd <= 4 )
            {
                int cura = HealStat + HP;
                if (cura > MaxHP)
                {
                    int HPcure = MaxHP - HP;
                    Console.WriteLine($"Você curou: {HPcure}");
                    return HP + HPcure;
                }
                else
                {
                    Console.WriteLine($"Você curou: {HealStat}");
                    return HealStat + HP;
                }
            }
            Console.WriteLine("Você falhou a cura!");
            return HP;
        }

        // CHECAR HP DO PLAYER E MONSTRO
        private bool IsPlayerAlive()
        {
            bool IsAlive = PlayerHP <= 0 ? true : false;
            return IsAlive;
        }
        private bool IsMonsterAlive()
        {
            bool IsAlive = MonstersHP <= 0 ? true : false;
            return IsAlive;
        }

        // CHECAR SE ALGUM DOS DOIS ESTA MORTO
        public int CheckDeath()
        {
            if(IsPlayerAlive() == true && IsMonsterAlive() == false)
            {
                return 1;
            }
            else if (IsMonsterAlive() == true && IsPlayerAlive() == false)
            {
                return 2;
            }
            return 3;
        }
    }
}