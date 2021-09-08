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
    }

    class Program
    {
        private static List<User> users = new List<User>();

        public Program()
        {
            /*
             * This is the admin user, or the 'Inkoop medewerker'
             */
            users.Add(new User("Inkoop","Gimpies_Inkoop"));
        }


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
            int tries = 3;
            
            while (tries > 0)
            {
                print("Geef je username op.");
                var name = Console.ReadLine();
                print("Geef je password op.");
                var password  = Console.ReadLine();
                
                foreach (var user in users)
                {
                    if (name == user.name)
                    {
                        if (password == user.password)
                        {
                            return true;
                        }
                    }
                }

                tries--;
                
            }

            return false;
        }

        static void Main(string[] args)
        {
            
        }
    }
}