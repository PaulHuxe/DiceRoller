using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    internal static class Help
    {
        internal static void Display(Result resultat)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Out.WriteLine("DiceRoller Help: ");
            Console.Out.WriteLine("General use");
            Console.Out.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine(@"Type the definition of the dices you want to roll.
For example, to roll one six-sided dice, type 1d6
To roll three 10-sided dices, type 3d10 and so on.
You can roll several dices at the same time. For example 1d10 + 2d8 + 3d6 is a valid entry.
You also can add modifiers, such as 2d6 + 1 or 3d10 - 2.
Differences of dices are also doable, like for example 1d6 - 1d4. This can lead to negative results.");
            Console.Out.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Out.WriteLine("Special dices");
            Console.Out.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine(@"You also can use special dices, that return non-numerical values, or non standard numerical values.vThese dices can be used into specific games. For example, 1dCoin will flip a coin and return Head or Tails.
You can  launch several special dices at the same time and even mix it with normal dices. For example, 3dFlip + 1d6 is a legal entry.

Currently, these dices are supported:

Coin -> flip a coin. Returns Head or Tail.
InsMv -> rolls three 6-sided dices and gives a result between 111 and 666. Used in the RPG In Nomine satanis/Magna Veritas");
            Console.Out.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Out.WriteLine("Special functions");
            Console.Out.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Out.WriteLine(@"You can record your favorite dice combinations to easily reuse them. Follow the example :
* MYROLL 1d100 + 5
will record the 1d100 + 5 roll with the name MYROLL

/ MYROLL
will roll the recorded function, i.e. 1d100 + 5

You can record as many roll definitions as you wish.
");
            resultat.AddSpecialResult("Help file shown", 1, false);
        }
    }
}
