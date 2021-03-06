using System;

namespace DiceRoller
{
    internal static class Program
    {
        private static void Main(string[] _)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Out.WriteLine("Welcome to DiceRoller");
                Console.Out.WriteLine("Type ? to obtain some help.");
                Console.Out.WriteLine();
                Console.Out.Write("-->");
                string Entry = Console.In.ReadLine();
                if (Entry.Length > 0)
                {
                    Result Result = Dice.Parse(Entry);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Out.Write(Result.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
        }
    }
}
