# Array Algorithms

# Part 1: Reverse an Array 

## The Two-Pointer Technique
The two-pointer technique is a fundamental algorithm pattern where you use two indices to traverse a data structure from different positions, often from both ends moving toward the center.

### How It Works for Reversing
```csharp
// Start with pointers at opposite ends
int left = 0;              // Points to first element
int right = arr.Length - 1; // Points to last element

// Move pointers toward each other
while (left < right)
{
    // Swap elements at left and right positions
    // Move left forward, right backward
}
```

### Swapping Elements
To swap two elements, you need a temporary variable:

```csharp
// Swap arr[i] and arr[j]
int temp = arr[i];
arr[i] = arr[j];
arr[j] = temp;
```

### Visual Example
```
Original: [1, 2, 3, 4, 5]
           ^           ^
          left       right

After swap: [5, 2, 3, 4, 1]
              ^     ^
            left  right

After swap: [5, 4, 3, 2, 1]
                 ^
            left=right (stop!)
```

## Your Task
Implement ReverseArray using the two-pointer technique to reverse the array in-place. Do not use Array.Reverse() or any built-in reverse methods like LINQ's .Reverse().

### Method Signature
```csharp
public static int[] ReverseArray(int[] arr)
```

### Expected Results
```
ReverseArray([1, 2, 3, 4, 5]) -> [5, 4, 3, 2, 1]
ReverseArray([10, 20]) -> [20, 10]
ReverseArray([7]) -> [7]
```

# Part 2: Find Duplicates 

## Finding Duplicates with HashSet
Detecting duplicate values is a common task in data processing. Whether you're validating user input, cleaning datasets, or finding repeated entries in logs, efficiently identifying duplicates is essential. A HashSet provides O(1) lookup time, making it ideal for tracking which values you've already encountered.

### How It Works
The strategy uses two HashSets working together:

- **Seen set**: Tracks every unique value encountered so far
- **Duplicates set**: Tracks values we've already identified as duplicates  

As you traverse the array, each element is checked against the "seen" set. If it's already there, it's a duplicate. The "duplicates" set prevents adding the same duplicate value multiple times to your result.

### Syntax
```csharp
// Creating a HashSet
HashSet<int> mySet = new HashSet<int>();

// Adding elements (returns true if added, false if already exists)
bool wasAdded = mySet.Add(value);

// Checking if element exists - O(1) operation
bool exists = mySet.Contains(value);
```

### Examples
```csharp
// Example 1: Tracking seen characters in a string
HashSet<char> seenChars = new HashSet<char>();
string word = "hello";
foreach (char c in word)
{
    if (!seenChars.Add(c))
    {
        Console.WriteLine($"'{c}' is a repeat!");
    }
}
// Output: 'l' is a repeat!

// Example 2: Finding common elements between two arrays
HashSet<string> setA = new HashSet<string> { "apple", "banana", "cherry" };
string[] listB = { "banana", "date", "cherry", "fig" };
List<string> common = new List<string>();
foreach (string item in listB)
{
    if (setA.Contains(item))
    {
        common.Add(item);
    }
}
// common contains: ["banana", "cherry"]
```

### Common Patterns
| Pattern | Description |
| :--- | :--- |
| set.Add(x) returns false | Element already exists in set |
| set.Contains(x) | Check membership without modifying |
| Two-set tracking | Use one set for "seen", another to avoid duplicate results |

## Your Task
Write a method that finds all duplicate values in an integer array. A value is a duplicate if it appears more than once. Return the duplicates in the order they are first identified as duplicates (i.e., the second time you see them).

### Requirements:
- Use a HashSet to track values you've seen
- Use another HashSet to ensure each duplicate is only added to the result once
- Return the duplicates as an array in discovery order
- If there are no duplicates, return an empty array
- Do not use LINQ methods - solve this using HashSet operations and loops

### Method Signature
```csharp
public static int[] FindDuplicates(int[] arr)
```

### Expected Results
```
FindDuplicates([1, 3, 2, 3, 1, 5]) -> [3, 1]
FindDuplicates([1, 2, 3, 4, 5]) -> []
FindDuplicates([5, 5, 5, 5]) -> [5]
```
