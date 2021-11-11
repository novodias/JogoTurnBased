using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    public class Combat
    {
        private string _name { get; set; } 
        /// <summary>
        /// status = 0 (BATALHA NOVA), status = 1 (CONTINUAR BATALHA), status != 1,0 (MORTE)
        /// </summary>
        int status { get; set; } = 0;
        public void CombatStart(string name)
        {
            PlayerStats playerStats = new();
            Encounter statusEnc = new();

            _name = name;

            statusEnc.FinalEncounterMonster(0);

            NewTurn:
            if (this.status == 0)
            {
                statusEnc.PlayerHPCheck = playerStats.PlayerHP;
            }
            else if (this.status == 1)
            {
                statusEnc.FinalEncounterMonster(1);
            }
            else goto EndBattle;

            ActionClass action = new();
            string act = Console.ReadLine();
            action.GetAction(act);

            PlayerAct:
            switch (action.ReturnAction())
            {
                case "atacar":
                    statusEnc.MoveAttack(playerStats.PlayerDamage, _name);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, playerStats.PlayerDodge, _name);
                    NewRound(statusEnc.DeathStatus());
                    goto NewTurn;

                case "curar":
                    statusEnc.MoveHeal(statusEnc.PlayerHPCheck, playerStats.PlayerHeal);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, playerStats.PlayerDodge, _name);
                    NewRound(statusEnc.DeathStatus());
                    goto NewTurn;

                case "esperar":
                    Console.WriteLine("Você começou a fazer um formato de T com o corpo");
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, playerStats.PlayerDodge, _name);
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
        }
        public void NewRound(int status)
        {
            // 1 = PLAYER DEATH // 2 = MONSTER DEATH // 3 = CONTINUAR
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
    }
}
