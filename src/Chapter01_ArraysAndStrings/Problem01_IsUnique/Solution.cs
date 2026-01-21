namespace CrackingTheCode.Chapter01.Problem01;

/// <summary>
/// Problem 1.1: Is Unique
/// Implement an algorithm to determine if a string has all unique characters.
/// What if you cannot use additional data structures?
/// </summary>
public static class IsUnique
{
    /// <summary>
    /// Approach 1: Using HashSet
    /// - Create a HashSet to track seen characters
    /// - Iterate through each character in the string
    /// - If character already exists in set, return false
    /// - Otherwise, add it to the set
    /// 
    /// Time Complexity: O(n) where n is the length of the string
    /// Space Complexity: O(n) for the HashSet (or O(1) if we consider fixed character set)
    /// </summary>
    public static bool UsingHashSet(string str)
    {
        if (string.IsNullOrEmpty(str))
            return true;

        var seen = new HashSet<char>();

        foreach (char c in str)
        {
            if (!seen.Add(c))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Approach 2: Without Additional Data Structures (Bit Vector)
    /// - Use an integer as a bit vector (32 bits)
    /// - Each bit represents whether a character has been seen
    /// - Assumes string only contains lowercase a-z (26 characters)
    /// 
    /// Time Complexity: O(n) where n is the length of the string
    /// Space Complexity: O(1) - only uses a single integer
    /// </summary>
    public static bool UsingBitVector(string str)
    {
        if (string.IsNullOrEmpty(str))
            return true;

        // If string length > 26, there must be duplicates (pigeonhole principle)
        if (str.Length > 26)
            return false;

        int checker = 0;

        foreach (char c in str)
        {
            int val = c - 'a';

            // Check if bit at position 'val' is already set
            if ((checker & (1 << val)) > 0)
                return false;

            // Set the bit at position 'val'
            checker |= (1 << val);
        }

        return true;
    }

    /// <summary>
    /// Approach 3: Brute Force - No Additional Data Structures
    /// - Compare every character with every other character
    /// - Simple but inefficient
    /// 
    /// Time Complexity: O(n²) where n is the length of the string
    /// Space Complexity: O(1)
    /// </summary>
    public static bool UsingBruteForce(string str)
    {
        if (string.IsNullOrEmpty(str))
            return true;

        for (int i = 0; i < str.Length; i++)
        {
            for (int j = i + 1; j < str.Length; j++)
            {
                if (str[i] == str[j])
                    return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Approach 4: Sort and Check Adjacent
    /// - Sort the string first
    /// - Check if any adjacent characters are the same
    /// 
    /// Time Complexity: O(n log n) for sorting
    /// Space Complexity: O(n) for the sorted array
    /// </summary>
    public static bool UsingSorting(string str)
    {
        if (string.IsNullOrEmpty(str))
            return true;

        char[] chars = str.ToCharArray();
        Array.Sort(chars);

        for (int i = 0; i < chars.Length - 1; i++)
        {
            if (chars[i] == chars[i + 1])
                return false;
        }

        return true;
    }
}
