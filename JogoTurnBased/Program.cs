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

            int[] playerStats = new int[6] { player.HP, player.Damage, player.Dodge, player.Heal, player.EXP, player.EXPtoLevelUP};

            Explore explore = new();
            explore.FoundDungeon(playerName.ReturnPlayerName(), playerStats);

        }
    }
}
