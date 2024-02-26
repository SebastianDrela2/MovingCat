using System.Reflection.Metadata.Ecma335;

namespace MovingCat;

internal class Program
{
    static void Main(string[] args)
    {
        var start = 0;
        var amount = 10000;

        var box = new Box(ref start, ref amount);
        var cat = Box.AsignCatToOneOfBoxes(amount, box);
        var firstCat = Box.FindFirstCatForReference(cat);
        var catGameDetails = CatGame(box, cat);

        if (catGameDetails.CatWasFound.Equals(true))
        {
            Console.WriteLine($"Cat was found in {catGameDetails.AmountOfMoves} moves at {catGameDetails.BoxNumber}");
            Console.WriteLine($"FirstCat original was in {firstCat.BoxNumber}");
        }
        else
        {
            Console.WriteLine($"Cat was not found.");
        }
    }

    private static CatGameDetails CatGame(Box box, Box? catBox)
    {
        var amountOfMoves = 0;

        while (box.Next != null)
        {
            amountOfMoves++;

            if (Box.LookForCat(box))
            {
                return new CatGameDetails(amountOfMoves, box.BoxNumber, true);
            }

            catBox = Box.MoveCat(catBox);

            if (box.BoxNumber % 2 == 0)
            {
                amountOfMoves++;

                if (Box.LookForCat(box))
                {
                    return new CatGameDetails(amountOfMoves, box.BoxNumber, true);
                }
            }

            box = box.Next;
        }

        while (box.BoxNumber != 0)
        {
            box = box.Before;

            if (Box.LookForCat(box))
            {
                return new CatGameDetails(amountOfMoves, box.BoxNumber, true);
            }

            catBox = Box.MoveCat(catBox);
            amountOfMoves++;
        }

        return new CatGameDetails(amountOfMoves, box.BoxNumber, false);
    }
}