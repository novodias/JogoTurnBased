using System;

namespace JogoTurnBased
{
    public class Combat
    {
        private string _name { get; set; }
        private int[] _player { get; set; }

        //_player[0] = hp
        //_player[1] = damage
        //_player[2] = dodge
        //_player[3] = heal
        //_player[4] = exp
        //_player[5] = exptolevelup
        //_player[6] = maxhealth

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
        public int mExp { get; private set; }
        public void CombatStart()
        {
            Encounter statusEnc = new();
            status = 0;
            ChangeStatusBattle();

            void ChangeStatusBattle()
            {
                switch (status)
                {
                    case 0:
                        statusEnc.PlayerHPCheck = _player[0];
                        statusEnc.FinalEncounterMonster(0);
                        TurnAction();
                        break;

                    case 1:
                        statusEnc.FinalEncounterMonster(1);
                        TurnAction();
                        break;

                    case -1:
                        EndBattle(); // PLAYER MORTO
                        break;

                    default:
                        EndBattle(); // BATALHA FINALIZADA!
                        break;
                }
            }

            void TurnAction()
            {
                void Attack()
                {
                    statusEnc.MoveAttack(_player[1], _name);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _player[2], _name);
                    NewRound(statusEnc.DeathStatus());
                    ChangeStatusBattle();
                }
                void Heal()
                {
                    statusEnc.PlayerHPCheck = statusEnc.MoveHeal(_player[3], statusEnc.PlayerHPCheck, _player[6]);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _player[2], _name);
                    NewRound(statusEnc.DeathStatus());
                    ChangeStatusBattle();
                }
                void Wait()
                {
                    Console.WriteLine("Você começou a fazer um formato de T com o corpo");
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, _player[2], _name);
                    NewRound(statusEnc.DeathStatus());
                    ChangeStatusBattle();
                }

                //PlayerAct:
                string act = Console.ReadLine();
                switch (act)
                {
                    case "atacar":
                    case "attack":
                        Attack();
                        break;

                    case "curar":
                    case "heal":
                        Heal();
                        break;

                    case "esperar":
                    case "wait":
                        Wait();
                        break;

                    case "quit":
                        Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine(MessageClass.SendMessage("InvalidCommand", "combat"));
                        TurnAction();
                        break;
                }

            }

            void EndBattle()
            {
                if (statusEnc.PlayerHPCheck > 0) // Player vivo
                {
                    mExp = statusEnc.ReturnMonsterExp();
                    _player[0] = statusEnc.PlayerHPCheck;
                    Console.WriteLine(MessageClass.SendMessage("EndBattle01", "combat"));
                }
                else
                {
                    _player[0] = statusEnc.PlayerHPCheck;
                    Console.WriteLine(MessageClass.SendMessage("EndBattle02", "combat"));
                }
            }
        }

        public void NewRound(int status)
        {
            // case 1 = PLAYER DEATH // case 2 = MONSTER DEATH // case 3 = CONTINUAR
            // status = 0 (BATALHA NOVA), status = 1 (CONTINUAR BATALHA), status != 1,0 (MORTE)
            switch (status)
            {
                case 1:
                    Console.WriteLine(MessageClass.SendMessage("NewTry", "combat"));
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
