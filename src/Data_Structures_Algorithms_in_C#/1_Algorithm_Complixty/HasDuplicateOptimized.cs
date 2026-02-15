using System;
using System.Collections.Generic;

public class Solution
{
    public static bool HasDuplicatesOptimized(int[] numbers)
    {
        var seen = new HashSet<int>();
        foreach (int num in numbers)
        {
            if (!seen.Add(num))
            {
                return true;
            }
        }
        return false;
    }
}
