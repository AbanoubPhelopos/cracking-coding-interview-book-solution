using System;

public class Solution
{
    public static int[] CompareOperationCounts(int n)
    {
        int[] ans= new int[2];
        for(int i=0;i<n;i++)
        {
            ans[0]++;
        }
        for(int i=0;i<n;i++)
        {
            for(int j=0;j<n;j++)
            {
                ans[1]++;
            }
        }
        return ans;
    }
}
