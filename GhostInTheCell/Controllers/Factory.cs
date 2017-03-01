using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Controllers
{
    public class Factory : Entity
    {
        // Private member-variables
        // ------------------------

        //  factory production (between 0 and 3)
        private uint _lvlProd;

        // Constructors
        // ------------

        public Factory(uint id)
            : base(id)
        { }

        // Accessors
        // ---------

        public uint LvlProd { get { return this._lvlProd; } }

        // Public methods
        // --------------

        public void addData(int owner, uint numOfCyborg, uint lvlProd)
        {
            base._owner = owner;
            base._numOfCyborgs = numOfCyborg;
            this._lvlProd = lvlProd;
        }

        public int Units { get { return 1; } }
        public OwnerEnum Owner { get { return OwnerEnum.Neutral; } }
        public static List<Factory> Factories;
    }
}
