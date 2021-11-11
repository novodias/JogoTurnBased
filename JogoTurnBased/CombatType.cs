using System;

namespace JogoTurnBased
{
    public class CombatType
    {
        public int PlayerHP {get; set;}
        public int MonstersHP {get; set;}
        public int FinalHP {get; private set;}
        private int CriticalDMG {get; set;}

        Random RandomMiss = new Random();

        /// <summary>
        /// Retorna o HP depois do ataque
        /// </summary>
        /// <param name="HP"></param>
        /// <param name="Attack"></param>
        /// <returns></returns>
        public int HPCheck(int HP, int Attack)
        {
            FinalHP = HP - Attack;
            return FinalHP;
        }

        // ATAQUE
        public int Attack(int Attack, string infoAttacker)
        {
            CriticalDMG = RandomMiss.Next(1, Attack + 1);
            if(CriticalDMG == Attack)
            {
                int DamageInfo = CriticalDMG * 2;
                Console.WriteLine(infoAttacker + " acertou um dano crítico: " + DamageInfo);
                return DamageInfo;
            }
            else 
            {
                int DamageInfo = RandomMiss.Next(0, Attack + 1);
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
        /// Retona o valor curado, chance de 3/5 de ser retornar 0.
        /// </summary>
        /// <param name="HP"></param>
        /// <param name="Heal"></param>
        /// <returns></returns>
        public int Heal(int HP, int Heal)
        {
            int MissRnd = RandomMiss.Next(1,5);
            if (MissRnd >= 3)
            {
                Heal = 0;
            }
            FinalHP = HP + Heal;
            return FinalHP;
        }

        // CHECAR HP DO PLAYER E MONSTRO
        private bool CheckPlayer()
        {
            if (PlayerHP <= 0)
            {
                return true;
            }
            return false;
        }
        private bool CheckMonster()
        {
            if (MonstersHP <= 0)
            {
                return true;
            }
            return false;
        }

        // CHECAR SE ALGUM DOS DOIS ESTA MORTO
        public int CheckDeath()
        {
            if(CheckPlayer() == true && CheckMonster() == false)
            {
                return 1;
            }
            else if (CheckMonster() == true && CheckPlayer() == false)
            {
                return 2;
            }
            return 3;
        }
    }
}