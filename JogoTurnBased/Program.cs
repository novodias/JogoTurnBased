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
            PlayerStats playerStats = new();

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
            CombatNow.GetStatsBeforeCombat(playerName.ReturnPlayerName(), playerStats.PlayerHP, playerStats.PlayerDamage, playerStats.PlayerDodge, playerStats.PlayerHeal, playerStats.PlayerEXP, playerStats.PlayerEXPtoLevelUP);
            CombatNow.CombatStart();
            CombatNow.ReturnStatsAfterCombat(playerStats.PlayerHP, playerStats.PlayerDamage, playerStats.PlayerDodge, playerStats.PlayerHeal, playerStats.PlayerEXP);
        }
    }
}
