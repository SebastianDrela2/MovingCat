namespace MovingCat
{
    public class Box
    {
        public int BoxNumber;
        public bool HasCat;
        public Box? Next;
        public Box Before;

        public Box(ref int start, ref int ammount)
        {
            if (start.Equals(ammount))
            {
                Next = null;
            }
            else
            {
                BoxNumber = start;
                start++;

                Next = new Box(ref start, ref ammount)
                {
                    Before = this
                };
            }
        }

        public static Box? AsignCatToOneOfBoxes(int maxNumber, Box box)
        {
            var random = new Random();
            var randomNumber = random.Next(maxNumber + 1);

            while (box.Next != null)
            {
                if (box.BoxNumber.Equals(randomNumber))
                {
                    box.HasCat = true;
                    return box;
                }

                box = box.Next;
            }

            return null;
        }

        public static Box? FindFirstCatForReference(Box box)
        {
            while (box.Next != null)
            {
                if (box.HasCat)
                {
                    return box;
                }

                box = box.Next;
            }

            return null;
        }

        public static bool LookForCat(Box box) => box.HasCat.Equals(true);

        public static Box? MoveCat(Box catBox)
        {
            var random = new Random();
            var randomNumber = random.Next(2);
            catBox.HasCat = false;

            if (randomNumber.Equals(1) && catBox.Next != null)
            {
                catBox.Next.HasCat = true;
                return catBox.Next;
            }

            catBox.Before.HasCat = true;
            return catBox.Before;
        }
    }
}