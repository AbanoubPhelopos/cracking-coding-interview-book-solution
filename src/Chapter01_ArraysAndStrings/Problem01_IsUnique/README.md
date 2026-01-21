# Problem 1.1: Is Unique

## 📋 Problem Statement

**Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures?**

---

## 💡 Solutions

### Approach 1: Using HashSet ✅ (Recommended)

Uses a HashSet to track characters we've seen. If we try to add a character that already exists, return false.

| Complexity | Value |
|------------|-------|
| **Time** | O(n) |
| **Space** | O(n) |

```csharp
public static bool UsingHashSet(string str)
{
    var seen = new HashSet<char>();
    foreach (char c in str)
    {
        if (!seen.Add(c))
            return false;
    }
    return true;
}
```

---

### Approach 2: Bit Vector (No Extra Data Structures) 🚀

Uses a single integer as a bit vector. Each bit represents whether a lowercase letter (a-z) has been seen.

| Complexity | Value |
|------------|-------|
| **Time** | O(n) |
| **Space** | O(1) |

```csharp
public static bool UsingBitVector(string str)
{
    int checker = 0;
    foreach (char c in str)
    {
        int val = c - 'a';
        if ((checker & (1 << val)) > 0)
            return false;
        checker |= (1 << val);
    }
    return true;
}
```

> ⚠️ **Note:** This approach only works for lowercase a-z (26 characters) since we use a 32-bit integer.

---

### Approach 3: Brute Force

Compare every character with every other character. Simple but inefficient.

| Complexity | Value |
|------------|-------|
| **Time** | O(n²) |
| **Space** | O(1) |

---

### Approach 4: Sort and Check

Sort the string, then check if any adjacent characters are the same.

| Complexity | Value |
|------------|-------|
| **Time** | O(n log n) |
| **Space** | O(n) |

---

## 🧪 Test Cases

| Input | Expected | Explanation |
|-------|----------|-------------|
| `"abcdef"` | `true` | All unique characters |
| `"hello"` | `false` | 'l' appears twice |
| `""` | `true` | Empty string has no duplicates |
| `"a"` | `true` | Single character is unique |
| `"aA"` | `true` | Case-sensitive: 'a' ≠ 'A' |

---

## 🔑 Key Insights

1. **Clarify assumptions:** Ask if the string is ASCII or Unicode (affects space complexity)
2. **Pigeonhole principle:** If string length > character set size, duplicates must exist
3. **Trade-offs:** HashSet is cleaner, bit vector uses less space for limited character sets
