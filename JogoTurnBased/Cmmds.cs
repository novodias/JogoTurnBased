using System;

namespace JogoTurnBased
{
    public class Cmmds
    {
        public static string InsertText()
        {
            string Text = Console.ReadLine();
            if (Text == "quit")
            {
                Environment.Exit(1);
            }
            return Text;
        }

        /// <summary>
        /// Lista de comandos. (explore, combat e begin)
        /// </summary>
        /// <param name="cmmdoption"></param>
        public static void List(string cmmdoption)
        {
            switch (cmmdoption)
            {
                case "explore":
                    Console.WriteLine(MessageClass.SendMessage("ExploreCmmds", "cmmds"));
                    break;

                case "combat":
                    Console.WriteLine(MessageClass.SendMessage("CombatCmmds", "cmmds"));
                    break;

                case "begin":
                    Console.WriteLine(MessageClass.SendMessage("BeginCmmds", "cmmds"));
                    break;
            }
        }
    }
}