using System;
using System.Linq;

namespace DiceRoller
{
    internal static class Dice
    {
        private static readonly Random Rand = new();

        internal static int Parse(string entry)
        {
            entry = entry.Trim().ToUpper();
            string[] RollDefinitions = entry.Split(new char[] { '+' });
            return RollDefinitions.Sum(p => Roll(p));
        }

        private static int Roll(string rollDefinition)
        {
            rollDefinition = rollDefinition.Trim();
            if (rollDefinition.Contains('D'))
            {
                string[] DiceDefinition = rollDefinition.Split(new char[] { 'D' });
                int NumberOfDices = int.Parse(DiceDefinition[0]);
                int NumberOfFaces = int.Parse(DiceDefinition[1]);
                int Result = 0;
                for (int i = 0;i<NumberOfDices;i++)
                {
                    Result += RollDice(NumberOfFaces);
                }
                return Result;
            }
            else
            {
                return int.Parse(rollDefinition);
            }
        }

        private static int RollDice(int numberOfFaces)
        {
            return Rand.Next(numberOfFaces) + 1;
        }
    }
}