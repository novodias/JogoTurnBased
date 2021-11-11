using System;

namespace JogoTurnBased
{
    public class Cmmds
    {
        public string InsertText(string Text)
        {
            Text = Console.ReadLine();
            if (Text == "quit")
            {
                Environment.Exit(1);
            }
            return Text;
        }
        public void cmmds()
        {
            Console.WriteLine("Digite andar para si aventurar!");
            Console.WriteLine("Digite quit para sair.");
        }
        public void cmmdsInCombat()
        {
            Console.WriteLine("Digite atacar para dar dano no monstro.");
            Console.WriteLine("Digite esperar para pular o turno.");
            Console.WriteLine("Digite curar para si curar.");
            Console.WriteLine("Digite quit para sair do jogo.");
        }
    }
}