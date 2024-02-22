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
        var (found, ammount, catBox) = CatGame(ref box, ref cat);

        if (found.Equals(true))
        {
            Console.WriteLine($"Cat was found in {ammount} moves at {catBox}");
            Console.WriteLine($"FirstCat original was in {firstCat.BoxNumber}");
        }
        else
        {
            Console.WriteLine($"Cat was not found.");
        }
    }

    private static (bool, int, int) CatGame(ref Box box, ref Box? catBox)
    {
        var amountOfMoves = 0;

        while (box.Next != null)
        {
            amountOfMoves++;
            if (Box.LookForCat(box))
            {
                return (true, amountOfMoves, box.BoxNumber);
            }

            catBox = Box.MoveCat(catBox);
            if (box.BoxNumber % 2 == 0)
            {
                amountOfMoves++;
                if (Box.LookForCat(box))
                {
                    return (true, amountOfMoves, box.BoxNumber);
                }
            }

            box = box.Next;
        }

        while (box.BoxNumber != 0)
        {
            box = box.Before;
            if (Box.LookForCat(box))
            {
                return (true, amountOfMoves, box.BoxNumber);
            }

            catBox = Box.MoveCat(catBox);
            amountOfMoves++;
        }

        return (false, 0, 0);
    }
}