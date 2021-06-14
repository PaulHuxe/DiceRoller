using System;
using System.Linq;

namespace DiceRoller
{
    internal static class Dice
    {
        private static readonly Random Rand = new();

        internal static Result Parse(string entry)
        {
            entry = entry.Trim().ToUpper();
            string[] RollDefinitions = entry.Split(new char[] { '+' });
            Result Resultat = new();
            foreach (string S in RollDefinitions)
            {
                Roll(S, Resultat);
            }
            return Resultat;
        }

        private static void Roll(string rollDefinition, Result resultat)
        {
            rollDefinition = rollDefinition.Trim();
            if (rollDefinition.Contains('D'))
            {
                string[] DiceDefinition = rollDefinition.Split(new char[] { 'D' });
                //TODO error tests
                int NumberOfDices = int.Parse(DiceDefinition[0]);
                int NumberOfFaces = int.Parse(DiceDefinition[1]);
                for (int i = 0;i<NumberOfDices;i++)
                {
                    resultat.Resultat += RollDice(NumberOfFaces);
                }
            }
            else
            {
                resultat.Resultat += int.Parse(rollDefinition);
            }
        }

        private static int RollDice(int numberOfFaces)
        {
            return Rand.Next(numberOfFaces) + 1;
        }
    }
}