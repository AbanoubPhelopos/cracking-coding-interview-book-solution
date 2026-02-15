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
