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
            // this is maze one
            // "S" means start
            // "." means open cell
            // "#" means closed cell
            // "E" means end
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

            string mazeTwo = "..........," +
                             ".####.###.," +
                             ".#..#.###.," +
                             "...##S###.," +
                             "###.#####.," +
                             "..........," +
                             "#.#######.," +
                             "#.##E#....," +
                             "#.##.####.," +
                             "...#......";

            while(true)
            {
                // introduction
                Console.WriteLine("=======================================");
                Console.WriteLine("Welcome to Brian Tran's A* Maze Solver!");
                Console.WriteLine("Type one of the following numbers:");
                Console.WriteLine("1 - Help");
                Console.WriteLine("2 - Solve Maze One");
                Console.WriteLine("3 - Solve Maze Two");
                Console.WriteLine("4 - Close the program.");
                Console.WriteLine("=======================================");

                Console.Write("Input:");
                string cmd = Console.ReadLine();

                MazeSolver solver = new MazeSolver();
                switch (cmd)
                {
                    case "1":
                        // show legend
                        Console.WriteLine("\n==Maze reference==");
                        Console.WriteLine("S - start");
                        Console.WriteLine(". - open cell");
                        Console.WriteLine("# - closed cell");
                        Console.WriteLine("E - end\n");

                        Console.WriteLine("===A* reference===");
                        Console.WriteLine("c - current cell");
                        Console.WriteLine("v - visited cell");
                        Console.WriteLine("+ - final path\n");
                        break;
                    case "2":
                        // solve maze on
                        solver.setData(mazeOne);
                        solver.solve();
                        break;
                    case "3":
                        // solve maze two
                        solver.setData(mazeTwo);
                        solver.solve();
                        break;
                    case "4":
                        // exit the program
                        return;
                    default:
                        Console.WriteLine("\n================");
                        Console.WriteLine("Invalid command.");
                        Console.WriteLine("================\n");
                        break;
                }
            }
        }
    }
}
