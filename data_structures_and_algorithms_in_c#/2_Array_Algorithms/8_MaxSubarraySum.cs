using System;

public class Solution
{
    public static int MaxSubarraySum(int[] arr)
    {
        int currentMax = arr[0];
        int globalMax = arr[0];
        
        for (int i = 1; i < arr.Length; i++)
        {
            currentMax = Math.Max(arr[i], currentMax + arr[i]);
            globalMax = Math.Max(globalMax, currentMax);
        }
        
        return globalMax;
    }
}
