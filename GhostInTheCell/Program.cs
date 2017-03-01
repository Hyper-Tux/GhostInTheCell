using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

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
            string[] inputs;
            int factoryCount = int.Parse(Console.ReadLine()); // the number of factories
            Graph graph = new Graph(factoryCount);

            // Game Initialization
            // -------------------

            {
                int linkCount = int.Parse(Console.ReadLine()); // the number of links between factories
                for (int i = 0; i < linkCount; i++)
                {
                    inputs = Console.ReadLine().Split(' ');

                    graph.addLink(uint.Parse(inputs[0]), uint.Parse(inputs[1]), uint.Parse(inputs[2]));
                }
            }

            // Game Loop
            // ---------
            while (true)
            {
                // Start Turn
                // ----------
                {
                    int entityCount = int.Parse(Console.ReadLine()); // the number of entities (e.g. factories and troops)
                    for (int i = 0; i < entityCount; i++)
                    {
                        inputs = Console.ReadLine().Split(' ');

                        if (inputs[1] == "FACTORY")
                            graph.addDataToFactory(
                                uint.Parse(inputs[0]),  // Entity ID
                                int.Parse(inputs[2]),   // player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral
                                uint.Parse(inputs[3]),  // number of cyborgs in the factory
                                uint.Parse(inputs[4])); // factory production (between 0 and 3)
                        else if (inputs[1] == "TROOP")
                            graph.addTroop(
                                uint.Parse(inputs[0]),  // Entity ID
                                int.Parse(inputs[2]),   // arg1: player that owns the troop: 1 for you or -1 for your opponent
                                uint.Parse(inputs[3]),  // arg2: identifier of the factory from where the troop leaves
                                uint.Parse(inputs[4]),  // arg3: identifier of the factory targeted by the troop
                                uint.Parse(inputs[5]),  // arg4: number of cyborgs in the troop(positive integer)
                                uint.Parse(inputs[6])); // arg5: remaining number of turns before the troop arrives(positive integer)
                    }
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