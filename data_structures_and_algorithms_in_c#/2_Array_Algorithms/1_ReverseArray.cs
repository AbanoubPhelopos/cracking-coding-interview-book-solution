using System;

public class Solution
{
    private static void Swap(ref int a,ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    public static int[] ReverseArray(int[] arr)
    {
        int left=0,right=arr.Length-1;
        while(left<right)
        {
            Swap(ref arr[left], ref arr[right]);
            
            right--;
            left++;
        }
        return arr;
    }
}
