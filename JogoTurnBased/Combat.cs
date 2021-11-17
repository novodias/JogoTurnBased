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
        private int[] _player { get; set; }
        // private int _hp { get; set; }
        // private int _damage { get; set; }
        // private int _dodge { get; set; }
        // private int _heal { get; set; }
        // private int _exp { get; set; }
        // private int _expToLevelUP { get; set; }

        public void GetStatsBeforeCombat(string PlayerName, int[] PlayerStats)
        {
            _name = PlayerName;
            _player = PlayerStats;

            // TESTES
            //_player = new int[] { hp, damage, dodge, heal, exp, exptolevelup };
            //Console.Write("Stats Array: ");
            //foreach (var item in _player)
            //{
            //    Console.Write("{0} ", item);
            //}
            //Console.WriteLine($"\nTESTE HP n2: {_player[0]}");
            //Console.WriteLine($"\nTESTE DANO n2: {_player[1]}");
            //Console.WriteLine($"\nTESTE DODGE n2: {_player[2]}");
            //Console.WriteLine($"\nTESTE HEAL n2: {_player[3]}");
            //Console.WriteLine($"\nTESTE EXP n2: {_player[4]}");
            //Console.WriteLine($"\nTESTE EXP PRA UPAR n2: {_player[5]}");
        }
        public int[] ReturnStatsAfterCombat()
        { 
            return _player;
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
                statusEnc.PlayerHPCheck = _player[0];
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
                    statusEnc.MoveAttack(_player[1], _name);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _player[2], _name);
                    NewRound(statusEnc.DeathStatus());
                    goto NewTurn;

                case "curar":
                    statusEnc.PlayerHPCheck = MaxHeal(statusEnc.MoveHeal(_player[3]), statusEnc.PlayerHPCheck, _player[0]);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _player[2], _name);
                    NewRound(statusEnc.DeathStatus());
                    goto NewTurn;

                case "esperar":
                    Console.WriteLine("Você começou a fazer um formato de T com o corpo");
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _player[2], _name);
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
            _player[4] = GainEXP(_player[4], statusEnc.ReturnMonsterExp());
            LevelUpPoints(_player[0], _player[1], _player[2], _player[3], _player[4], _player[5]);
            Console.WriteLine($"Seu experiência no total: {_player[4]}");
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
