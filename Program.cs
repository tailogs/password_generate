using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratePassword
{
    class Program
    {
        static Random random = new Random();
        static string allowedCharacters = "!@#$%^&*()_+-=[]{}|;:,.<>?";
        static string password = "";

        static void Main(string[] args)
        {
            if (args.Length < 2 || args[0].Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Пример: GeneratePassword.exe 20 i");
                Console.WriteLine("Первый аргумент это длина пароля. В примере выше - 20");
                Console.WriteLine("Второй аргумент это тип пароля:");
                Console.WriteLine("    i - только числа");
                Console.WriteLine("    a - только буквы");
                Console.WriteLine("    ai - числа и буквы");
                Console.WriteLine("    is - числа и символы");
                Console.WriteLine("    as - буквы и символы");
                Console.WriteLine("    ais - буквы, числа и символы");
                return;
            }

            switch (args[1])
            {
                case "i":
                    for (int i = 0; i < int.Parse(args[0]); i++)
                        password += GenerateIntToString();
                    break;
                case "a":
                    for (int i = 0; i < int.Parse(args[0]); i++)
                        password += GenerateChar();
                    break;
                case "ai":
                    for (int i = 0; i < int.Parse(args[0]) / 2; i++)
                    {
                        password += GenerateIntToString();
                        password += GenerateChar();
                    }
                    break;
                case "is":
                    for (int i = 0; i < int.Parse(args[0]) / 2; i++)
                    {
                        password += GenerateIntToString();
                        password += GenerateSymbol();
                    }
                    break;
                case "as":
                    for (int i = 0; i < int.Parse(args[0]) / 2; i++)
                    {
                        password += GenerateChar();
                        password += GenerateSymbol();
                    }
                    break;
                case "ais":
                    while (password.Length != int.Parse(args[0]))
                    {
                        if (password.Length != int.Parse(args[0]))
                            password += GenerateChar();
                        if (password.Length != int.Parse(args[0]))
                            password += GenerateIntToString();
                        if (password.Length != int.Parse(args[0]))
                            password += GenerateSymbol();
                    }
                    break;
                default:
                    Console.WriteLine("Указан неверный параметр!");
                    return;
            }

            Console.WriteLine("Пароль: " + password);
        }

        public static char GenerateChar()
        {
            bool isUpperCase = random.Next(2) == 0;
            char randomLetter;

            if (isUpperCase)
                randomLetter = (char)(random.Next(26) + 'A');
            else
                randomLetter = (char)(random.Next(26) + 'a');

            return randomLetter;
        }

        public static string GenerateIntToString()
        {
            return random.Next(10).ToString();
        }

        public static char GenerateSymbol()
        {
            return allowedCharacters[random.Next(allowedCharacters.Length)];
        }
    }
}
