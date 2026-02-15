using System;
using System.Collections.Generic;

public class Solution
{
    public static int[] FindDuplicates(int[] arr)
    {
        List<int> ans = new List<int>();
        HashSet<int> seen = new HashSet<int>();
        HashSet<int> added = new HashSet<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (seen.Contains(arr[i]))
            {
                if (!added.Contains(arr[i]))
                {
                    ans.Add(arr[i]);
                    added.Add(arr[i]);
                }
            }
            else
            {
                seen.Add(arr[i]);
            }
        }

        return ans.ToArray();

    }
}
