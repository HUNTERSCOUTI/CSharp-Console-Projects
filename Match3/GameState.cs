using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3
{
    public class GameState
    {
        private int[] guesses = new int[3];
        private int currentGuess = 0;

        private DataPoint[,] data;

        public GameState(int columns, int rows)
        {
            data = new DataPoint[columns, rows];

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    data[x, y] = new DataPoint(Random.Shared.Next(0, 10));
                }
            }
        }
    }
    public struct DataPoint
    {
        public int value;
        public bool available;

        public DataPoint(int val)
        {
            value = val;
            available = true;
        }
    }
}
