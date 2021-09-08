using System;
using System.Collections.Generic;

namespace Gimpies
{

    struct User
    {
        public string name;
        public string password;

        public User(string name,string password)
        {
            this.name = name;
            this.password = password;
        }


        public bool checkLogin(string name, string pass)
        {
            if (this.name == name && this.password == pass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }

    class Program
    {
        private static List<User> users = new List<User>();




        public static void print(Object OBJ)
        {
            Console.WriteLine(OBJ);
        }

        /*
         * This will return true, IF the user logged in successfully. If not, it will say how many tries it has left,
         * and after 3 tries it will exit the program.
         * if the user does not exist in the database, we will show a error message that will inform the user that something went wrong.
         */
        public static bool login()
        {
                print("Geef je username op.");
                var name = Console.ReadLine();
                print("Geef je password op.");
                var password  = Console.ReadLine();


                foreach (var user in users)
                {
                    if (user.checkLogin(name, password))
                    {
                        return true;
                    }
                    else
                    {
                        login();
                    }
                }
                
                
                // foreach (var user in users)
                // {
                //     if (name == user.name)
                //     {
                //         if (password == user.password)
                //         {
                //             return true;
                //         }
                //         else
                //         {
                //             print("Je wachtwoord OF gebruikersnaam is niet goed ingevuld");
                //         }
                //     }
                //     else
                //     {
                //         print("Je gebruikersnaam is niet goed ingevuld");
                //     }
                // }

            return false;
        }

        static void Main(string[] args)
        {
            
            
            /*
             * Inkoop gebruiker, standart in de programma
             */
            users.Add(new User("Inkoop","Gimpies_Inkoop"));
            
            
            bool loggedIn = login();
            print(loggedIn);
            
        }
    }
}