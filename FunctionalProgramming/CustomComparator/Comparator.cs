namespace CustomComparator
{
    using System.Collections.Generic;

    internal class Comparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            else if (y % 2 == 0 && x % 2 != 0)
            {
                return 1;
            }
            else
            {
                if (x < y)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}