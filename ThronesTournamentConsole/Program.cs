using BusinessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThronesTournamentConsole
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        /*
        static void Main(string[] args)
        {
            ThronesTournamentManager t = new ThronesTournamentManager();
            List<Character> ch = new List<Character>();
            List<House> ho = new List<House>();
            List<Territory> te = new List<Territory>();

            int num = 0;
            while (num != 5)
            {
                System.Console.WriteLine("~~~~~~~~~~~~~ Menu ~~~~~~~~~~~~~");
                System.Console.WriteLine("Entrer 1 pour Afficher la liste des maisons");
                System.Console.WriteLine("Entrer 2 pour Afficher la liste des maisons qui contiennent plus de 200 unités.");
                System.Console.WriteLine("Entrer 3 pour Afficher la liste des personnages qui ont plus de 3 points de forces et plus de 50 points de vie.");
                System.Console.WriteLine("Entrer 4 pour Afficher la liste des terrains.");
                System.Console.WriteLine("Entrer 5 pour sortir");
                string nbr=System.Console.ReadLine();
                int.TryParse(nbr,out num);
                if (num == 1)
                {
                    System.Console.WriteLine("le numero est egal à 1");
                    ho = t.GetAllHouses();
                    foreach(House houses in ho)
                    {
                        System.Console.WriteLine(houses.ToString());
                    }
                }
                else if (num == 2)
                {
                    System.Console.WriteLine("le numero est egal à 2");
                    ho = t.GetHousesUnities();
                    foreach (House houses in ho)
                    {
                        System.Console.WriteLine(houses.ToString());
                    }
                }
                else if(num == 3)
                {
                    System.Console.WriteLine("le numero est egal à 3");
                    ch = t.GetSomeCharacter();
                    foreach (Character characters in ch)
                    {
                        System.Console.WriteLine(characters.ToString());
                    }
                }
                else if(num == 4)
                {
                    System.Console.WriteLine("le numero est egal à 4");
                    te = t.GetTerritorys();
                    foreach (Territory territorys in te)
                    {
                        System.Console.WriteLine(territorys.ToString());
                    }
                }
            }

        }*/
    }
}
