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

        //_player[0] = hp
        //_player[1] = damage
        //_player[2] = dodge
        //_player[3] = heal
        //_player[4] = exp
        //_player[5] = exptolevelup

        public void GetStatsBeforeCombat(string PlayerName, int[] PlayerStats)
        {
            _name = PlayerName;
            _player = PlayerStats;
        }
        public int[] ReturnStatsAfterCombat()
        { 
            return _player;
        }
        /// <summary>
        /// status = 0 (BATALHA NOVA), status = 1 (CONTINUAR BATALHA), status != 1,0 (MORTE)
        /// </summary>
        public int status { get; private set; } = 0;
        public void CombatStart()
        {
            Encounter statusEnc = new();
            this.status = 0;
            NewTurn:
            if (this.status == 0)
            {
                statusEnc.PlayerHPCheck = _player[0];
                statusEnc.FinalEncounterMonster(0);
            }
            else if (this.status == 1)
            {
                statusEnc.FinalEncounterMonster(1);
            }
            else if ( this.status == -1 && statusEnc.PlayerHPCheck <= 0 )
            {
                _player[0] = statusEnc.PlayerHPCheck;
                goto PlayerDeath;
            }
            else 
            { 
                goto EndBattle; 
            }

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
                    statusEnc.PlayerHPCheck = statusEnc.MoveHeal(_player[3], statusEnc.PlayerHPCheck, _player[0]);
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
            MonsterEXP(statusEnc.ReturnMonsterExp());
            _player[0] = statusEnc.PlayerHPCheck;
            PlayerDeath:
            Console.WriteLine("Batalha finalizada.");
        }

        public int mExp { get; private set; }

        private void MonsterEXP(int getExp)
        {
            mExp = getExp;
        }

        public void NewRound(int status)
        {
            // case 1 = PLAYER DEATH // case 2 = MONSTER DEATH // case 3 = CONTINUAR
            // status = 0 (BATALHA NOVA), status = 1 (CONTINUAR BATALHA), status != 1,0 (MORTE)
            switch (status)
            {
                case 1:
                    Console.WriteLine("Deseja tentar novamente? (y/n)");
                    char TryAgain = Console.ReadKey().KeyChar;
                    if (TryAgain == 'n')
                    {
                        Environment.Exit(1);
                    }
                    this.status = -1;
                    break;

                case 2:
                    this.status = -1;
                    break;

                case 3:
                    this.status = 1;
                    break;
            }
        }

    }
}
