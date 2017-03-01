using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using GhostInTheCell.DAO;

namespace GhostInTheCell.Controllers
{
    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/

    class Program
    {
        static void Main(string[] args)
        {
            Ressources R = Ressources.Instance;
            // the number of factories
            // Graph graph = new Graph(factoryCount);

            // Game Initialization
            // -------------------

            R.initGame();
            // Game Loop
            // ---------
            while (true)
            {
                // Start Turn
                // ----------
                {
                    
                }

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                // Any valid action, such as "WAIT" or "MOVE source destination cyborgs"
                Console.WriteLine("WAIT");


                // End of the turn
                // ---------------
                graph.clean();
            }
        }
    }
}