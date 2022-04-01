using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenV2
{

    class Program
    {
        public static string Generate_Password(bool Letters, bool Numbers, bool Characters, int Length)
        {
            string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] characters = { ":", ";", "'", "@", "#", "~", "[", "{", "]", "}", "+", "=", "_", "-", "!", "£", "$", "%", "^", "&", "(", ")" };
            Random rnd = new Random();
            string Result = "";
            for (int i = 0; i != Length; i++)
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
            bool LettersBool = true;
            bool NumbersBool = true;
            bool CharactersBool = true;
            int PasswordLength = 1;
            int MinimumLength = 1;
            int MaximumLength = 100;
            string[] MenuSelections = { "Generate", "Length", "Letters", "Numbers", "Special_Characters", "Info" };
            int selectionID = 0;
            int NewID = 0;
            bool selecting = true;
            while (selecting)
            {
                Menu(selectionID, MenuSelections, LettersBool, NumbersBool, CharactersBool, PasswordLength);
                ConsoleKey key = Console.ReadKey().Key;
                NewID = IDCalculation(selectionID, key);
                if (selectionID == NewID)
                {
                    if (key == ConsoleKey.Spacebar)
                    {
                        switch (NewID)
                        {
                            case 0:
                                Console.WriteLine();
                                Console.WriteLine("Password Generated");
                                Console.WriteLine(Generate_Password(LettersBool, NumbersBool, CharactersBool, PasswordLength));
                                Console.WriteLine("=-= Press enter to continue =-=");
                                Console.ReadLine();
                                break;
                            case 2:
                                LettersBool = !LettersBool;
                                break;
                            case 3:
                                NumbersBool = !NumbersBool;
                                break;
                            case 4:
                                CharactersBool = !CharactersBool;
                                break;
                            case 5:
                                Info();
                                break;
                        }
                        //Console.WriteLine("End Switch");
                        //Console.ReadLine();
                    }
                    if (key == ConsoleKey.RightArrow && PasswordLength != MaximumLength)
                    {
                        PasswordLength += 1;
                    }
                    else if (key == ConsoleKey.LeftArrow && PasswordLength != MinimumLength)
                    {
                        PasswordLength -= 1;
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        Environment.Exit(9999999);
                    }
                }
                selectionID = NewID;
            }
        }
        static void Title()
        {
            var originColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("██╗░░██╗██╗░░░░░██╗░░░██╗███████╗██╗░██████╗  ██████╗░░█████╗░░██████╗░██████╗░██╗░░░░░░░██╗░█████╗░██████╗░██████╗░  ░██████╗░███████╗███╗░░██╗███████╗██████╗░░█████╗░████████╗░█████╗░██████╗░");
            Console.WriteLine("██║░██╔╝██║░░░░░╚██╗░██╔╝██╔════╝╚█║██╔════╝  ██╔══██╗██╔══██╗██╔════╝██╔════╝░██║░░██╗░░██║██╔══██╗██╔══██╗██╔══██╗  ██╔════╝░██╔════╝████╗░██║██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗");
            Console.WriteLine("█████═╝░██║░░░░░░╚████╔╝░█████╗░░░╚╝╚█████╗░  ██████╔╝███████║╚█████╗░╚█████╗░░╚██╗████╗██╔╝██║░░██║██████╔╝██║░░██║  ██║░░██╗░█████╗░░██╔██╗██║█████╗░░██████╔╝███████║░░░██║░░░██║░░██║██████╔╝");
            Console.WriteLine("██╔═██╗░██║░░░░░░░╚██╔╝░░██╔══╝░░░░░░╚═══██╗  ██╔═══╝░██╔══██║░╚═══██╗░╚═══██╗░░████╔═████║░██║░░██║██╔══██╗██║░░██║  ██║░░╚██╗██╔══╝░░██║╚████║██╔══╝░░██╔══██╗██╔══██║░░░██║░░░██║░░██║██╔══██╗");
            Console.WriteLine("██║░╚██╗███████╗░░░██║░░░███████╗░░░██████╔╝  ██║░░░░░██║░░██║██████╔╝██████╔╝░░╚██╔╝░╚██╔╝░╚█████╔╝██║░░██║██████╔╝  ╚██████╔╝███████╗██║░╚███║███████╗██║░░██║██║░░██║░░░██║░░░╚█████╔╝██║░░██║");
            Console.WriteLine("╚═╝░░╚═╝╚══════╝░░░╚═╝░░░╚══════╝░░░╚═════╝░  ╚═╝░░░░░╚═╝░░╚═╝╚═════╝░╚═════╝░░░░╚═╝░░░╚═╝░░░╚════╝░╚═╝░░╚═╝╚═════╝░  ░╚═════╝░╚══════╝╚═╝░░╚══╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝");
            Console.WriteLine("");
            Console.ForegroundColor = originColor;
            Console.WriteLine("Tool made by Klye-Projects");
        }
        static void Menu(int ID, string[] MenuItems, bool LettersBool, bool NumbersBool, bool CharactersBool, int Length)
        {
            Console.Clear();
            Title();
            for (int i = 0; i < MenuItems.Length; i++)
            {
                if (i != ID)
                {
                    Console.Write("  " + MenuItems[i]);
                    if (i == 1)
                    {
                        Console.Write(" " + Length);
                    }
                    else if (i == 2)
                    {
                        Console.Write(" " + LettersBool);
                    }
                    else if (i == 3)
                    {
                        Console.Write(" " + NumbersBool);
                    }
                    else if (i == 4)
                    {
                        Console.Write(" " + CharactersBool);
                    }



                }
                else
                {
                    Console.Write("> " + MenuItems[i]);
                    if (i == 1)
                    {
                        Console.Write(" " + Length);
                    }
                    else if (i == 2)
                    {
                        Console.Write(" " + LettersBool);
                    }
                    else if (i == 3)
                    {
                        Console.Write(" " + NumbersBool);
                    }
                    else if (i == 4)
                    {
                        Console.Write(" " + CharactersBool);
                    }
                }
                Console.Write('\n');
            }
        }
        static int IDCalculation(int CurrentID, ConsoleKey Key)
        {
            if (Key == ConsoleKey.UpArrow && CurrentID != 0)
            {
                CurrentID -= 1;
            }
            else if (Key == ConsoleKey.DownArrow && CurrentID != 5)
            {
                CurrentID += 1;
            }
            return CurrentID;
        }
        static void Info()
        {
            Console.WriteLine("Application Made By Klye");
            Console.WriteLine("Password Generator V2.0 ");
            Console.WriteLine("Added - Variable Length ");
            Console.WriteLine("Added - Menu System     ");
            Console.WriteLine("Added - Secure Password Measures" + '\n');
            Console.WriteLine("Press Enter To Continue");
            Console.ReadLine();
        }
    }
}

