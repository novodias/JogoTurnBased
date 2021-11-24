using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    partial class MessageClass
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

        private static string language { get; set; }
        public static void SelectLanguage()
        {
            Console.WriteLine("Select the language: PT, EN.");
            language = Console.ReadLine();
            language.ToLower();
            Messages();
        }

        private static string[] ListMessage()
        {
            if (language == "pt")
            {
                string[] ptmessages =
                {
                    #region Frases
                    "Você encontrou uma dungeon!",
                    "Explorando a dungeon...",
                    "Você encontrou nada.",
                    "Big Chungus",
                    "Thanos em T pose",
                    "Sus Amogus dourado",
                    $"Você achou uma poção de HP! bebeu, e recuperou {0} de HP",
                    "Você achou uma poção de HP! bebeu, e recuperou 5 de HP",
                    $"Você encontrou um {0}! e ganhou +{1} de exp",
                    $"Você upou o HP máximo, e aumentou para {0}",
                    $"Você upou Dano, e aumentou para {0}",
                    $"Você upou Esquiva, e aumentou para {0}",
                    $"Você upou Cura, e aumentou para {0}",
                    "Digite corretamente o status!",
                    $"Você upou para o nível: {0}, e agora pode upar um stat!",
                    $"Escolha um dos status para upar: HP máximo: {0}, Dano: {1}, Esquiva: {2} e Cura: {3}.",
                    $"Sua experiência até o próximo nível: {0}/{1}",
                    "Digite explorar para continuar\nDigite quit para sair do jogo",
                    "Digite atacar para dar dano no monstro.\nDigite esperar para pular o turno.\nDigite curar para si curar.\nDigite quit para sair do jogo.",
                    "Digite andar para si aventurar!\nDigite quit para sair.",
                    "Comando inválido, tente novamente!",
                    "Batalha finalizada",
                    "Batalha finalizada, você morreu.",
                    "Deseja tentar novamente? (y/n)",
                    $"{0} acertou um dano crítico: {1}",
                    $"{0} deu: 1",
                    $"{0} deu: {1}",
                    $"{0} desviou do ataque!",
                    $"Você curou: {0}",
                    $"Você falhou a cura",
                    $"Seu HP: {0}",
                    $"HP do {0}: {1}",
                    "O que pretende fazer?",
                    "Você morreu!",
                    "Você derrotou o monstro",
                    "Insira o seu nome: "
                    #endregion
                };
                return ptmessages;
            }
            else
            {
                string[] enmessages =
                {
                    "You found a dungeon!",
                    "Exploring the dungeon...",
                    "You found nothing.",
                    "Big Chungus",
                    "Thanos in T pose",
                    "Golden Sus Amogus",
                    String.Format("You found a hp potion! Drank, and recovered {0} HP"),
                    "You found a hp potion! Drank, and recovered 5 HP"
                };
                return enmessages;
            }
        }

        private static void Messages()
        {
            void MessageCheck(int index, string message)
            {
                messages.ElementAt(index).Message = message;
            }

            string[] selected = ListMessage();

            for (int i = 0; i < selected.Length; i++)
            {
                MessageCheck(i, selected[i]);
            }
        }

        public static string SendMessage(string name, string type)
        {
            var Search = from s in messages where s.Name == name && s.Type == type select s;
            foreach (var sendmessage in Search)
            {
                return sendmessage.Message;
            }
            return null;
        }
    }
}