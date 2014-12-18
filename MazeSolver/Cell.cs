using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    /// <summary>
    /// The Cell represents the cell of a maze.
    /// </summary>
    public class Cell
    {
        // reference to its own row and col
        private int _row;
        private int _col;

        private bool _blocked; // check whether the cell is a block or not
        private Cell _parent = null; // check if the cell has a parent (this is used to find the final path)
        private bool _visited; // check if the cell has been visited

        private bool _final; // if true, this cell is part of the final path from start to end

        private double _distanceToGoal = -1.0; // the distance from itself to the end cell

        public Cell(bool blocked, int row, int col)
        {
            _blocked = blocked;
            _row = row;
            _col = col;
        }

        public double distanceToGoal
        {
            get { return _distanceToGoal; }
            set
            {
                if (_distanceToGoal == -1.0) // only set distance once
                    _distanceToGoal = value;
            }
        }

        public int row
        {
            get { return _row; }
        }

        public int col
        {
            get { return _col; }
        }

        public bool blocked
        {
            get { return _blocked; }
        }

        public bool visited
        {
            get { return _visited; }
            set { _visited = value; }
        }

        public Cell parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public bool final
        {
            get { return _final; }
            set { _final = value; }
        }
    }
}
