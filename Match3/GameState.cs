using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3
{
    public class GameState
    {
        private DataPoint[] _guesses = new DataPoint[3];
        public int Guess { get; private set; }

        public DataPoint[,] BoardNumbers { get; }

        public GameState(int columns, int rows)
        {
            BoardNumbers = new DataPoint[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    BoardNumbers[x, y] = new DataPoint(Random.Shared.Next(1, 4));
                }
            }
        }

        public DataPoint TakeNumber(int column)
        {
            DataPoint bestValue = BoardNumbers[column, 0];
            for (int row = 0; row < BoardNumbers.GetLength(1); row++)
            {
                var currentValue = BoardNumbers[column, row];
                if (!currentValue.Available)
                {
                    bestValue.Available = false;
                    return bestValue;
                }
                bestValue = currentValue;
            }
            bestValue.Available = false;
            return bestValue;
        }

        public void CheckMatch(int num1, int num2, int num3)
        {
            if (num1 != num2 || num2 != num3)
            {
                foreach (DataPoint point in _guesses)
                {
                    point.Available = true;
                }
            }
            Guess = 0;
            _guesses = new DataPoint[3];
        }

        public void AddGuess(DataPoint guess)
        {
            _guesses[Guess] = guess;
            Guess++;
        }
    }
    public class DataPoint
    {
        public int Value { get; set; }
        public bool Available { get; set; }

        public DataPoint(int val)
        {
            Value = val;
            Available = true;
        }
    }
}
