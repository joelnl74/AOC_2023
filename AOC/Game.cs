namespace AOC
{
    public struct Game
    {
        const int VALID_RED = 12;
        const int VALID_GREEN = 13;
        const int VALID_BLUE = 14;

        public bool IsValid { get; private set;  }
        public int Id { get; private set; }

        readonly int red;
        readonly int green;
        readonly int blue;

        public Game(int id, int r, int g, int b)
        {
            Id = id;
            red = r; 
            green = g; 
            blue= b;

            IsValid = red <= VALID_RED && blue <= VALID_BLUE && green <= VALID_GREEN;
        }
    }
}
