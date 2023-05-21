namespace retardcat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var start = 0;
            var ammount = 10000;

            var box = new Box(ref start,ref ammount);
            var cat = Box.AsignCatToOneOfBoxes(ammount,box);
            var firstCat = Box.FindFirstCatForReference(cat);
            var (found,ammounst,catbox) = CatGame(ref box, ref cat);

            if (found.Equals(true))
            {
                Console.WriteLine($"Cat was found in {ammounst} moves at {catbox}");
                Console.WriteLine($"FirstCat originall was in {firstCat.BoxNumber}");
            }
            else
            {
                Console.WriteLine($"Cat was not found.");
            }
        }

        private static (bool,int,int) CatGame(ref Box box, ref Box? catBox)
        {
            int ammountOfMoves = 0;

            while (box.Next != null)
            {
                ammountOfMoves++;
                if (Box.LookForCat(box))
                {
                    return (true,ammountOfMoves,box.BoxNumber);
                }
                catBox = Box.MoveCat(catBox);
                if (box.BoxNumber % 2 == 0)
                {
                    ammountOfMoves++;
                    if (Box.LookForCat(box))
                    {
                        return (true, ammountOfMoves,box.BoxNumber);
                    }
                }
                box = box.Next;
            }

            while (box.BoxNumber != 0)
            {
                box = box.Before;
                if (Box.LookForCat(box))
                {
                    return (true,ammountOfMoves,box.BoxNumber);
                }

                catBox = Box.MoveCat(catBox);
                ammountOfMoves++;
            }
            return (false,0,0);
        }
    }
}