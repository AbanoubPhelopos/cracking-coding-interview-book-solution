using System;

public class Solution
{
    public static string ClassifyComplexity(string algorithm)
    {
        switch (algorithm.ToLower())
        {
            case "array_access":
            case "hash_lookup":
            case "stack_push":
            case "stack_pop":
                return "O(1)";
            
            case "binary_search":
            case "balanced_tree_search":
                return "O(log n)";

            case "linear_search":
            case "find_max":
            case "array_sum":
                return "O(n)";

            case "merge_sort":
            case "heap_sort":
            case "quicksort_average":
                return "O(n log n)";

            case "bubble_sort":
            case "selection_sort":
            case "insertion_sort":
                return "O(n^2)";

            default:
                return "Unknown";
        }
    }
}
