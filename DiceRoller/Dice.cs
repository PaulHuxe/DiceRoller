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
            // tip to manage the sustract sign
            entry = entry.Replace("-", "+-");
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
            if (!string.IsNullOrEmpty(rollDefinition))
            {
                if (rollDefinition.Contains('D'))
                {
                    string[] DiceDefinition = rollDefinition.Split(new char[] { 'D' });
                    bool HasNumberOfDice = int.TryParse(DiceDefinition[0], out int NumberOfDices);
                    if (!HasNumberOfDice)
                    {
                        resultat.AddError(DiceDefinition[0] + " is not a valid number of dices");
                    }
                    else
                    {
                        bool HasNumberOfFaces = int.TryParse(DiceDefinition[1], out int NumberOfFaces);
                        if (!HasNumberOfFaces)
                        {
                            //TODO replace it with special dice management
                            resultat.AddError(DiceDefinition[1] + " is not a valid number of faces");
                        }
                        else
                        {
                            if (NumberOfFaces < 0)
                            {
                                resultat.AddError("A dice cannot have a negative number of faces");
                            }
                            else
                            {
                                if (NumberOfDices > 0)
                                {
                                    for (int i = 0; i < NumberOfDices; i++)
                                    {
                                        resultat.Resultat += RollDice(NumberOfFaces);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < -NumberOfDices; i++)
                                    {
                                        resultat.Resultat -= RollDice(NumberOfFaces);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    resultat.Resultat += int.Parse(rollDefinition);
                }
            }
        }

        private static int RollDice(int numberOfFaces)
        {
            return Rand.Next(numberOfFaces) + 1;
        }
    }
}