using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Controllers
{
    public enum PlayerEnum { Ally, Vilain, Both }

    public class Player
    {
        private Owner[] ownerArray;
        private PlayerEnum playerEnum;

        public PlayerEnum PlayerEnum { get { return this.playerEnum; } }

        private Player(Owner[] owners, PlayerEnum playerEnum)
        { this.ownerArray = owners; this.playerEnum = playerEnum; }

        private static Player ally = new Player(new Owner[] { Owner.Me }, PlayerEnum.Ally);
        private static Player vilain = new Player(new Owner[] { Owner.Ennemy }, PlayerEnum.Vilain);
        private static Player both = new Player(new Owner[] { Owner.Me, Owner.Ennemy }, PlayerEnum.Both);

        public static Player Ally { get { return ally; } }
        public static Player Vilain { get { return vilain; } }
        public static Player Both { get { return Both; } }

        public List<Factory> Factories { get { return this.ownerArray.Select(o => o.Factories).MergeToList(); } }

        public Factory GetMostCrowdedFactory() { return this.Factories.OrderBy(f => f.Units).ToList()[0]; }
    }
}
