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
                    Console.WriteLine
                        ("Digite explorar para continuar\n" +
                        "Digite quit para sair do jogo");
                    break;

                case "combat":
                    Console.WriteLine
                        ("Digite atacar para dar dano no monstro.\n" +
                        "Digite esperar para pular o turno.\n" +
                        "Digite curar para si curar.\n" +
                        "Digite quit para sair do jogo.");
                    break;

                case "begin":
                    Console.WriteLine
                        ("Digite andar para si aventurar!\n" +
                        "Digite quit para sair.");
                    break;
            }
        }
    }
}