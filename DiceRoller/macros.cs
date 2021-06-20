using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    internal static class Macros
    {
        private static readonly Dictionary<string, string> Records = new();

        public static void Add (string key, string value, Result Resultat)
        {
            if (Records.ContainsKey(key))
            {
                Records.Remove(key);
            }
            Records.Add(key, value);
            Resultat.AddSpecialResult("Macro recorded", 1, false);
        }

        public static void Roll(string key, Result Resultat)
        {
            Dice.Parse(Records[key], Resultat);
        }
    }
}
