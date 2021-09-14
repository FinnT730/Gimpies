using System;
using System.Collections.Generic;

namespace Gimpies
{
    class Program
    {
        // Struct om data van de schoenen op te slaan
        public struct SchoenStruct
        {
            public string merk;
            public string type;
            public int maat;
            public string kleur;
            public int aantal;
            public float prijs;
        }

        // print is gebruikt om naar de console printen
        public static void print(object obj)
        {
            Console.WriteLine(obj);
        }

        // print is gebruikt om van de console lezen
        public static string cread()
        {
            return Console.ReadLine();
        }

        // print is gebruikt om de console leeg te maken
        public static void clear()
        {
            Console.Clear();
        }
        
        // Hier worden alle schoenen opgeslagen
        static List<SchoenStruct> schoenen = new List<SchoenStruct>();

        // Hier word alles van de menu geregeld
        static void menu()
        {
            clear();
            print("Menu opties: \n [1] : Voorraad schoenen bekijken." +
                  "\n [2] : Schoenen inkoopen. \n [3] : Uitloggen.");
            int menuOption = int.Parse(cread());

            switch (menuOption)
            {
                case 1:
                {
                    voorraadSchoenen();
                    break;
                }
                case 2:
                {
                    inkoopSchoenen();
                    break;
                }
                case 3:
                {
                    uitloggen();
                    break;
                }
                default:
                {
                    print($"{menuOption} is geen optie in het menu");
                    menu();
                    break;
                }
            }

            // Hier kunnen we de voorraad van de schoenen uitlesen en printen naar de console
            static void voorraadSchoenen()
            {
                clear();
                foreach (var sc in schoenen)
                {
                    print("[");
                    print($"Merk: {sc.merk}\nType: {sc.type}\nMaat: {sc.maat}\nKleur: {sc.kleur}\nAantal: {sc.aantal}" +
                          $"\nPrijs: {sc.prijs}");
                    print("]");
                    print("");
                }

                print("Terug gaan naar het menu? [Y/N of y/n]");
                char answer = char.Parse(cread());
                if (answer is 'Y' or 'y')
                {
                    menu();
                }
                else if (answer == 'N' || answer == 'n')
                {
                    print("Wat dan?");
                }

                return;
            }
        }

        // hier kunnen we schoenen inkoopen
        static void inkoopSchoenen()
        {
            clear();
            print("Koop nieuwe schoenen.");

            print("Welke merk?");
            string merk = cread();

            print("Welke type?");
            string type = cread();

            print("Welke maat?");
            int maat = int.Parse(cread());

            print("Welke Kleur?");
            string kleur = cread();

            print("Hoeveel wil je bestellen?");
            int hoeveel = int.Parse(cread());

            if (hoeveel < 1)
            {
                print("De hoeveelheid moet positief zijn. Vul het opniew in.");
                hoeveel = int.Parse(cread());
            }
            
            print("Wat is de prijs?");
            float prijs = float.Parse(cread());
            
            schoenen.Add(new SchoenStruct()
            {
                merk = merk,
                type = type,
                maat = maat,
                kleur = kleur,
                aantal = hoeveel,
                prijs = prijs
            });

            print("\n\n Wil je nog meer bijvoegen? [y/n] of [Y/N]");
            char answer = Char.Parse(cread());
            if (answer is 'Y' or 'y')
            {
                inkoopSchoenen();
            }
            else if (answer == 'N' || answer == 'n')
            {
                menu();
            }

            return;
        }

        // hier kunnen we uitloggen van de app
        static void uitloggen()
        {
            clear();
            // goto start;
            return;
        }
        
        // Hello World!
        static void Main(string[] args)
        {

            const string INKOOPLOGIN = "Inkoop";
            const string INKOOPPASSWORD = "Gimpies_Inkoop";

            schoenen.Add(new SchoenStruct()
            {
                merk = "Nike",
                type = "Air Max",
                maat = 42,
                kleur = "Rood",
                aantal = 17,
                prijs = 49.99f
            });
            
            int loginTries = 3;

            for (int i = 1; i <= loginTries; i++)
            {
                print("Gebruikers naam:");
                string name = Console.ReadLine();

                print("Wachtwoord:");
                string password = "";
                ConsoleKey key;
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;
                    if (key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        Console.Write("\b \b");
                        password = password[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        password += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);


                if ((name == INKOOPLOGIN && password == INKOOPPASSWORD) || name == "admin" && password == "admin")
                {
                    menu();
                }
                else
                {
                    clear();
                    print($"Probeer opnieuw in te loggen.\n{loginTries - i} poginingen over.");
                }

                if (i == loginTries)
                {
                    print("Je hebt te vaak geprobeerd in te loggen, programma sluit nu.");
                    System.Environment.Exit(0);
                }

            }

        }
    }
}