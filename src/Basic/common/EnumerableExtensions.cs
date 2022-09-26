namespace IJKD.dotNetFramework.Example.common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static T Median<T>(this IEnumerable<T> coll, MidpointRounding rounding = MidpointRounding.AwayFromZero)
        {
            var orderedColl = coll.OrderBy(x => x);
            int maxIndex = orderedColl.Count() - 1;
            if (maxIndex % 2 == 0)  // even count but odd maxIndex
            {
                return orderedColl.ElementAt(maxIndex / 2);
            }
            else
            {
                // odd count but even maxIndex
                int midIndex = (int) Math.Round((double) (maxIndex / 2), rounding);
                return orderedColl.ElementAt(midIndex);
            }
        }

        public static void AddRange<T>(this IList list, IEnumerable<T> coll)
        {
            foreach (var item in coll)
                list.Add(item);
        }
    }
}