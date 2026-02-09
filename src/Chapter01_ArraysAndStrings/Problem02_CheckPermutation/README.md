# Problem 1.2: Check Permutation

## 📋 Problem Statement

**Given two strings, write a method to decide if one is a permutation of the other.**

---

## 💡 Solutions

### Approach 1: Sort the Strings

If two strings are permutations, they have the same characters in different orders. Sorting them puts characters in the same order.

| Complexity | Value |
|------------|-------|
| **Time** | O(N log N) |
| **Space** | O(N) |

```csharp
public static bool UsingSorting(string s1, string s2)
{
    if (s1.Length != s2.Length) return false;
    
    var c1 = s1.ToCharArray();
    var c2 = s2.ToCharArray();
    
    Array.Sort(c1);
    Array.Sort(c2);
    
    return new string(c1) == new string(c2);
}
```

---

### Approach 2: Character Count (Efficient)

Check if the two strings have identical character counts. We can use an array (for ASCII) or a Hash Map (for Unicode).

| Complexity | Value |
|------------|-------|
| **Time** | O(N) |
| **Space** | O(1) |

```csharp
public static bool UsingCharCount(string s1, string s2)
{
    if (s1.Length != s2.Length) return false;
    
    int[] letters = new int[128]; // Assumption: ASCII
    
    foreach (char c in s1) letters[c]++;
    
    foreach (char c in s2) {
        letters[c]--;
        if (letters[c] < 0) return false;
    }
    
    return true;
}
```

---

## 🧪 Test Cases

| String 1 | String 2 | Expected | Explanation |
|----------|----------|----------|-------------|
| "abc" | "cba" | `true` | Reverse order is a permutation |
| "test" | "estt" | `true` | Same characters |
| "dog" | "god" | `true` | Permutation |
| "dog" | "dog " | `false` | Different lengths (whitespace matters) |
| "dog" | "God" | `false` | Case sensitive |
| "abc" | "abd" | `false` | Different characters |

---

## 🔑 Key Insights

1.  **Clarify Assumptions:**
    -   Is the comparison case-sensitive? (Usually yes: "God" != "dog")
    -   Is whitespace significant? (Usually yes: "god " != "dog")
    -   What is the character set? (ASCII vs Unicode)
2.  **Length Check:** Permutations must have the same length.
3.  **Efficiency:** Counting characters O(N) is faster than sorting O(N log N).
