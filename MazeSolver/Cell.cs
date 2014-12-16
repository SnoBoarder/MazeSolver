using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class Cell
    {
        private int _row;
        private int _col;

        private bool _blocked;
        private Cell _parent = null;
        private bool _visited;

        private double _distanceToGoal = -1.0;

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
                if (_distanceToGoal == -1.0)
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
    }
}
