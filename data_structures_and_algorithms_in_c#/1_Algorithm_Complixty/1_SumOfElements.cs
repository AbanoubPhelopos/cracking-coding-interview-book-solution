using System;

public class Solution
{
    public static int SumArray(int[] numbers)
    {
        int sum=0;
        foreach (var item in numbers)
        {
            sum+=item;
        }
        return sum;
    }
}
