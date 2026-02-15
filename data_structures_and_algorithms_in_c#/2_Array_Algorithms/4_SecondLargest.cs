using System;

public class Solution
{
    public static int SecondLargest(int[] arr)
    {
        int largest = int.MinValue;
        int secondlargest = -1;
        if (arr.Length > 0)
            largest = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > largest)
            {
                secondlargest = largest;
                largest = arr[i];
            }
            else if (arr[i] > secondlargest && arr[i] != largest)
            {
                secondlargest = arr[i];
            }
        }
        return secondlargest;
    }
}
