using System;
using System.Collections.Generic;

public class Solution
{
    public static int[] ComplexityCapstone(int[] numbers)
    {
        if (numbers.Length == 0) return new int[] { 0, 0, 0 };

        int[] result = new int[3];

        // 1. Naive Duplicate Check - O(n^2)
        bool naiveFound = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    naiveFound = true;
                    break;
                }
            }
            if (naiveFound) break;
        }
        result[0] = naiveFound ? 1 : 0;

        // 2. HashSet Duplicate Check - O(n)
        bool hashSetFound = false;
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in numbers)
        {
            if (!seen.Add(num))
            {
                hashSetFound = true;
                break;
            }
        }
        result[1] = hashSetFound ? 1 : 0;

        // 3. Binary Search - O(log n)
        // Sort a copy of the input array
        int[] sorted = (int[])numbers.Clone();
        Array.Sort(sorted);
        
        // Find the middle value
        int target = sorted[sorted.Length / 2];
        
        // Count how many comparisons binary search needs to find it
        int binarySearchSteps = 0;
        int left = 0;
        int right = sorted.Length - 1;
        
        while (left <= right)
        {
            binarySearchSteps++;
            int mid = left + (right - left) / 2;
            
            if (sorted[mid] == target)
            {
                break;
            }
            else if (sorted[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        result[2] = binarySearchSteps;

        return result;
    }
}
