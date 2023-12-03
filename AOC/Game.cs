namespace AOC
{
    public struct Game
    {
        const int VALID_RED = 12;
        const int VALID_GREEN = 13;
        const int VALID_BLUE = 14;

        public bool IsValid { get; private set;  }
        public int Id { get; private set; }
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public Game(int id, int r, int g, int b)
        {
            Id = id;
            Red = r; 
            Green = g; 
            Blue= b;

            IsValid = Red <= VALID_RED && Blue <= VALID_BLUE && Green <= VALID_GREEN;
        }
    }
}
