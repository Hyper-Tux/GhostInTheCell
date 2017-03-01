using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.DAO
{
    /// <summary>
    /// Class: Bomb (Data Access Object)
    /// </summary>
    class BombDAO : EntityDAO
    {
        private int _player;
        private uint _idFactorySource;
        private uint _idFactoryDestination;
        private uint _remainingTurns;

        /// <summary>
        /// Player that send the bomb: 1 if it is you, -1 if it is your opponent
        /// </summary>
        public int Player { get { return this._player; } }

        /// <summary>
        /// Identifier of the factory from where the bomb is launched
        /// </summary>
        public uint IDFactorySource { get { return this._idFactorySource; } }

        /// <summary>
        /// Identifier of the targeted factory if it's your bomb, -1 otherwise
        /// </summary>
        public uint IDFactoryDestination { get { return this._idFactoryDestination; } }

        /// <summary>
        /// Remaining number of turns before the bomb explodes (positive integer) if that's your bomb, -1 otherwise
        /// </summary>
        public uint RemainingTurns { get { return this._remainingTurns; } }

        /// <summary>
        /// Bomb constructor (Data Access Object)
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <param name="player">Player that send the bomb: 1 if it is you, -1 if it is your opponent</param>
        /// <param name="idFactorySource">Identifier of the factory from where the bomb is launched</param>
        /// <param name="idFactoryDestination">Identifier of the targeted factory if it's your bomb, -1 otherwise</param>
        /// <param name="remainingTurns">Remaining number of turns before the bomb explodes (positive integer) if that's your bomb, -1 otherwise</param>
        public BombDAO(uint id, int player, uint idFactorySource, uint idFactoryDestination, uint remainingTurns)
            : base(id)
        {
            this._player = player;
            this._idFactorySource = idFactorySource;
            this._idFactoryDestination = idFactoryDestination;
            this._remainingTurns = remainingTurns;
        }
    }
}
