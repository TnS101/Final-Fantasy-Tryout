using System;

namespace Final_Fantasy_Tryout.PlayingField
{
    public class PlayerMovement
    {
        public PlayerMovement()
        {
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Movement(ConsoleKey direction, int x, int y)
        {
            this.X = x;
            this.Y = y;
            switch (direction)
            {
                case ConsoleKey.UpArrow: this.Y--; return Y;
                case ConsoleKey.DownArrow: Y++; return Y;
                case ConsoleKey.LeftArrow: X--; return X;
                case ConsoleKey.RightArrow: X++; return X;
            }
            return 0;
        }
    }
}
