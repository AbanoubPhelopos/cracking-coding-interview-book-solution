# Algorithm Complixty

# Sum of elements 

## Algorithm Complexity & Big O Notation
Big O notation describes how an algorithm's runtime grows as input size increases. It's the universal language for analyzing and comparing algorithms, helping you predict performance and choose the right approach.

### What Does "O" Mean?
The "O" stands for "Order of" and represents the upper bound of growth. When we say an algorithm is O(n), we mean its runtime grows at most proportionally to the input size.

```csharp
// The "n" represents the size of your input
int[] array = new int[1000];  // n = 1000
int[] bigArray = new int[1000000];  // n = 1,000,000
```

### O(n) - Linear Time Complexity
An algorithm is O(n) when it performs a constant amount of work for each element in the input. If you double the input size, the runtime roughly doubles.

```csharp
// O(n) example - visits each element once
for (int i = 0; i < array.Length; i++)
{
    sum += array[i];  // constant work per element
}
```
Real-world analogy: Reading a book is O(n) where n is the number of pages. A 200-page book takes roughly twice as long to read as a 100-page book.

### Common Big O Complexities Compared
| Notation | Name | 10 items | 100 items | 1000 items | Example |
| :--- | :--- | :--- | :--- | :--- | :--- |
| O(1) | Constant | 1 | 1 | 1 | Array index access |
| O(log n) | Logarithmic | 3 | 7 | 10 | Binary search |
| O(n) | Linear | 10 | 100 | 1000 | Sum all elements |
| O(n log n) | Linearithmic | 33 | 664 | 9966 | Efficient sorting |
| O(n²) | Quadratic | 100 | 10,000 | 1,000,000 | Nested loops |

### Code Examples of Each Complexity
```csharp
// O(1) - Constant time
// Doesn't matter if array has 10 or 10 million elements
int first = array[0];
int length = array.Length;

// O(n) - Linear time
// Must touch every element once
int total = 0;
for (int i = 0; i < array.Length; i++)
    total += array[i];

// O(n²) - Quadratic time
// For each element, we look at every other element
for (int i = 0; i < array.Length; i++)
    for (int j = 0; j < array.Length; j++)
        Console.WriteLine($"{array[i]}, {array[j]}");
```

### Why Summing an Array is O(n)
To calculate the sum of all elements, you must examine each element at least once. There's no shortcut - you can't know the total without looking at every value.

```csharp
int[] numbers = {3, 7, 2, 9, 1};

// Step by step - each element visited exactly once:
// Visit index 0: sum = 0 + 3 = 3
// Visit index 1: sum = 3 + 7 = 10
// Visit index 2: sum = 10 + 2 = 12
// Visit index 3: sum = 12 + 9 = 21
// Visit index 4: sum = 21 + 1 = 22
// Total visits: 5 (same as array length)
```

| Array Size | Elements Visited | Time (relative) |
| :--- | :--- | :--- |
| 5 | 5 | 1x |
| 50 | 50 | 10x |
| 500 | 500 | 100x |
| 5,000,000 | 5,000,000 | 1,000,000x |

The relationship is linear - operations grow proportionally with input size.

### Why O(n) Matters
O(n) is often the best possible complexity for problems where you must examine all data. You can't sum an array faster than O(n) because skipping any element means potentially wrong answer.

```csharp
// These are ALL O(n) - one pass through data
int max = FindMax(array);      // Must check all to find largest
int min = FindMin(array);      // Must check all to find smallest
int total = CalculateTotal(array);  // Must add all values
bool found = Contains(array, target);  // Worst case: check all
```

## Your Task
Write a method that calculates the sum of all integers in an array. Your solution will have O(n) complexity because you must examine each element exactly once.

Important: Implement the summation using a loop to understand the O(n) behavior. Built-in LINQ methods like .Sum() or .Aggregate() are not allowed for this exercise.

### Method Signature
```csharp
public static int SumArray(int[] numbers)
```

### Expected Results
```
SumArray([1, 2, 3, 4, 5]) -> 15
SumArray([10, 20, 30]) -> 60
SumArray([-5, 5, -10, 10]) -> 0
```

# Part 2: Has Duplicate Nested Loops

## O(n²) Complexity - Nested Loops
When you have a loop inside another loop, and both iterate over the input, the time complexity becomes O(n²) - quadratic time. The runtime grows with the square of the input size.

### Why Nested Loops Are O(n²)
```csharp
for (int i = 0; i < n; i++)        // Runs n times
{
    for (int j = 0; j < n; j++)    // For each i, runs n times
    {
        // Total: n × n = n² operations
    }
}
```

### Comparing Every Pair
To check if an array has duplicates using nested loops, we compare each element with every element that comes after it:

```csharp
// For array [1, 2, 3, 4]
// i=0: compare 1 with 2, 3, 4  (3 comparisons)
// i=1: compare 2 with 3, 4     (2 comparisons)
// i=2: compare 3 with 4        (1 comparison)
// Total: 3 + 2 + 1 = 6 comparisons
```

### Growth Rate Example
| Array Size | Comparisons (worst case) |
| :--- | :--- |
| 10 | 45 |
| 100 | 4,950 |
| 1,000 | 499,500 |
| 10,000 | 49,995,000 |

## Your Task
Write a method that checks if an array contains duplicate values using nested for loops only. Do not use HashSet, LINQ, or sorting - the goal is to understand O(n²) complexity.

### Method Signature
```csharp
public static bool HasDuplicatesNaive(int[] numbers)
```

### Expected Results
```
HasDuplicatesNaive([1, 2, 3, 4]) -> False
HasDuplicatesNaive([1, 2, 3, 1]) -> True
HasDuplicatesNaive([5, 5]) -> True
```

# Part 3: Has Duplicate HashSet Optimized (O(n))

## HashSet for O(1) Lookups
A HashSet<T> stores unique values and provides O(1) average-time operations for Add, Remove, and Contains. This makes it perfect for tracking "have I seen this before?" scenarios.

### O(n²) vs O(n) Comparison
In the previous lesson, we used nested loops to check for duplicates:

```csharp
// O(n²) - Nested loops approach
for (int i = 0; i < numbers.Length; i++)
{
    for (int j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] == numbers[j]) return true;
    }
}
```

With a HashSet, we can do much better:

```csharp
// O(n) - HashSet approach
var seen = new HashSet<int>();
foreach (int num in numbers)
{
    if (!seen.Add(num)) return true;  // Add returns false if already exists
}
```

### Why HashSet.Add Returns a Boolean
The Add method returns true if the element was added successfully, or false if it already exists. This single operation both checks and adds in O(1) time:

```csharp
var set = new HashSet<int>();
set.Add(5);  // returns true (5 added)
set.Add(3);  // returns true (3 added)
set.Add(5);  // returns false (5 already exists!)
```

### Performance Impact
| Array Size | O(n²) Operations | O(n) Operations |
| :--- | :--- | :--- |
| 100 | 10,000 | 100 |
| 1,000 | 1,000,000 | 1,000 |
| 10,000 | 100,000,000 | 10,000 |

## Your Task
Implement HasDuplicatesOptimized that returns true if the array contains any duplicate values, using a HashSet for O(n) time complexity.

Important: Use the HashSet.Add() method to detect duplicates. Do not use LINQ methods.

### Method Signature
```csharp
public static bool HasDuplicatesOptimized(int[] numbers)
```

### Expected Results
```
HasDuplicatesOptimized([1, 2, 3, 2]) -> True
HasDuplicatesOptimized([1, 2, 3, 4]) -> False
HasDuplicatesOptimized([5, 5]) -> True
```

# Part 4: Algorithm Classification

## Algorithm Complexity Classification
Understanding time complexity helps you predict how an algorithm's performance scales with input size. Each complexity class has distinct characteristics.

### The Five Major Complexity Classes
| Complexity | Name | What It Means | Growth Rate |
| :--- | :--- | :--- | :--- |
| O(1) | Constant | Always same time | Flat line |
| O(log n) | Logarithmic | Halves problem each step | Very slow growth |
| O(n) | Linear | Touches each element once | Straight line |
| O(n log n) | Linearithmic | Divide and conquer | Slightly curved |
| O(n²) | Quadratic | Nested iteration | Steep curve |

### Recognizing Each Pattern
```csharp
// O(1) - Constant: Direct access, no iteration
int value = array[5];           // Array index lookup
var item = dictionary["key"];   // Hash table lookup
stack.Push(42);                 // Stack operations

// O(log n) - Logarithmic: Eliminates half the data each step
// Binary search on 1,000,000 items: ~20 comparisons
while (low <= high)
{
    int mid = (low + high) / 2;
    if (arr[mid] == target) return mid;
    else if (arr[mid] < target) low = mid + 1;
    else high = mid - 1;
}

// O(n) - Linear: Single pass through data
for (int i = 0; i < n; i++)     // Visit each element once
    sum += array[i];

// O(n log n) - Linearithmic: Efficient sorting
// Merge sort: divide array, recursively sort, merge results
// n elements, log n levels of recursion

// O(n²) - Quadratic: Nested loops comparing pairs
for (int i = 0; i < n; i++)
    for (int j = 0; j < n; j++)  // Compare every pair
        if (arr[j] > arr[j+1]) Swap(arr, j, j+1);
```

### Real-World Performance (n = 10,000)
| Complexity | Operations | Time (1μs/op) |
| :--- | :--- | :--- |
| O(1) | 1 | 0.001 ms |
| O(log n) | 13 | 0.013 ms |
| O(n) | 10,000 | 10 ms |
| O(n log n) | 132,877 | 133 ms |
| O(n²) | 100,000,000 | 100 sec |

## Your Task
Classify algorithms by their Big O notation. Given an algorithm name, return its time complexity.

### O(1) - Constant:
"array_access", "hash_lookup", "stack_push", "stack_pop"

### O(log n) - Logarithmic:
"binary_search", "balanced_tree_search"

### O(n) - Linear:
"linear_search", "find_max", "array_sum"

### O(n log n) - Linearithmic:
"merge_sort", "heap_sort", "quicksort_average"

### O(n²) - Quadratic:
"bubble_sort", "selection_sort", "insertion_sort"

Return "Unknown" for any other algorithm. Input matching should be case-insensitive.

### Method Signature
```csharp
public static string ClassifyComplexity(string algorithm)
```

### Expected Results
```
ClassifyComplexity("array_access") -> "O(1)"
ClassifyComplexity("binary_search") -> "O(log n)"
ClassifyComplexity("merge_sort") -> "O(n log n)"
ClassifyComplexity("BUBBLE_SORT") -> "O(n^2)"
ClassifyComplexity("dijkstra") -> "Unknown"
```

# Part 5: Binary Search (O(log n))

## O(log n) Complexity - Binary Search
Binary search is the classic example of O(log n) complexity. Instead of checking every element like linear search O(n), binary search halves the search space with each comparison.

### How Binary Search Works
```csharp
// On a sorted array [1, 3, 5, 7, 9, 11, 13]
// Searching for 11:

// Step 1: Check middle (7) - 11 > 7, search right half
// Step 2: Check middle of [9, 11, 13] which is 11 - Found!
// Total: 2 steps instead of 6 with linear search
```

### Why O(log n) is Powerful
| Array Size | Linear Search O(n) | Binary Search O(log n) |
| :--- | :--- | :--- |
| 100 | up to 100 steps | up to 7 steps |
| 1,000 | up to 1,000 steps | up to 10 steps |
| 1,000,000 | up to 1M steps | up to 20 steps |

Each step halves the remaining elements: n → n/2 → n/4 → n/8 → ... → 1
The number of times you can halve n until reaching 1 is log₂(n).

### Binary Search Algorithm
```csharp
// 1. Start with left = 0, right = length - 1
// 2. Calculate middle index: mid = left + (right - left) / 2
// 3. Compare middle element to target:
//    - If equal: found it!
//    - If target is larger: search right half (left = mid + 1)
//    - If target is smaller: search left half (right = mid - 1)
// 4. Repeat until left > right (not found)
```

## Your Task
Implement binary search that counts and returns the number of comparison steps. Each time you compare the middle element to the target counts as one step - whether you find the target or not.

Important: You must implement the binary search algorithm manually. Built-in search methods are not allowed for this exercise.

### Method Signature
```csharp
public static int CountBinarySearchSteps(int[] sortedArray, int target)
```

### Expected Results
```
CountBinarySearchSteps([1, 3, 5, 7, 9], 5) -> 1  // Middle element is target
CountBinarySearchSteps([1, 3, 5, 7, 9], 9) -> 3  // Check 5, then 7, then 9
CountBinarySearchSteps([1, 3, 5, 7, 9], 4) -> 3  // Not found after 3 steps
```

# Part 6: Growth Comparison (O(n) vs O(n²))

## Comparing O(n) vs O(n²) Growth
The best way to understand algorithm complexity is to see it in action. By counting actual operations, you can observe how dramatically O(n²) algorithms slow down compared to O(n) as input grows.

### O(n) - Linear Growth
```csharp
int count = 0;
for (int i = 0; i < n; i++)
{
    count++;  // Executes exactly n times
}
// count == n
```
A single loop iterating n times performs exactly n operations.

### O(n²) - Quadratic Growth
```csharp
int count = 0;
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        count++;  // Executes n × n times
    }
}
// count == n * n
```
Nested loops where both iterate n times perform n × n = n² operations.

### Growth Comparison
| n | O(n) ops | O(n²) ops | Ratio |
| :--- | :--- | :--- | :--- |
| 5 | 5 | 25 | 5× |
| 10 | 10 | 100 | 10× |
| 100 | 100 | 10,000 | 100× |
| 1000 | 1,000 | 1,000,000 | 1000× |

Notice how the ratio equals n itself - O(n²) becomes n times slower than O(n)!

## Your Task
Write a method that counts and compares operation counts for both complexity classes:

1. Count operations in a single loop from 0 to n-1
2. Count operations in nested loops, each from 0 to n-1
3. Return both counts as an array [linearCount, quadraticCount]

### Method Signature
```csharp
public static int[] CompareOperationCounts(int n)
```

### Expected Results
```
CompareOperationCounts(5) -> [5, 25]
CompareOperationCounts(10) -> [10, 100]
CompareOperationCounts(3) -> [3, 9]
```

# Part 7: Complexity Capstone

## Complexity Tradeoff Analyzer Capstone
This capstone exercise brings together the key complexity concepts you've learned: O(n²) nested loops, O(n) HashSet lookups, and O(log n) binary search.

### The Three Algorithms
1. Naive Duplicate Check - O(n²)
```csharp
// Compare every pair of elements
for (int i = 0; i < arr.Length; i++)
    for (int j = i + 1; j < arr.Length; j++)
        if (arr[i] == arr[j]) return true;
```

2. HashSet Duplicate Check - O(n)
```csharp
// Track seen values with O(1) lookups
HashSet<int> seen = new HashSet<int>();
foreach (int num in arr)
    if (!seen.Add(num)) return true;
```

3. Binary Search - O(log n)
```csharp
// Each comparison halves the search space
while (left <= right)
{
    steps++;
    int mid = left + (right - left) / 2;
    if (arr[mid] == target) return steps;
    // Narrow to left or right half
}
```

### Complexity Comparison
| Algorithm | Time Complexity | 1000 elements |
| :--- | :--- | :--- |
| Nested loops | O(n²) | ~500,000 comparisons |
| HashSet | O(n) | ~1,000 operations |
| Binary search | O(log n) | ~10 comparisons |

## Your Task
Implement ComplexityCapstone that returns an array with three values:

1. `hasDuplicateNaive`: 1 if duplicates found using nested loops, 0 otherwise
2. `hasDuplicateHashSet`: 1 if duplicates found using HashSet, 0 otherwise
3. `binarySearchStepsForMiddle`: Number of comparisons to find the middle element of the sorted array using binary search

For the binary search:
- Sort a copy of the input array
- Find the middle value: `sorted[length / 2]`
- Count how many comparisons binary search needs to find it
- If the array is empty, return `[0, 0, 0]`.

Important: You must implement all algorithms manually - no built-in shortcuts for duplicate detection, searching, or summation.

### Method Signature
```csharp
public static int[] ComplexityCapstone(int[] numbers)
```

### Expected Results
```
ComplexityCapstone([1, 2, 3, 4, 5]) -> [0, 0, 1]
ComplexityCapstone([1, 2, 2, 4, 5]) -> [1, 1, 1]
ComplexityCapstone([]) -> [0, 0, 0]
```
