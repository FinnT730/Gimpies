using System;
using System.Collections;
using System.Collections.Generic;

namespace Gimpies
{
    partial class Program
    {
        public struct schoen
        {
            string merk;
            string type;
            int maat;
            string kleur;
            int aantal;
            float prijs;
        }

        public static void print(object obj)
        {
            Console.WriteLine(obj);
        }

        public static string cread()
        {
            return Console.ReadLine();
        }
        public static void clear()
        {
            Console.Clear();
        }
        
        static void Main(string[] args)
        {

            List<schoen> schoenen = new List<schoen>();
            
            int loginTries = 3;

            for (int i = 1; i <= loginTries; i++)
            {
                print("Gebruikers naam:");
                string name = Console.ReadLine();
                
                print("Wachtwoord:");
                string password = Console.ReadLine();


                if ((name == "Inkoop" && password == "Gimpies_Inkoop") || name == "admin" && password == "admin")
                {
                    goto menu;
                }
                else
                {
                    clear();
                    print($"Probeer opnieuw in te loggen.\n{loginTries-i} poginingen over.");
                }

                if (i == loginTries)
                {
                    print("Je hebt te vaak geprobeerd in te loggen, programma sluit nu.");
                    System.Environment.Exit(0);
                }

            }
            
            
            menu:
            {
                clear();
                print("Menu opties: \n [1] : Voorraad schoenen bekijken." +
                      "\n [2] Schoenen inkoopen. \n [3] Uitloggen.");
                int menuOption = int.Parse(cread());
                
                switch (menuOption)
                {
                    case 1:
                    {
                        goto voorraadSchoen;
                        break;
                    }
                    case 2:
                    {
                        goto inkoopSchoen;
                        break;
                    }
                    case 3:
                    {
                        goto Uitloggen;
                        break;
                    }
                    default:
                    {
                        print($"{menuOption} is geen optie in het menu");
                        goto menu;
                    }
                }
                
                voorraadSchoen:
                {
                    
                }
                
                inkoopSchoen:
                {
                    
                }
                
                Uitloggen:
                {
                    
                }

            }

        }
    }
}