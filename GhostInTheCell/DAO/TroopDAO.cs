using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.DAO
{
    /// <summary>
    /// Class : Troop (Data Access Object
    /// </summary>
    class TroopDAO : EntityDAO
    {
        private int _owner;
        private uint _idFactorySource;
        private uint _idFactoryDestination;
        private uint _numbersOfCyborgs;
        private uint _remainingTurns;

        /// <summary>
        /// Player that owns the troop: 1 for you or -1 for your opponent
        /// </summary>
        public int Owner { get { return this._owner; } }

        /// <summary>
        /// Identifier of the factory from where the troop leaves
        /// </summary>
        public uint IDFactorySource { get { return this._idFactorySource; } }

        /// <summary>
        /// Identifier of the factory targeted by the troop
        /// </summary>
        public uint IDFactoryDestination { get { return this._idFactoryDestination; } }

        /// <summary>
        /// Number of cyborgs in the troop (positive integer)
        /// </summary>
        public uint NumbersOfCyborgs { get { return this._numbersOfCyborgs; } }

        /// <summary>
        /// Remaining number of turns before the troop arrives (positive integer)
        /// </summary>
        public uint RemainingTurns { get { return this._remainingTurns; } }


        /// <summary>
        /// Troop constructor (Data Access Object)
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <param name="owner">Player that owns the troop: 1 for you or -1 for your opponent</param>
        /// <param name="idFactorySource">Identifier of the factory from where the troop leaves</param>
        /// <param name="idFactoryDestination">Identifier of the factory targeted by the troop</param>
        /// <param name="numbersOfCyborgs">Number of cyborgs in the troop (positive integer)</param>
        /// <param name="remainingTurns">Remaining number of turns before the troop arrives (positive integer)</param>
        public TroopDAO(uint id, int owner, uint idFactorySource, uint idFactoryDestination, uint numbersOfCyborgs, uint remainingTurns)
            : base(id)
        {
            this._owner = owner;
            this._idFactorySource = idFactorySource;
            this._idFactoryDestination = idFactoryDestination;
            this._numbersOfCyborgs = numbersOfCyborgs;
            this._remainingTurns = remainingTurns;
        }
    }
}
