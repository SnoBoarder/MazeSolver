using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class Program
    {
        static void Main(string[] args)
        {
            string mazeOne = "####S#....," +
                             "...#.##.#.," +
                             "##.#.##.#.," +
                             "##.#.##.#.," +
                             "##......#.," +
                             "#######.#.," +
                             "E.#####.##," +
                             "#.........," +
                             "########.#," +
                             "####.....#";

            MazeSolver solver = new MazeSolver();
            solver.setData(mazeOne);

            while(true)
            {

            }
        }
    }
}
