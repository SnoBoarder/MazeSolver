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
        public const char CHAR_BLOCKED = '#';
        public const char CHAR_START = 'S';
        public const char CHAR_GOAL = 'E';
        public const char CHAR_VISITED = '+';
        public const char CHAR_CURRENT = 'x';

        private int[] _offsets = new int[8] {-1, 0, // up
                                             0, -1, // left
                                             1, 0,  // down
                                             0, 1}; // right

        private Cell[,] _cells;

        private int _startRow;
        private int _startCol;

        private int _goalRow;
        private int _goalCol;

        private StringBuilder _scratchString;

        public MazeSolver()
        {
            _cells = new Cell[TOTAL_ROWS, TOTAL_COLS];

            _scratchString = new StringBuilder();
        }

        public void setData(string dataStr)
        {
            string[] data = dataStr.Split(SEPARATOR);

            for (int i = 0; i < data.Length; ++i)
            {
                addRowData(i, data[i]);
            }

            // calculate distance for every cell to the end goal
            Cell cell;
            for (int row = 0; row < TOTAL_ROWS; ++row)
            {
                for (int col = 0; col < TOTAL_COLS; ++col)
                {
                    cell = _cells[row, col];
                    if (!cell.blocked)
                        cell.distanceToGoal = distance(row, col, _goalRow, _goalCol);
                }
            }

            printMaze();
        }

        /// <summary>
        /// Use the pythagorean to calculate the distance from the current point to the end point.
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="startCol"></param>
        /// <param name="endRow"></param>
        /// <param name="endCol"></param>
        /// <returns></returns>
        private double distance(int startRow, int startCol, int endRow, int endCol)
        {
            return Math.Sqrt(Math.Pow(endCol - startCol, 2) + Math.Pow(endRow - startRow, 2));
        }

        public void solve()
        {
            List<Cell> list = new List<Cell>();

            // set the starting node as visited and the first node in the queue
            Cell current = _cells[_startRow, _startCol];
            current.visited = true;
            
            list.Add(current);

            while (list.Count > 0)
            {
                current = list[0];
                list.RemoveAt(0);

                if (current.row == _goalRow && current.col == _goalCol)
                {
                    // we're done! get the path to the root and break or just break
                    break;
                }

                for (int i = 0; i < _offsets.Length; i+=2)
                {
                    // get adjacent cell based on offset
                    int row = current.row + _offsets[i];
                    int col = current.col + _offsets[i + 1];

                    if (row < 0 || row >= TOTAL_ROWS)
                        continue; // row exceeds bounds. ignore.

                    if (col < 0 || col >= TOTAL_COLS)
                        continue; // column exceeds bounds. ignore.

                    Cell adjacent = _cells[row, col];

                    if (adjacent.blocked)
                        continue; // it's a blockade. ignore.

                    if (adjacent.visited)
                        continue; // we already visited this cell. ignore.

                    // we have a new cell! add it to the list
                    adjacent.visited = true;
                    adjacent.parent = current;

                    list.Add(adjacent);
                }

                // sort list by lowest distance to goal
                list = list.OrderBy(s => s.distanceToGoal).ToList();

                printMaze(current);
            }
        }

        private void printMaze(Cell curr = null)
        {
            _scratchString.Clear();

            for (int row = 0; row < TOTAL_ROWS; ++row)
            {
                for (int col = 0; col < TOTAL_COLS; ++col)
                {
                    if (curr != null && curr.row == row && curr.col == col)
                        _scratchString.Append(CHAR_CURRENT);
                    else
                        _scratchString.Append(getCharacter(row, col));

                    if (col + 1 == TOTAL_COLS)
                        _scratchString.Append("\n");
                }
            }

            Console.WriteLine(_scratchString);
        }

        private char getCharacter(int row, int col)
        {
            Cell cell = _cells[row, col];

            if (cell.blocked)
                return CHAR_BLOCKED;

            // cell is OPEN! check if it's start or end
            if (row == _startRow && col == _startCol)
                return CHAR_START;

            if (row == _goalRow && col == _goalCol)
                return CHAR_GOAL;

            // check if it's been visited
            if (cell.visited)
                return CHAR_VISITED;

            return CHAR_OPENED;
        }

        private void addRowData(int row, string rowData)
        {
            for (int col = 0; col < rowData.Length; ++col)
            {
                switch (rowData[col])
                {
                    case CHAR_OPENED:
                        _cells[row, col] = new Cell(false, row, col);
                        break;
                    case CHAR_BLOCKED:
                        _cells[row, col] = new Cell(true, row, col);
                        break;
                    case CHAR_START:
                        _cells[row, col] = new Cell(false, row, col);
                        _startRow = row;
                        _startCol = col;
                        break;
                    case CHAR_GOAL:
                        _cells[row, col] = new Cell(false, row, col);
                        _goalRow = row;
                        _goalCol = col;
                        break;
                }
            }
        }
    }
}
