using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Controllers
{
    public abstract class Entity
    {
        // Private member-variables
        // ------------------------

        // Unique identifier of the factory
        private uint _idEntity;
        //  player that owns the Entity : 1 for you, -1 for your opponent and 0 if neutral
        protected int _owner;
        //  number of cyborgs in the factory
        protected uint _numOfCyborgs;

        // Constructors
        // ------------

        public Entity(uint id)
        {
            this._idEntity = id;
        }

        //public Entity(uint id, int owner, uint numOfCyborgs)
        //    : this(id)
        //{
        //    this._owner = owner;
        //    this._numOfCyborgs = numOfCyborgs;
        //}

        // Accessors
        // ---------

        public uint IdEntity { get { return this._idEntity; } }
        public int Owner { get { return this._owner; } }
        public uint NumOfCyborgs { get { return this._numOfCyborgs; } }

        public bool IsMine { get { return (this._owner == 1); } }
        public bool IsNeutral { get { return (this._owner == 0); } }
        public bool IsAdverse { get { return (this._owner == -1); } }

        public override bool Equals(Object obj)
        {
            Entity entityObj = obj as Entity;
            if (entityObj == null)
                return false;
            else
                return this._idEntity.Equals(entityObj._idEntity);
        }

        public override int GetHashCode()
        {
            return (int)this._idEntity;
        }
    }
}
