using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class MazeSolver
    {
        public const int TOTAL_ROWS = 10;
        public const int TOTAL_COLS = 10;

        public const char SEPARATOR = ',';
        public const char CHAR_OPENED = '.';
        public const char CHAR_CLOSED = '#';
        public const char CHAR_START = 'S';
        public const char CHAR_END = 'E';
        public const char CHAR_PATH = '+';

        private enum PositionTypes { OPENED, CLOSED, START, END, PATH };

        private PositionTypes[] _positions;

        public MazeSolver()
        {
            _positions = new PositionTypes[TOTAL_ROWS * TOTAL_COLS];
        }

        public void setData(string dataStr)
        {
            string[] data = dataStr.Split(SEPARATOR);

            for (int i = 0; i < data.Length; ++i)
            {
                addRowData(i, data[i]);
            }

            printMaze();
        }

        public void solve()
        {
            // TODO: Solve maze
        }

        private void printMaze()
        {
            string retVal = "";
            for (int i = 0; i < _positions.Length; ++i)
            {
                retVal += getCharacter(_positions[i]);

                if (getColOfPosition(i) + 1 == TOTAL_COLS)
                    retVal += "\n";
            }

            Console.WriteLine(retVal);
        }

        private char getCharacter(PositionTypes posType)
        {
            switch (posType)
            {
                case PositionTypes.OPENED:
                    return CHAR_OPENED;
                case PositionTypes.CLOSED:
                    return CHAR_CLOSED;
                case PositionTypes.START:
                    return CHAR_START;
                case PositionTypes.END:
                    return CHAR_END;
                case PositionTypes.PATH:
                    return CHAR_PATH;
                default:
                    throw new Exception("Invalid position type");
            }
        }

        private void addRowData(int row, string rowData)
        {
            int rowIndex = getPositionIndex(row, 0); // get index of first row

            for (int i = 0; i < rowData.Length; ++i)
            {
                switch (rowData[i])
                {
                    case CHAR_OPENED:
                        _positions[rowIndex + i] = PositionTypes.OPENED;
                        break;
                    case CHAR_CLOSED:
                        _positions[rowIndex + i] = PositionTypes.CLOSED;
                        break;
                    case CHAR_START:
                        _positions[rowIndex + i] = PositionTypes.START;
                        break;
                    case CHAR_END:
                        _positions[rowIndex + i] = PositionTypes.END;
                        break;
                }
            }
        }

        private PositionTypes getPositionTypeAt(int row, int col)
        {
            return _positions[getPositionIndex(row, col)];
        }

        private int getPositionIndex(int row, int col)
        {
            return row * TOTAL_COLS + col;
        }

        private int getRowOfPosition(int pos)
        {
            return pos / TOTAL_ROWS;
        }

        private int getColOfPosition(int pos)
        {
            return pos % TOTAL_COLS;
        }
    }
}
