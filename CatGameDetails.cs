namespace MovingCat
{
    internal class CatGameDetails
    {
        public int AmountOfMoves;

        public int BoxNumber;

        public bool CatWasFound;

        public CatGameDetails(int ammountOfMoves, int boxNumber, bool catWasFound) 
        {
            AmountOfMoves = ammountOfMoves;
            BoxNumber = boxNumber;
            CatWasFound = catWasFound;
        }
    }
}
