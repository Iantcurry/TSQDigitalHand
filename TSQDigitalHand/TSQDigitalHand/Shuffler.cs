using System;
using System.Collections.Generic;
using System.Text;

namespace TSQDigitalHand
{
    public static class Shuffler
    {
        public static void Shuffle<T>(this IList<T> list, Random rnd)
        {
            //for (var i = list.Count; i > 0; i--)
            //list.Swap(0, rnd.Next(0, i));
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
