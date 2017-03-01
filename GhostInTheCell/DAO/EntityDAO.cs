using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.DAO
{
    /// <summary>
    /// Abstract class : Entity (Data Access Object)
    /// </summary>
    public abstract class EntityDAO
    {
        protected uint _id;

        /// <summary>
        /// Entity ID
        /// </summary>
        public uint ID { get { return this._id; } } // 

        /// <summary>
        /// Entity constructor (Data Access Objet)
        /// </summary>
        /// <param name="id">Entity ID</param>
        public EntityDAO(uint id)
        { this._id = id; }
    }
}
