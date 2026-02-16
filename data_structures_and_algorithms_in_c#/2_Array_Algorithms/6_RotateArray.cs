using System;

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
    public static int[] RotateArray(int[] arr, int k)
    {
        if (arr.Length == 0) return arr;
        k = k % arr.Length;
        if (k == 0) return arr;
        
        ReverseSection(arr, 0, arr.Length - 1);
        ReverseSection(arr, 0, k - 1);
        ReverseSection(arr, k, arr.Length - 1);
        
        return arr;
    }
}
