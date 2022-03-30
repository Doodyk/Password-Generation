using System;

namespace Password_Generator_Console
{
    class Program
    {
        public static string Generate_Password(bool Letters, bool Numbers, bool Characters)
        {
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] characters = { ":", ";", "'", "@", "#", "~", "[", "{", "]", "}", "+", "=", "_", "-", "!", "£", "$", "%", "^", "&", "(", ")" };
            Random rnd = new Random();
            string Result = "";
            for (int i = 0; i != 15; i++)
            {
                int tmp = rnd.Next(1, 11);
                if (tmp > 0 && tmp <= 5 && Letters == true)
                {
                    Result += letters[rnd.Next(1, letters.Length)];
                }
                else if (tmp >= 6 && tmp <= 8 && Numbers == true)
                {
                    Result += numbers[rnd.Next(1, numbers.Length)];
                }
                else if (tmp >= 9 && tmp <= 10 && Characters == true)
                {
                    Result += characters[rnd.Next(1, characters.Length)];
                }
                else
                {
                    i -= 1;
                }

            }
            return (Result);
        }
        static void Main(string[] args)
        {
            bool Letters1 = true;
            bool Number1 = true;
            bool Characters1 = true;
            Console.WriteLine("Pass_Gen_V1.0");
            while (true)
            {
                Console.WriteLine("Would you like letters?");
                if (Console.ReadLine() == "y")
                {
                    Letters1 = true;
                }
                else
                {
                    Letters1 = false;
                }
                Console.WriteLine("Would you like Numbers?");
                if (Console.ReadLine() == "y")
                {
                    Number1 = true;
                }
                else
                {
                    Number1 = false;
                }
                Console.WriteLine("Would you like Characters?");
                if (Console.ReadLine() == "y")
                {
                    Characters1 = true;
                }
                else
                {
                    Characters1 = false;
                }
                Console.WriteLine(Generate_Password(Letters1, Number1, Characters1));
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}

