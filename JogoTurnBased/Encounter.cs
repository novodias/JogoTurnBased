using System;

namespace JogoTurnBased
{

    partial class Encounter : CombatType
    {
        MonsterData MonsterInfo = new();
        private void SelectMonster()
        {
            Random RandomMonster = new Random();
            if (RandomMonster.Next(1, 11) <= 3)
            {
                MonsterInfo.TrollMonster();
            }
            else
            {
                MonsterInfo.SlimeMonster();
            }
        }
        public int ReturnMonsterExp()
        {
            return (int)MonsterInfo.InfoMonsterArray("exp");
        }
        Cmmds commands = new Cmmds();

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
            commands.cmmdsInCombat();
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
        public int MoveHeal(int PlayerHealStats)
        {
            int heal = Heal(PlayerHealStats);
            Console.WriteLine("Você curou: " + heal);
            return heal;
        }
        public int MonsterAttack(int PlayerHealth, int PlayerDodge, string PlayerName)
        {
            int damage = Dodge(Attack((int)MonsterInfo.InfoMonsterArray("damage"), (string)MonsterInfo.InfoMonsterArray("name")), PlayerDodge, PlayerName);
            PlayerHP = HPCheck(PlayerHealth, damage);
            return PlayerHPCheck = PlayerHP;
        }
    }
}