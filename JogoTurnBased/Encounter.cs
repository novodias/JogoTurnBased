using System;
using System.Collections.Generic;

namespace JogoTurnBased
{

    partial class Encounter : CombatType
    {
        MonsterData MonsterInfo = new();

        #region Encounter
        private void SelectMonster()
        {
            Random RandomMonster = new Random();
            int RndMonsterSelect = RandomMonster.Next(0, 11);
            if (RndMonsterSelect == 1)
            {
                MonsterInfo.TrollMonster();
            }
            else if(RndMonsterSelect <= 7 && RndMonsterSelect != 1)
            {
                MonsterInfo.SlimeMonster();
            }
            else
            {
                MonsterInfo.GoblinMonster();
            }
        }
        public int ReturnMonsterExp()
        {
            return (int)MonsterInfo.InfoMonsterArray("exp");
        }

        public int FinalEncounterMonster(int num)
        {
            if (num == 0)
            {
                SelectMonster();
                InitialEncounterMonster(PlayerHPCheck);
                return 0;
            }
            else if (num == 1)
            {
                EncounterMonster(PlayerHPCheck);
                return 1;
            }
            return 2;
        }
        private void InitialEncounterMonster(int PlayerHPCheck)
        {
            MonstersHP = (int)MonsterInfo.InfoMonsterArray("hp");
            EncounterMonster(PlayerHPCheck);
        }
        public void EncounterMonster(int PlayerHPCheck)
        {
            Console.WriteLine("Seu HP: " + PlayerHPCheck);
            Console.WriteLine("HP do " + (string)MonsterInfo.InfoMonsterArray("name") + ": " + MonstersHP);
            Console.WriteLine("O que pretende fazer?");
            Cmmds.List("combat");
        }
        public int DeathStatus()
        {
            if(CheckDeath() == 1)
            {
                Console.WriteLine("Você morreu!");
                return 1;
            }
            else if(CheckDeath() == 2)
            {
                Console.WriteLine("Você derrotou o monstro!");
                return 2;
            }
            else return 3;
        }
        public int MoveAttack(int PlayerDamageStats, string PlayerName)
        {
            int damage = Dodge(Attack(PlayerDamageStats, PlayerName), (int)MonsterInfo.InfoMonsterArray("dodge"), (string)MonsterInfo.InfoMonsterArray("name"));
            return MonstersHP = HPCheck(MonstersHP, damage);
        }
        public int MoveHeal(int PlayerHealStats, int PlayerHealth, int PlayerMaxHealth)
        {
            int heal = Heal(PlayerHealStats, PlayerHealth, PlayerMaxHealth);
            return heal;
        }
        public int MonsterAttack(int PlayerHealth, int PlayerDodge, string PlayerName)
        {
            int damage = Dodge(Attack((int)MonsterInfo.InfoMonsterArray("damage"), (string)MonsterInfo.InfoMonsterArray("name")), PlayerDodge, PlayerName);
            PlayerHP = HPCheck(PlayerHealth, damage);
            return PlayerHPCheck = PlayerHP;
        }
        #endregion
    }
}