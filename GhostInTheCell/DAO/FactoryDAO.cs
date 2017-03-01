using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.DAO
{
    /// <summary>
    /// Class : Factory (Data Access Object)
    /// </summary>
    class FactoryDAO : EntityDAO
    {
        private int _owner;
        private uint _numberOfCyborgs;
        private uint _factoryProduction;
        private uint _remainingTurns;

        /// <summary>
        /// Player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral
        /// </summary>
        public int Owner { get { return this._owner; } }

        /// <summary>
        /// Number of cyborgs in the factory
        /// </summary>
        public uint NumberOfCyborgs { get { return this._numberOfCyborgs; } }

        /// <summary>
        /// Factory production (between 0 and 3)
        /// </summary>
        public uint FactoryProduction { get { return this._factoryProduction; } }

        /// <summary>
        /// Number of turns before the factory starts producing again (0 means that the factory produces normally)
        /// </summary>
        public uint RemainingTurns { get { return this._remainingTurns; } }

        /// <summary>
        /// Factory constructor (Data Access Object)
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <param name="owner">Player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral</param>
        /// <param name="numberOfCyborgs">Number of cyborgs in the factory</param>
        /// <param name="factoryProduction">Factory production (between 0 and 3)</param>
        /// <param name="remainingTurns">Number of turns before the factory starts producing again (0 means that the factory produces normally)</param>
        public FactoryDAO(uint id, int owner, uint numberOfCyborgs, uint factoryProduction, uint remainingTurns)
            : base(id)
        {
            this._owner = owner;
            this._numberOfCyborgs = numberOfCyborgs;
            this._factoryProduction = factoryProduction;
            this._remainingTurns = remainingTurns;
        }
    }
}
