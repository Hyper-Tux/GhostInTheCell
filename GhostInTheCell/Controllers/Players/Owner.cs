using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Players
{
    public enum OwnerEnum : int { Me = 1, Neutral = 0, Opponent = -1 }

    public class Owner
    {
        private OwnerEnum codePlayer;

        private Owner(OwnerEnum code)
        { this.codePlayer = code; }

        private static Owner me = new Owner(OwnerEnum.Me);
        private static Owner neutral = new Owner(OwnerEnum.Neutral);
        private static Owner ennemy = new Owner(OwnerEnum.Opponent);

        public static Owner Me { get { return me; } }
        public static Owner Neutral { get { return neutral; } }
        public static Owner Ennemy { get { return ennemy; } }

        public List<Factory> Factories { get { return Factory.Factories.Where(f => f.Owner == this.codePlayer).ToList(); } }

        public Factory GetRandomFactory()
        {
            if (this.Factories == null || this.Factories.Count == 0)
                return null;
            return this.Factories[new Random().Next(0, this.Factories.Count - 1)];
        }
    }
}
