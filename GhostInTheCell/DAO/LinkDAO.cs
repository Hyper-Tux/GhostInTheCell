using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.DAO
{
    /// <summary>
    /// Class : Link (Data Access Object)
    /// </summary>
    class LinkDAO
    {
        private uint _idFirstFactory;
        private uint _idSecondFactory;
        private uint _timeToTravel;

        /// <summary>
        /// Id of the first factory connected
        /// </summary>
        public uint FirstFactory { get { return this._idFirstFactory; } }
        /// <summary>
        /// Id of the second factory connected
        /// </summary>
        public uint SecondFactory { get { return this._idSecondFactory; } }
        /// <summary>
        /// Number of turns needed for a troop to travel between first factory and second factory
        /// </summary>
        public uint TimeToTravel { get { return this._timeToTravel; } }

        /// <summary>
        /// Link constructor (Data Access Object)
        /// </summary>
        /// <param name="idFirstFactory">Id of the first factory connected</param>
        /// <param name="idSecondFactory">Id of the second factory connected</param>
        /// <param name="timeToTravel">Number of turns needed for a troop to travel between first factory and second factory</param>
        public LinkDAO(uint idFirstFactory, uint idSecondFactory, uint timeToTravel)
        {
            this._idFirstFactory = idFirstFactory;
            this._idSecondFactory = idSecondFactory;
            this._timeToTravel = timeToTravel;
        }
    }
}
