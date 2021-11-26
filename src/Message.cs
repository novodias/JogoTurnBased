using System;
using System.Linq;
using System.IO;

namespace JogoTurnBased
{
    partial class MessageClass
    {
        public void InitialMessage(string playerName)
        {
            Console.WriteLine(SendMessage("Hello", "message"), playerName);
            Cmmds.List("begin");
        }
        public void MoveMessage(string playerName)
        {
            Console.WriteLine(SendMessage("Walk", "message"), playerName);
        }

        private static string _language { get; set; }
        private static string[] _languageMessages { get; set; }
        public static void SelectLanguage()
        {
            Console.WriteLine("Select the language: PT, EN.");
            _language = Console.ReadLine();
            _language.ToLower();
            Messages();
        }

        private static string[] ReadTextFileLanguage()
        {
            if (_language == "pt")
            {
                return _languageMessages = File.ReadAllLines("language-pt.txt");
            }
            else
            {
                return _languageMessages = File.ReadAllLines("language-en.txt");
            }
        }

        private static void Messages()
        {
            void MessageCheck(int index, string message)
            {
                messages.ElementAt(index).Message = message;
            }

            string[] selected = ReadTextFileLanguage();

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