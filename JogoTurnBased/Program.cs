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

            playerName.GetPlayerName(playerClient.InsertPName());

            MessageClass Message = new();
            Message.InitialMessage(playerName.ReturnPlayerName());

            Cmmds commands = new();
            ActionClass action = new();
            action.GetAction(commands.InsertText(""));

            Message.MoveMessage(playerName.ReturnPlayerName());

            Encontrar:
            playerClient.FindMonsters();
            Combat CombatNow = new();
            CombatNow.CombatStart(playerName.ReturnPlayerName());
        }
    }
}
