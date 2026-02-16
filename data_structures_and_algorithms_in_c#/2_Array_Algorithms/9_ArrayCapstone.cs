using System;
using System.Collections.Generic;

public class Solution
{
    private static void ReverseSection(int[] data, int start, int end)
    {
        while (start < end)
        {
            int temp = data[start];
            data[start] = data[end];
            data[end] = temp;
            start++;
            end--;
        }
    }
    
    public static int[] ArrayCapstone(int[] arr, int rotateBy, int target)
    {
        if (arr.Length == 0) return new int[] { -1, -1 };
        
        // Step 1: Rotate right by rotateBy positions
        int k = rotateBy % arr.Length;
        if (k > 0)
        {
            ReverseSection(arr, 0, arr.Length - 1);
            ReverseSection(arr, 0, k - 1);
            ReverseSection(arr, k, arr.Length - 1);
        }
        
        // Step 2: Move zeroes to end
        int ptr = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                arr[ptr] = arr[i];
                ptr++;
            }
        }
        for (int i = ptr; i < arr.Length; i++)
        {
            arr[i] = 0;
        }
        
        // Step 3: Two Sum
        Dictionary<int, int> mp = new();
        for (int i = 0; i < arr.Length; i++)
        {
            int complement = target - arr[i];
            if (mp.ContainsKey(complement))
            {
                return new int[] { mp[complement], i };
            }
            if (!mp.ContainsKey(arr[i]))
            {
                mp.Add(arr[i], i);
            }
        }
        
        return new int[] { -1, -1 };
    }
}
