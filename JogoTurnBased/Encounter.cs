using System;

namespace JogoTurnBased
{
    partial class Encounter : Combat
    {
        MonsterData MonsterInfo = new();
        private void MonsterType(string monster)
        {
            switch (monster)
            {
                case "troll":
                    MonsterInfo.TrollMonster();
                    break;
                case "slime":
                    MonsterInfo.SlimeMonster();
                    break;
            }
        }
        private void SelectMonster()
        {
            Random RandomMonster = new Random();
            if (RandomMonster.Next(1, 11) <= 3)
            {
                MonsterType("troll");
            }
            else
            {
                MonsterType("slime");
            }
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
        private void EncounterMonster(int PlayerHPCheck)
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
            int bruh;
            int damage = Dodge(Attack(PlayerDamageStats, PlayerName), (int)MonsterInfo.InfoMonsterArray("dodge"), (string)MonsterInfo.InfoMonsterArray("name"));
            bruh = HPCheck(MonstersHP, damage);
            return MonstersHP = bruh;
        }
        public int MoveHeal(int PlayerHealth, int PlayerHealStats)
        {
            int heal = Heal(PlayerHealth, PlayerHealStats);
            Console.WriteLine("Você curou: " + heal);
            return PlayerHPCheck = PlayerHP = heal;
        }
        public int MonsterAttack(int PlayerHealth, int PlayerDodge, string PlayerName)
        {
            int damage = Dodge(Attack((int)MonsterInfo.InfoMonsterArray("damage"), (string)MonsterInfo.InfoMonsterArray("name")), PlayerDodge, PlayerName);
            PlayerHP = HPCheck(PlayerHealth, damage);
            return PlayerHPCheck = PlayerHP;
        }
    }
}