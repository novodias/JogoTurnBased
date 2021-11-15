using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    public class Combat : Experience
    {
        private string _name { get; set; } 
        private int _hp { get; set; }
        private int _damage { get; set; }
        private int _dodge { get; set; }
        private int _heal { get; set; }
        private int _exp { get; set; }
        private int _expToLevelUP { get; set; }
        public void GetStatsBeforeCombat(string PlayerName, int PlayerHP, int PlayerDamage, int PlayerDodge, int PlayerHeal, int PlayerEXP, int PlayerEXPmin)
        {
            _name = PlayerName;
            _hp = PlayerHP;
            _damage = PlayerDamage;
            _dodge = PlayerDodge;
            _heal = PlayerHeal;
            _exp = PlayerEXP;
            _expToLevelUP = PlayerEXPmin;
        }
        public void ReturnStatsAfterCombat(int PlayerHP, int PlayerDamage, int PlayerDodge, int PlayerHeal, int PlayerEXP)
        {
            PlayerHP = _hp;
            PlayerDamage = _damage;
            PlayerDodge = _dodge;
            PlayerHeal = _heal;
            PlayerEXP = _exp;
        }
        /// <summary>
        /// status = 0 (BATALHA NOVA), status = 1 (CONTINUAR BATALHA), status != 1,0 (MORTE)
        /// </summary>
        int status { get; set; } = 0;
        public void CombatStart()
        {
            Encounter statusEnc = new();

            statusEnc.FinalEncounterMonster(0);

            NewTurn:
            if (this.status == 0)
            {
                statusEnc.PlayerHPCheck = _hp;
            }
            else if (this.status == 1)
            {
                statusEnc.FinalEncounterMonster(1);
            }
            else goto EndBattle;

            ActionClass action = new();

            PlayerAct:
            string act = Console.ReadLine();
            action.GetAction(act);

            switch (action.ReturnAction())
            {
                case "atacar":
                    statusEnc.MoveAttack(_damage, _name);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _dodge, _name);
                    NewRound(statusEnc.DeathStatus());
                    goto NewTurn;

                case "curar":
                    statusEnc.PlayerHPCheck = MaxHeal(statusEnc.MoveHeal(_heal), statusEnc.PlayerHPCheck, _hp);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _dodge, _name);
                    NewRound(statusEnc.DeathStatus());
                    goto NewTurn;

                case "esperar":
                    Console.WriteLine("Você começou a fazer um formato de T com o corpo");
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _dodge, _name);
                    NewRound(statusEnc.DeathStatus());
                    goto NewTurn;

                case "quit":
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Comando inválido, tente novamente!");
                    goto PlayerAct;
            }
            EndBattle:
            Console.WriteLine("Batalha finalizada.");
            _exp = GainEXP(_exp, statusEnc.ReturnMonsterExp());
            LevelUpPoints(_hp, _damage, _dodge, _heal, _exp, _expToLevelUP);
            Console.WriteLine($"Seu experiência no total: {_exp}");
        }
        public void NewRound(int status)
        {
            // case 1 = PLAYER DEATH // case 2 = MONSTER DEATH // case 3 = CONTINUAR
            switch (status)
            {
                case 1:
                    Console.WriteLine("Deseja tentar novamente? (y/n)");
                    char TryAgain = Console.ReadKey().KeyChar;
                    if (TryAgain == 'n')
                    {
                        Environment.Exit(1);
                    }
                    break;

                case 2:
                    this.status = -1;
                    break;

                case 3:
                    this.status = 1;
                    break;
            }
        }
        public int MaxHeal(int heal, int hpcheck, int maxhp)
        {
            int cura = heal + hpcheck;
            if (cura > maxhp)
            {
                int HPcure = maxhp - hpcheck;
                return hpcheck + HPcure;
            }
            else
            {
                return heal + hpcheck;
            }
        }
    }
}
