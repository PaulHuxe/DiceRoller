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
                Console.Out.Write("-->");
                string Entry = Console.In.ReadLine();
                if (Entry.Length > 0)
                {
                    int Result = Dice.Parse(Entry);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Out.Write(Result.ToString() + Environment.NewLine + Environment.NewLine);
                }
            }
        }
    }
}
