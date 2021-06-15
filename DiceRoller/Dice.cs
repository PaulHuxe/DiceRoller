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
            if (Char.IsDigit(entry[0]))
            {
                entry = entry.Replace("-", "+-");
                string[] RollDefinitions = entry.Split(new char[] { '+' });
                Result Resultat = new();
                foreach (string S in RollDefinitions)
                {
                    Roll(S, Resultat);
                }
                return Resultat;
            }
            else
            {
                //TODO managing the other functions

                return new Result();
            }
        }

        private static void Roll(string rollDefinition, Result resultat)
        {
            rollDefinition = rollDefinition.Trim();
            if (!string.IsNullOrEmpty(rollDefinition))
            {
                if (rollDefinition.Contains('D'))
                {
                    string[] DiceDefinition = rollDefinition.Split('D', 2);
                    bool HasNumberOfDice = int.TryParse(DiceDefinition[0], out int NumberOfDices);
                    if (!HasNumberOfDice)
                    {
                        resultat.AddError(DiceDefinition[0] + " is not a valid number of dices");
                    }
                    else
                    {
                        bool IsNegativeNumberOfDices = NumberOfDices < 0;
                        bool HasNumberOfFaces = int.TryParse(DiceDefinition[1], out int NumberOfFaces);
                        if (!HasNumberOfFaces)
                        {
                            for (int i = 0; i < Math.Abs(NumberOfDices); i++)
                            {
                                RollSpecialDice(DiceDefinition[1], IsNegativeNumberOfDices, resultat);
                            }
                        }
                        else
                        {
                            if (NumberOfFaces < 0)
                            {
                                resultat.AddError("A dice cannot have a negative number of faces");
                            }
                            else
                            {
                                if (IsNegativeNumberOfDices)
                                {
                                    for (int i = 0; i < -NumberOfDices; i++)
                                    {
                                        resultat.Resultat -= RollDice(NumberOfFaces);
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < NumberOfDices; i++)
                                    {
                                        resultat.Resultat += RollDice(NumberOfFaces);
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

        private static void RollSpecialDice(string specialDiceDefinition, bool isNegativeNumberOfDices, Result resultat)
        {
            specialDiceDefinition = specialDiceDefinition.Trim();
            switch (specialDiceDefinition)
            {
                case "COIN":
                    RollCoin(resultat, isNegativeNumberOfDices);
                    break;
                case "INSMV":
                    RollInsMv(resultat, isNegativeNumberOfDices);
                    break;
                default:
                    resultat.AddError(specialDiceDefinition + " is not a recognized dice name");
                    break;
            }
        }

        private static void RollInsMv(Result resultat, bool isNegativeNumberOfDices)
        {
            int Throw = 100 * RollDice(6) + 10 * RollDice(6) + RollDice(6);
            if (isNegativeNumberOfDices)
            {
                resultat.Resultat -= Throw;
            }
            else
            {
                resultat.Resultat += Throw;
            }
        }

        private static void RollCoin(Result resultat, bool isNegativeNumberOfDices)
        {
            int Throw = RollDice(2);
            resultat.AddSpecialResult(Throw == 1 ? "Head" : "Tail", 1, isNegativeNumberOfDices);
        }
    }
}