using System;
using System.Collections;

namespace NyTO.Library.Code
{
    /// <summary>
    /// 
    /// </summary>
    public static class Exterminator
    {
        /// <summary>
        /// This method has an error at values.RemoveAt(i), we can't work with
        /// the index in this way, because we reduce the array but the index keep
        /// incrementing through the collection. Another serious problem would be
        /// when trying to access an index out of bounds.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="value"></param>
        public static ArrayList Exterminate(ArrayList values, object value)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            for (var i = 0; i < values.Count; i++)
            {
                if (values[i].Equals(value))
                {
                    // as we delete we are gonna mess up the index
                    values.RemoveAt(i);
                }
            }

            return values;
        }

        /// <summary>
        /// In this version, once we find the value to be deleted we also decrement the index,
        /// ensuring  that we will go through all items in the collection
        /// </summary>
        /// <param name="values"></param>
        /// <param name="value"></param>
        public static ArrayList ExterminateV2(ArrayList values, object value)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            for (var i = 0; i < values.Count; i++)
            {
                if (values[i].Equals(value))
                {
                    values.RemoveAt(i);
                    // as we are removing from a list we need to go back the index
                    i--; 
                }
            }

            return values;
        }

        /// <summary>
        /// Personally, I prefer the following approach, because it relies on a solution where
        /// we don't need to update the index while searching for the values. However, we need to
        /// create another array list to keep tracking the good items. Once we do not need to take
        /// care about the space in memory, it would be good.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="value"></param>
        public static ArrayList ExterminateV3(ArrayList values, object value)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            var cleanedList = new ArrayList();

            foreach (var t in values)
            {
                if (t.Equals(value)) continue;
                cleanedList.Add(t);
            }

            return cleanedList;
        }
    }
}
