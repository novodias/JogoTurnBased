﻿using System;

namespace JogoTurnBased
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JOGO TURN BASED");

            MessageClass.SelectLanguage();

            Start:
            PlayerStatsName playerName = new();
            Player playerClient = new();
            PlayerStats player = new();

            playerName.GetPlayerName(playerClient.InsertPName());

            MessageClass Message = new();
            Message.InitialMessage(playerName.ReturnPlayerName());

            ActionClass action = new();
            action.GetAction(Cmmds.InsertText());

            Message.MoveMessage(playerName.ReturnPlayerName());

            int[] playerStats = new int[7] 
            { 
                player.HP, 
                player.Damage,
                player.Dodge, 
                player.Heal, 
                player.EXP, 
                player.EXPtoLevelUP, 
                player.MaxHealth
            };

            Explore explore = new();
            explore.FoundDungeon(playerName.ReturnPlayerName(), playerStats);

            goto Start;
        }
    }
}
