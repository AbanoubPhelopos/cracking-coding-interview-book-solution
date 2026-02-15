using System;

public class Solution
{
    public static int[] MoveZeroes(int[] arr)
    {
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
        return arr;
    }
}
