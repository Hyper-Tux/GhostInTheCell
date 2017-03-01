using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Utils
{
    public abstract class Singleton<T> where T : new()
    {
        protected static T _singletonInstance;
        public static T I
        {
            get
            {
                if (_singletonInstance == null)
                    _singletonInstance = new T();
                return _singletonInstance;
            }
            set { _singletonInstance = value; }
        }
    }
}
