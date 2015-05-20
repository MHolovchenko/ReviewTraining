using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Knight
    {
        private int _verticalPos;
        private int _horizontalPos;
        private const int LOWER_BOUND = 0;
        private const int UPPER_BOUND = 7;

        /// <summary>
        /// Gets possible positions to move for knight
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public List<string> Move(string position)
        {
            List<string> movements = new List<string>();
            if (!IsPositionCorrect(position))
            {
                return movements;
            }
            _verticalPos = GetVerticalCoord(position);
            _horizontalPos = GetHorizontalCoord(position);

            for (int i = -2; i <= 2; i = i + 4)
            {
                for (int j = -1; j <= 1; j = j + 2)
                {
                    if (IsOnBoard(_horizontalPos + i, _verticalPos + j))
                    {
                        movements.Add(ConvertCoord(_horizontalPos + i, _verticalPos + j));
                    }

                    if (IsOnBoard(_horizontalPos + j, _verticalPos + i))
                    {
                        movements.Add(ConvertCoord(_horizontalPos + j, _verticalPos + i));
                    }
                }
            }
            return movements;
        }
        /// <summary>
        /// Determines whether position of knight is correctly defined
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool IsPositionCorrect(string position)
        {
            if (position.Length <= 0 || position.Length > 2)
            {
                return false;
            }
            int horPos = GetHorizontalCoord(position);
            int vertPos = GetVerticalCoord(position);
            return IsOnBoard(horPos, vertPos);
        }

        /// <summary>
        /// Tells whether input coordinates are within board bounds.
        /// </summary>
        private bool IsOnBoard(int horPosition, int vertPosition)
        {
            bool result = horPosition <= UPPER_BOUND && horPosition >= LOWER_BOUND && vertPosition <= UPPER_BOUND && vertPosition >= LOWER_BOUND;
            return result;
        }

        /// <summary>
        /// Gets horizontal coordinate on board from string representation
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private int GetHorizontalCoord(string position)
        {
            return position[0] - 'A';
        }

        /// <summary>
        /// Gets vertical coordinate on board
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private int GetVerticalCoord(string position)
        {
            return (int)Char.GetNumericValue(position[1]) - 1;
        }

        /// <summary>
        /// Converts coordinates on board to string representation
        /// </summary>
        /// <param name="hPos"></param>
        /// <param name="vPos"></param>
        /// <returns></returns>
        private string ConvertCoord(int hPos, int vPos)
        {
            return Convert.ToChar(hPos + 'A').ToString() + (vPos + 1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Knight knight=new Knight();
            List<string> movements = knight.Move("C5");

            foreach (string move in movements)
            {
                Console.WriteLine(move);
            }

            Console.ReadKey();
        }
    }
}
