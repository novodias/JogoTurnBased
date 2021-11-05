using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    public class Player
    {
        Random RandomNumber = new Random();
        public string Action {get; set;}
        public string InsertPName(string name)
        {
            Console.Write("Insira o seu nome: ");
            name = Console.ReadLine();
            return name;
        }

        private bool bFindMonster()
        {
            int RandomEncounter = RandomNumber.Next(1, 10);
            if(RandomEncounter >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FindMonsters()
        {
            if(bFindMonster() == true)
            {
                Console.WriteLine("Você encontrou um monstro!");
            }
            else
            {
                Console.WriteLine("Você encontrou nada para batalhar, continuar andando?");
                string Continue = Console.ReadLine();
                if (Continue == "andar")
                {
                    FindMonsters();
                }
            }
        }
        
    }
}