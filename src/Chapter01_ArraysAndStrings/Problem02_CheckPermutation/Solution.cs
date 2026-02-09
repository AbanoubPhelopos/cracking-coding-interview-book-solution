namespace CrackingTheCode.Chapter01.Problem02;

/// <summary>
/// Problem 1.2: Check Permutation
/// Given two strings, write a method to decide if one is a permutation of the other.
/// </summary>
public static class CheckPermutation
{
    /// <summary>
    /// Approach 1: Sort the strings
    /// - Sort both strings
    /// - Compare the sorted strings
    /// 
    /// Time Complexity: O(N log N) + O(M log M) where N and M are lengths of the strings
    /// Space Complexity: O(N) depending on sorting implementation (char array creation)
    /// </summary>
    public static bool UsingSorting(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        var charArray1 = s1.ToCharArray();
        var charArray2 = s2.ToCharArray();

        Array.Sort(charArray1);
        Array.Sort(charArray2);

        // Compare the sorted arrays
        // In newer .NET versions we could use SequenceEqual on Span or just compare the strings made from arrays
        // But let's be explicit loop or string comparison
        for (int i = 0; i < charArray1.Length; i++)
        {
            if (charArray1[i] != charArray2[i])
                return false;
        }

        return true;
    }

    /// <summary>
    /// Approach 2: Check character counts
    /// - Use an array to count character frequencies (assuming ASCII 128)
    /// - Fail fast if lengths differ
    /// - Count chars in first string
    /// - Subtract counts using second string
    /// - If any count goes below zero, it's not a permutation
    /// 
    /// Time Complexity: O(N)
    /// Space Complexity: O(1) (fixed size array of 128 integers)
    /// </summary>
    public static bool UsingCharCount(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        // Assuming ASCII. If extended ASCII, use 256. If Unicode, use a Dictionary<char, int>.
        int[] letters = new int[128];

        foreach (char c in s1)
        {
            letters[c]++;
        }

        foreach (char c in s2)
        {
            letters[c]--;
            if (letters[c] < 0)
            {
                return false;
            }
        }

        return true;
    }
}
