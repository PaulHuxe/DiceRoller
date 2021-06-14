using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    internal class Result
    {
        public int Resultat;
        public string ErrorCodes;
        public Dictionary<string, int> SpecialResults;

        public Result()
        {
            SpecialResults = new Dictionary<string, int>();
        }

        public override string ToString()
        {
            //TODO
            return Resultat.ToString();
        }
    }
}
