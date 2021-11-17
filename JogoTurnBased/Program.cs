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
            PlayerStatsName playerName = new();
            Player playerClient = new();
            PlayerStats player = new();

            playerName.GetPlayerName(playerClient.InsertPName());

            MessageClass Message = new();
            Message.InitialMessage(playerName.ReturnPlayerName());

            Cmmds commands = new();
            ActionClass action = new();
            action.GetAction(commands.InsertText(""));

            Message.MoveMessage(playerName.ReturnPlayerName());
            Combat CombatNow = new();

            int[] playerStats = new int[6] { player.HP, player.Damage, player.Dodge, player.Heal, player.EXP, player.EXPtoLevelUP};

            Encontrar:
            playerClient.FindMonsters();
            CombatNow.GetStatsBeforeCombat(playerName.ReturnPlayerName(), playerStats);
            CombatNow.CombatStart();
            playerStats = CombatNow.ReturnStatsAfterCombat();
            Console.WriteLine($"PROGRAM HP: {playerStats[0]}");
            if (playerStats[0] > 0)
            {
                goto Encontrar;
            }
            else 
            { 
                goto Start;
            }
        }
    }
}
