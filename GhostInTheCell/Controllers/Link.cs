using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Controllers
{
    public class Link
    {
        // Private member-variables
        // ------------------------
        private uint _timeTravel;
        private Factory _firstFactory;
        private Factory _secondFactory;
        private List<Troop> _listOfTroop;

        // Constructors
        // ------------

        public Link(uint timeTravel, Factory firstFactory, Factory secondFactory)
        {
            this._timeTravel = timeTravel;
            this._firstFactory = firstFactory;
            this._secondFactory = secondFactory;
        }

        // Accessors
        // ---------

        public uint TimeTravel { get { return this._timeTravel; } }
        public Factory FirstFactory { get { return this._firstFactory; } }
        public Factory SecondFactory { get { return this._secondFactory; } }
        public List<Troop> ListOfTroop { get { return this._listOfTroop; } }

        public void addTroop(uint idEntity, int owner, Factory firstFactory, Factory secondFactory, uint numOfCyborgs, uint remainingTurns)
        {
            this._listOfTroop.Add(new Troop(idEntity, owner, firstFactory, secondFactory, numOfCyborgs, remainingTurns, this));
        }

        public void clean()
        {
            this._listOfTroop.Clear();
        }
    }
}
