using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Controllers
{
    public class Graph
    {
        // Private member-variables
        // ------------------------

        private uint _factoriesCount = 0;
        private Factory[] _factoriesArray;
        private Link[,] _links2DArray;

        // Constructors
        // ------------

        public Graph(int factoryNumber)
        {
            this._factoriesArray = new Factory[factoryNumber];
            this._links2DArray = new Link[factoryNumber, factoryNumber];
        }

        // Accessors
        // ---------

        public uint FactoriesCount { get { return this._factoriesCount; } }
        public Factory[] FactoriesArray { get { return this._factoriesArray; } }
        public Link[,] Links2DArray { get { return this._links2DArray; } }

        public uint EntityIdOfBestFactoryToAttack
        {
            get { return 1; }
        }

        // Public Methods
        // --------------

        public uint MyNearestFactoryOf(uint EntityIdOfNotMineFactory) // But soon ...
        {
            return 1;
        }

        public uint AmountOfMyTroopsAttacking(uint EntityAFactoryNotMine)
        {
            return 1;
        }

        public void addLink(uint idEntityFirstFactory, uint idEntitySecondFactory, uint timeTravel)
        {
            int indiceFirstFactory = this.getFactoryIndice(idEntityFirstFactory);
            int indiceSecondFactory = this.getFactoryIndice(idEntitySecondFactory);

            if (indiceFirstFactory == -1)
            {
                indiceFirstFactory = (int)this._factoriesCount++;
                this._factoriesArray[indiceFirstFactory] = new Factory(idEntityFirstFactory);
            }

            if (indiceSecondFactory == -1)
            {
                indiceSecondFactory = (int)this._factoriesCount++;
                this._factoriesArray[indiceSecondFactory] = new Factory(idEntitySecondFactory);
            }

            this._links2DArray[indiceFirstFactory, indiceSecondFactory] = new Link(timeTravel, this._factoriesArray[indiceFirstFactory], this._factoriesArray[indiceSecondFactory]);
            this._links2DArray[indiceSecondFactory, indiceFirstFactory] = new Link(timeTravel, this._factoriesArray[indiceSecondFactory], this._factoriesArray[indiceFirstFactory]);
        }

        public void addDataToFactory(uint idFactory, int owner, uint numOfCyborg, uint lvlProd)
        {
            this._factoriesArray[this.getFactoryIndice(idFactory)].addData(owner, numOfCyborg, lvlProd);
        }

        public void addTroop(uint idEntity, int owner, uint firstFactory, uint secondFactory, uint numOfCyborgs, uint remainingTurns)
        {
            int indiceFirstFactory = this.getFactoryIndice(firstFactory);
            int indiceSecondFactory = this.getFactoryIndice(secondFactory);

            this._links2DArray[indiceFirstFactory, indiceSecondFactory].addTroop(idEntity, owner, this._factoriesArray[indiceFirstFactory], this._factoriesArray[indiceSecondFactory], numOfCyborgs, remainingTurns);
        }

        public void clean()
        {
            foreach (Link link in this._links2DArray)
                link.clean();
        }

        private int getFactoryIndice(uint idFactory)
        {
            uint cpt = 0;

            while (cpt < this._factoriesArray.Length)
            {
                if (this._factoriesArray[cpt].IdEntity == idFactory)
                    return (int)cpt;
                cpt++;
            }

            return -1;
        }
    }
}
