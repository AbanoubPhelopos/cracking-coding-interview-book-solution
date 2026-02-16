using System;
using System.Collections.Generic;

public class Solution
{
    public static int[] TwoSum(int[] numbers, int target)
    {
        List<int> ans = new();
        Dictionary<int, int> mp = new();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (!mp.ContainsKey(numbers[i]))
            {
                mp.Add(numbers[i], i);
            }
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            if (mp.ContainsKey(target - numbers[i]))
            {
                if (mp[target - numbers[i]] != i)
                {
                    ans.Add(i);
                    ans.Add(mp[target - numbers[i]]);
                    break;
                }
            }
        }
        return ans.ToArray();

    }
}
