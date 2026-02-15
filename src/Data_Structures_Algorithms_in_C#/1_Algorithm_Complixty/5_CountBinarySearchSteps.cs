using System;

public class Solution
{
    public static int CountBinarySearchSteps(int[] sortedArray, int target)
    {
        int left=0,right=sortedArray.Length-1,mid,ans=0;
        while(left<=right)
        {
            ans++;
            mid = (right+left)/2;
            if(sortedArray[mid]==target)
            break;
            else if(sortedArray[mid]>target)
            right=mid-1;
            else
            left=mid+1;
            
        }
        return ans;
    }
}
