using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JOGO TURN BASED");

            Start:
            PlayerStats playerStats = new PlayerStats();

            Player playerClient = new Player();
            playerStats.PlayerName = playerClient.InsertPName("");
            Console.WriteLine("Seu HP: " + playerStats.PlayerHP );

            MessageClass Message = new MessageClass();
            Message.InitialMessage(playerStats.PlayerName);

            Cmmds commands = new Cmmds();
            playerClient.Action = commands.InsertText("");

            Message.MoveMessage(playerStats.PlayerName);

            Encontrar:
            playerClient.FindMonsters();
            Encounter statusEnc = new Encounter();
            statusEnc.FinalEncounterMonster(0);

            int status = 0;
            NewTurn:
            if(status == 0)
            {
                statusEnc.PlayerHPCheck = playerStats.PlayerHP;
            }
            else 
            {
                statusEnc.FinalEncounterMonster(1);
            }

            Encontro:
            playerClient.Action = commands.InsertText("");

            switch (playerClient.Action)
            {
                case "atacar":
                    statusEnc.MoveAttack(playerStats.PlayerDamage, playerStats.PlayerName);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, playerStats.PlayerDodge, playerStats.PlayerName);
                    switch (statusEnc.DeathStatus())
                    {
                        case 1:
                            Console.WriteLine("Deseja tentar novamente? (y/n");
                            char TryAgain = Console.ReadKey().KeyChar;
                            if (TryAgain == 'n')
                            {
                                Environment.Exit(1);
                            }
                            goto Start;
                        
                        case 2:
                            goto Encontrar;
                        
                        case 3:
                            status = 1;
                            goto NewTurn;
                        
                        default:
                            Console.WriteLine("Algo de errado aconteceu bruh");
                            Console.ReadKey();
                            break;
                    }
                    break;

                case "curar":
                    statusEnc.MoveHeal(statusEnc.PlayerHPCheck, playerStats.PlayerHeal);
                    statusEnc.MonsterAttack(statusEnc.PlayerHPCheck, playerStats.PlayerDodge, playerStats.PlayerName);
                    switch (statusEnc.DeathStatus())
                    {
                        case 1:
                            Console.WriteLine("Deseja tentar novamente? (y/n)");
                            char TryAgain = Console.ReadKey().KeyChar;
                            if (TryAgain == 'n')
                            {
                                Environment.Exit(1);
                            }
                            goto Start;
                        
                        case 2:
                            playerClient.FindMonsters();
                            break;
                        
                        case 3:
                            status = 1;
                            goto NewTurn;
                        
                        default:
                            Console.WriteLine("Algo de errado aconteceu bruh");
                            Console.ReadKey();
                            break;
                    }
                    break;

                case "quit":
                    Environment.Exit(1);
                    break;

                default:
                    Console.WriteLine("Comando desconhecido, tente novamente!");
                    goto Encontro;
            }
            
        }
    }
}
