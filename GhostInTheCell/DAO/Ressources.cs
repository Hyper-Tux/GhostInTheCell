using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.DAO
{
    public class Ressources : Utils.Singleton<Ressources>
    {
        private int factoryCount;
        private int linkCount;
        private int entityCount;

        private List<LinkDAO> listOfLinkDAO = new List<LinkDAO>();
        private List<FactoryDAO> listOfFactoriesDAO = new List<FactoryDAO>();
        private List<TroopDAO> listOfTroopsDAO = new List<TroopDAO>();
        private List<BombDAO> listOfBombDAO = new List<BombDAO>();

        private void addLinkDAO(string[] inputs)
        {
            this.listOfLinkDAO.Add(new LinkDAO(uint.Parse(inputs[0]), uint.Parse(inputs[1]), uint.Parse(inputs[2])));
        }

        private void addEntityDAO(string[] inputs)
        {
            if (inputs[1] == "FACTORY")
                this.listOfFactoriesDAO.Add(new FactoryDAO(
                    uint.Parse(inputs[0]),  // Entity ID
                    int.Parse(inputs[2]),   // player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral
                    uint.Parse(inputs[3]),  // number of cyborgs in the factory
                    uint.Parse(inputs[4]),  // factory production (between 0 and 3)
                    uint.Parse(inputs[5])   // number of turns before the factory starts producing again (0 means that the factory produces normally)
                    ));
            else if (inputs[1] == "TROOP")
                this.listOfTroopsDAO.Add(new TroopDAO(
                    uint.Parse(inputs[0]),  // Entity ID
                    int.Parse(inputs[2]),   // player that owns the troop: 1 for you or -1 for your opponent
                    uint.Parse(inputs[3]),  // identifier of the factory from where the troop leaves
                    uint.Parse(inputs[4]),  // identifier of the factory targeted by the troop
                    uint.Parse(inputs[5]),  // number of cyborgs in the troop(positive integer)
                    uint.Parse(inputs[6])   // remaining number of turns before the troop arrives(positive integer)
                    ));
            else if (inputs[1] == "BOMB")
                this.listOfBombDAO.Add(new BombDAO(
                    uint.Parse(inputs[0]),   // Entity ID
                    int.Parse(inputs[2]),    // player that send the bomb: 1 if it is you, -1 if it is your opponent
                    uint.Parse(inputs[3]),   // identifier of the factory from where the bomb is launched
                    uint.Parse(inputs[4]),   // identifier of the targeted factory if it's your bomb, -1 otherwise
                    uint.Parse(inputs[5])    // remaining number of turns before the bomb explodes (positive integer) if that's your bomb, -1 otherwise
                    ));
        } 

        public void initGame()
        {
            this.factoryCount = int.Parse(Console.ReadLine()); // The number of factories on the map
            this.linkCount = int.Parse(Console.ReadLine()); // the number of links between factories

            for (int i = 0; i < linkCount; i++)
                this.addLinkDAO(Console.ReadLine().Split(' '));
        }

        public void initTurn()
        {
            this.entityCount = int.Parse(Console.ReadLine()); // the number of entities (e.g. factories and troops)

            for (int i = 0; i < entityCount; i++)
                this.addEntityDAO(Console.ReadLine().Split(' '));
        }
    }
}
