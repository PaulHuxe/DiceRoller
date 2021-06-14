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
            if (string.IsNullOrWhiteSpace(ErrorCodes))
            {
                return Resultat.ToString();
                //TODO add to this output the special results.
            }
            else
            {
                return ErrorCodes;
            }
        }

        public void AddError(string newError)
        {
            if (!string.IsNullOrWhiteSpace(ErrorCodes))
            {
                ErrorCodes += ", ";
            }
            ErrorCodes += newError;
        }

        public void AddSpecialResult(string resultName, int value, bool isNegative)
        {
            if (SpecialResults.ContainsKey(resultName))
            {
                if (isNegative)
                {
                    SpecialResults[resultName] -= value;
                }
                else
                {
                    SpecialResults[resultName] += value;
                }
            }
            else
            {
                if (isNegative)
                {
                    SpecialResults.Add(resultName, -value);
                }
                else
                {
                    SpecialResults.Add(resultName, value);
                }
            }
        }
    }
}
