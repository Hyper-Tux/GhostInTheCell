using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Controllers
{
    public class Troop : Entity
    {
        // Private member-variables
        // ------------------------

        // arg2: identifier of the factory from where the troop leaves
        private Factory _firstFactory;
        // arg3: identifier of the factory targeted by the troop
        private Factory _secondFactory;
        // arg5: remaining number of turns before the troop arrives(positive integer)
        private uint _remainingTurns;

        private Link _attachedLink;

        // Constructors
        // ------------

        public Troop(uint id, int owner, Factory leavingFactory, Factory targetedFactory, uint numOfCyborgs, uint remainingTurns, Link attachedLink)
            : base(id, owner, numOfCyborgs)
        {
            this._firstFactory = leavingFactory;
            this._secondFactory = targetedFactory;
            this._remainingTurns = remainingTurns;
            this._attachedLink = attachedLink;
        }

        // Accessors
        // ---------

        public Factory FirstFactory { get { return this._firstFactory; } }
        public Factory SecondFactory { get { return this._secondFactory; } }
        public uint RemainingTurns { get { return this._remainingTurns; } }
        public Link AttachedLink { get { return this._attachedLink; } }
    }
}
