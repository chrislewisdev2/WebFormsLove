using System;
using System.Collections.Generic;

namespace WebFormsLove.Helpers
{

    public static class ListExtensions
    {
        public static int FindIndex<T>(this IList<T> list, Func<T, bool> matcher) where T : class, new()
        {
            if (list == null) throw new ArgumentNullException("list");

            for (var i = 0; i < list.Count; i++)
            {
                if(matcher(list[i]))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}