using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInTheCell.Utils
{
    public static class LinQUtils
    {
        public static List<T> MergeToList<T>(this IEnumerable<IEnumerable<T>> source)
        {
            List<T> newList = new List<T>();

            foreach (IEnumerable<T> collection in source)
                foreach (T item in collection)
                    newList.Add(item);

            return newList;
        }
    }
}
