using System;

public class Solution
{
    public static bool HasDuplicatesNaive(int[] numbers)
    {
        for(int i=0;i<numbers.Length;i++)
        {
            for(int j=i+1;j<numbers.Length;j++)
            {
                if(numbers[i]==numbers[j])
                {
                    return true;
                }
            }
        }
        return false;
    }
} 
