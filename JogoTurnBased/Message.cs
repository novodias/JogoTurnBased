using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    public class MessageClass
    {
        public void InitialMessage(string playerName)
        {
            Console.WriteLine("Olá " + playerName + ", seja bem-vindo ao jogo Turn Based, se prepare para lutar!");
            Cmmds.List("begin");
        }
        public void MoveMessage(string playerName)
        {
            Console.WriteLine(playerName + " começou a andar...");
        }
    }
}