using System;

namespace JogoTurnBased
{
    public class Player
    {
        public string InsertPName()
        {
            string name;
            Console.Write(MessageClass.SendMessage("InsertName", "player"));
            name = Console.ReadLine();
            return name;
        } 
    }
}