using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Players
{
    public enum TeamEnum { Ally, Enemy, Neutral, Players, EnemyAndNeutral, AllyAndNeutral, All }

    public class Team
    {
        private Owner[] ownerArray;

        private TeamEnum teamEnum;

        public TeamEnum TeamEnum { get { return this.TeamEnum; } }

        private Team(Owner[] owners, TeamEnum teamEnum)
        { this.ownerArray = owners; this.teamEnum = teamEnum; }

        private static Team ally = new Team(new Owner[] { Owner.Me }, TeamEnum.Ally);
        private static Team enemy = new Team(new Owner[] { Owner.Ennemy }, TeamEnum.Enemy);
        private static Team neutral = new Team(new Owner[] { Owner.Neutral }, TeamEnum.Neutral);

        private static Team players = new Team(new Owner[] { Owner.Me, Owner.Ennemy }, TeamEnum.Players);
        private static Team enemyAndNeutral = new Team(new Owner[] { Owner.Ennemy, Owner.Neutral }, TeamEnum.EnemyAndNeutral);
        private static Team allyAndNeutral = new Team(new Owner[] { Owner.Me, Owner.Neutral }, TeamEnum.AllyAndNeutral);

        private static Team all = new Team(new Owner[] { Owner.Me, Owner.Neutral, Owner.Ennemy }, TeamEnum.All);

        public static Team Ally { get { return ally; } }
        public static Team Enemy { get { return enemy; } }
        public static Team Neutral { get { return neutral; } }

        public static Team Player { get { return players; } }
        public static Team EnemyAndNeutral { get { return enemyAndNeutral; } }
        public static Team AllyAndNeutral { get { return allyAndNeutral; } }

        public static Team All { get { return all; } }

        public List<Factory> Factories { get { return this.ownerArray.Select(o => o.Factories).MergeToList(); } }

        public Factory GetRandomFactory()
        {
            if (this.Factories == null || this.Factories.Count == 0)
                return null;
            return this.Factories[new Random().Next(0, this.Factories.Count - 1)];
        }
    }
}
