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

# Part 3: Move Zeroes to End

## The Write-Pointer Technique
The write-pointer technique is a powerful pattern for rearranging array elements in-place. Instead of creating a new array or swapping elements back and forth, you maintain a single pointer that tracks where the next "valid" element should be written.

This approach is memory-efficient because it modifies the array directly without allocating additional space proportional to the input size.

### How It Works
Imagine you're organizing a bookshelf. You want to move all the empty slots to one end. Instead of shuffling books around repeatedly, you:

1. Start with a marker at position 0 (the write pointer)
2. Walk through each slot from left to right
3. When you find a book (non-empty slot), place it at the marker position and move the marker forward
4. After checking all slots, fill everything from the marker to the end with empty slots

The write pointer always indicates where the next non-empty item should go.

### Syntax
```csharp
// Basic write-pointer pattern
int writePointer = 0;

for (int i = 0; i < arr.Length; i++)
{
    if (/* element meets condition */)
    {
        arr[writePointer] = arr[i];
        writePointer++;
    }
}

// Fill remaining positions with default value
while (writePointer < arr.Length)
{
    arr[writePointer] = defaultValue;
    writePointer++;
}
```

### Examples
```csharp
// Example 1: Move negative numbers to the front
int[] scores = { 5, -2, 8, -1, 3 };
int wp = 0;

for (int i = 0; i < scores.Length; i++)
{
    if (scores[i] < 0)
    {
        scores[wp] = scores[i];
        wp++;
    }
}
// After loop: wp = 2, negative numbers are at front
// Then copy non-negatives after position wp

// Example 2: Remove specific value by overwriting
char[] letters = { 'a', 'x', 'b', 'x', 'c' };
int writePos = 0;

for (int i = 0; i < letters.Length; i++)
{
    if (letters[i] != 'x')
    {
        letters[writePos] = letters[i];
        writePos++;
    }
}
// Result positions 0-2: 'a', 'b', 'c'
// Remaining positions can be filled with a placeholder
```

### Key Insight
The write pointer is always less than or equal to the read position (loop variable). This means we never overwrite an element we haven't processed yet, which is why this technique works safely in-place.

## Your Task
Write a method that moves all zeroes in an integer array to the end while maintaining the relative order of all non-zero elements. The modification must be done in-place.

### Requirements:
- Non-zero elements must keep their original relative order
- All zeroes should appear at the end of the array
- Modify the array in-place and return it
- Use the write-pointer technique (no LINQ or sorting)

### Method Signature
```csharp
public static int[] MoveZeroes(int[] arr)
```

### Expected Results
```
MoveZeroes([0, 1, 0, 3, 12]) -> [1, 3, 12, 0, 0]
MoveZeroes([1, 2, 3]) -> [1, 2, 3]
MoveZeroes([0, 0, 0]) -> [0, 0, 0]
MoveZeroes([1, 0, 1]) -> [1, 1, 0]
```

# Part 4: Second Largest Element

## Single-Pass Tracking with Multiple Variables
Many array problems can be solved efficiently by maintaining a small set of "best so far" variables as you iterate through the data. Instead of sorting the entire collection or making multiple passes, you keep track of the values you care about and update them as you encounter new elements. This is especially useful when you need the top N values from a dataset — think leaderboards, performance monitoring, or statistical analysis.

### How It Works
Imagine you're watching runners cross a finish line one at a time. You don't need to remember every runner's time — you just keep a mental note of the fastest time and the second fastest time. Each time a new runner finishes, you compare their time against your two tracked values and update accordingly.

The key insight is handling the cascade: when a new element beats your current best, the old best doesn't disappear — it becomes the new second best. And when a new element doesn't beat the best but does beat the second best, only the second variable updates.

### Syntax
```csharp
// Initialize tracking variables
int best = int.MinValue;
int secondBest = int.MinValue;

// Single pass through the array
for (int i = 0; i < arr.Length; i++)
{
    // Compare arr[i] against best and secondBest
    // Update in the right order to preserve both values
}
```

### Examples
```csharp
// Finding the two smallest temperatures in a week
int[] temps = {72, 65, 80, 65, 71, 68, 77};
int coldest = int.MaxValue;
int secondColdest = int.MaxValue;

for (int i = 0; i < temps.Length; i++)
{
    if (temps[i] < coldest)
    {
        secondColdest = coldest;  // old best becomes second best
        coldest = temps[i];       // new best
    }
    else if (temps[i] < secondColdest && temps[i] != coldest)
    {
        secondColdest = temps[i]; // new second best (distinct)
    }
}
// coldest = 65, secondColdest = 68

// Notice how duplicates (65 appears twice) are handled:
// The second occurrence of 65 doesn't change either variable
// because it equals coldest and is not less than secondColdest
```

### Common Pitfalls
- **Forgetting the cascade**: When a new maximum is found, the old maximum should shift to the second position — don't just overwrite it.
- **Duplicate values**: If the array contains [8, 8, 8], the largest is 8 but there is no distinct second largest. Your logic must distinguish between "equal to the best" and "a new second best."
- **Edge cases**: Arrays with 0 or 1 elements, or arrays where all elements are identical, have no valid second value.
- **Initialization**: Think carefully about initial values and how to know whether you've actually found valid candidates.

## Your Task
Write a method that finds the second largest distinct value in an integer array using a single pass. You should track the largest and second largest values as you iterate, updating them appropriately when you encounter new values.

If the array has fewer than 2 distinct values (including empty arrays or arrays with all identical elements), return -1.

Remember: the second largest must be strictly less than the largest. For example, in [5, 1, 8, 3, 8], the largest is 8 and the second largest is 5.

### Method Signature
```csharp
public static int SecondLargest(int[] arr)
```

### Expected Results
```
SecondLargest([5, 1, 8, 3, 8]) -> 5
SecondLargest([10, 10, 10]) -> -1
SecondLargest([3, 7]) -> 3
SecondLargest([]) -> -1
```

# Part 5: Two Sum

## Hash-Based Complement Lookup
The Two Sum problem is one of the most well-known algorithmic challenges, and it beautifully demonstrates how a hash map (dictionary) can transform a brute-force O(n²) solution into an efficient O(n) one. The core insight is that instead of checking every pair, you can ask a smarter question: "Have I already seen the number that would complete this pair?"

### How It Works
Imagine you're searching through a list of numbers for two that add up to a target. The naive approach compares every element with every other element — slow for large arrays. A better approach uses a dictionary as a "memory" of what you've already visited.

As you walk through the array, for each number you compute its complement — the value that, when added to the current number, equals the target. Then you check: "Is that complement already in my dictionary?" If yes, you've found your pair. If no, you store the current number and its index in the dictionary for future lookups.

### Syntax
```csharp
// Creating and using a Dictionary<TKey, TValue>
var map = new Dictionary<int, int>();

// Adding an entry: map[key] = value
map[42] = 0;

// Checking if a key exists
if (map.ContainsKey(42))
{
    int storedValue = map[42];
}

// Computing a complement
int complement = target - currentValue;
```

### Examples
```csharp
// Example 1: Finding a pair that sums to 10 in temperatures
// temperatures = [3, 7, 1, 9]
// target = 10
// At index 0: complement = 10 - 3 = 7, not in dict → store {3: 0}
// At index 1: complement = 10 - 7 = 3, found in dict at index 0 → return [0, 1]

// Example 2: The pair isn't always at the start
// scores = [5, 1, 8, 3, 6]
// target = 9
// At index 0: complement = 9 - 5 = 4, not in dict → store {5: 0}
// At index 1: complement = 9 - 1 = 8, not in dict → store {5:0, 1:1}
// At index 2: complement = 9 - 8 = 1, found in dict at index 1 → return [1, 2]

// Example 3: Negative numbers work the same way
// values = [-1, 4, -3, 8]
// target = 5
// At index 0: complement = 5 - (-1) = 6, not in dict → store {-1: 0}
// At index 1: complement = 5 - 4 = 1, not in dict → store {-1:0, 4:1}
// At index 2: complement = 5 - (-3) = 8, not in dict → store {-1:0, 4:1, -3:2}
// At index 3: complement = 5 - 8 = -3, found in dict at index 2 → return [2, 3]
```

### Why Dictionary Over Nested Loops?
| Approach | Time Complexity | Space Complexity |
| :--- | :--- | :--- |
| Nested loops (brute force) | O(n²) | O(1) |
| Dictionary lookup | O(n) | O(n) |

Dictionary lookup trades a small amount of extra memory for a dramatic speedup. The ContainsKey operation is O(1) on average, so the entire algorithm runs in a single pass through the array.

## Your Task
Write a method that takes an array of integers and a target sum, then returns the indices of the two numbers that add up to the target. The returned indices should be in ascending order (smaller index first).

### Assumptions:
- There is always exactly one valid solution
- The same element cannot be used twice (the two indices must be different)
- The array will have at least 2 elements

### Method Signature
```csharp
public static int[] TwoSum(int[] numbers, int target)
```

### Expected Results
```
TwoSum([2, 7, 11, 15], 9)       → [0, 1]
TwoSum([3, 2, 4], 6)            → [1, 2]
TwoSum([1, 5, 3, 7, 2], 9)      → [1, 3]
TwoSum([-1, 0, 1, 2], 1)        → [0, 2]
```

# Part 6: Rotate Array by K

## The Reversal Algorithm for Array Rotation
Rotating an array means shifting every element to the right (or left) by a certain number of positions, with elements that "fall off" one end wrapping around to the other. This operation appears in circular buffers, scheduling algorithms, and image processing. The reversal algorithm is an elegant O(n) time, O(1) space technique that accomplishes rotation using only in-place swaps.

### How It Works
The key insight is that rotation can be decomposed into three reversals. Imagine you have a deck of cards and you want to move the last few cards to the front. If you flip the entire deck upside down, the cards that were at the end are now at the beginning — but everything is backwards. By then flipping the front portion and the back portion separately, each section is restored to its correct order.

The three steps for a right rotation by k positions:
1. **Reverse the entire array** — brings the tail elements to the front, but both halves are now backwards
2. **Reverse the first k elements** — restores the correct order of what was the tail
3. **Reverse the remaining elements** — restores the correct order of what was the head

### Normalizing K
If k is larger than the array length, rotating by k is the same as rotating by `k % length`. For example, rotating a 5-element array by 7 positions is equivalent to rotating by 2 positions. Always normalize k before proceeding.

### Syntax
```csharp
// A helper method to reverse a section of an array between two indices
private static void ReverseSection(int[] data, int start, int end)
{
    while (start < end)
    {
        int temp = data[start];
        data[start] = data[end];
        data[end] = temp;
        start++;
        end--;
    }
}
```

### Examples
```
Consider the string characters ['A', 'B', 'C', 'D', 'E'] rotated right by 3:

Original:           A  B  C  D  E
Reverse all:        E  D  C  B  A
Reverse first 3:    C  D  E  B  A
Reverse last 2:     C  D  E  A  B
Result: The last 3 elements (C, D, E) moved to the front.

Another example — rotating [10, 20, 30, 40] right by 1:

Original:           10  20  30  40
Reverse all:        40  30  20  10
Reverse first 1:    40  30  20  10   (single element, no change)
Reverse last 3:     40  10  20  30
Result: [40, 10, 20, 30] — the last element wrapped to the front.
```

### Edge Cases to Consider
- **k equals 0**: No rotation needed — the array stays as-is
- **k equals the array length**: Full rotation brings everything back to the original position
- **k greater than the array length**: Normalize using the modulo operator
- **Empty array**: Nothing to rotate — return immediately
- **Single element**: Already in its only possible position

## Your Task
Write a method that rotates an integer array to the right by k positions in-place using the reversal algorithm. You must implement your own reverse helper — do not use any built-in reverse or LINQ slicing methods. The method should modify the array in place and return it.

### Method Signature
```csharp
public static int[] RotateArray(int[] arr, int k)
```

### Expected Results
```
RotateArray([1, 2, 3, 4, 5], 2)  -> [4, 5, 1, 2, 3]
RotateArray([1, 2, 3, 4, 5], 5)  -> [1, 2, 3, 4, 5]
RotateArray([10, 20, 30], 1)     -> [30, 10, 20]
RotateArray([], 3)               -> []
```
