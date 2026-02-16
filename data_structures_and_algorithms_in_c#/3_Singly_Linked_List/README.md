# Singly Linked List

# Part 1: Create a Node Class

## The Node: Building Block of a Linked List
A linked list is one of the most fundamental data structures in computer science. Unlike arrays, which store elements in contiguous memory, a linked list is made up of individual nodes that are connected together through references. Before you can build a linked list, you need to understand and create its smallest unit — the Node.

A node in a singly linked list holds two things: a value (the data it stores) and a reference to the next node in the chain. When a node is the last one in the list (or the only one), its next reference is null.

### How It Works
Think of a node like a box with two compartments. The first compartment holds something valuable (the data), and the second compartment holds a slip of paper with directions to the next box. If there is no next box, the slip of paper is blank (null).

When you create a brand-new node, it exists on its own — it doesn't know about any other nodes yet. So its "next" reference starts as null. Later, when building a full linked list, you connect nodes by setting one node's Next to point to another node.

### Syntax
In C#, you define a class with properties and a constructor:

```csharp
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

A property with `{ get; set; }` is an auto-implemented property — C# generates a backing field for you automatically. The constructor is a special method that runs when you create a new instance with the `new` keyword.

### Examples
Here's a class that models a simple container with a value and an optional reference to another container:

```csharp
// A container that holds a string message
public class MessageBox
{
    public string Message { get; set; }
    public MessageBox NextBox { get; set; }

    public MessageBox(string message)
    {
        Message = message;
        NextBox = null;  // No next box by default
    }
}

// Creating a standalone message box
MessageBox box = new MessageBox("Hello");
Console.WriteLine(box.Message);            // "Hello"
Console.WriteLine(box.NextBox == null);    // True
```

Notice how `NextBox` is a reference to another `MessageBox`. This self-referential pattern — where a class has a property of its own type — is exactly what makes linked structures possible.

```csharp
// A simple coordinate point with an optional link to the next point
public class Waypoint
{
    public double X { get; set; }
    public Waypoint Next { get; set; }

    public Waypoint(double x)
    {
        X = x;
        Next = null;
    }
}

Waypoint w = new Waypoint(3.14);
// w.X is 3.14, w.Next is null
```

### Common Patterns
- **Self-referential types**: A class that has a property of its own type (`Node` has a `Node Next` property). This is the foundation of linked lists, trees, and graphs.
- **Null as "end of chain"**: When `Next` is `null`, it signals there are no more nodes.
- **Constructors initializing defaults**: Setting references to `null` in the constructor makes the intent clear and prevents uninitialized reference issues.

## Your Task
Define a `Node` class with:

- An `int` property called `Value`
- A `Node` property called `Next`
- A constructor that accepts an `int value`, stores it in `Value`, and sets `Next` to `null`

Then implement the `CreateNode` method that:

- Creates a new `Node` with the given value
- Returns an `int[]` array containing two elements:
  - The node's `Value`
  - `1` if the node's `Next` is `null`, or `0` if it is not

Since a freshly created node should always have `Next` set to `null`, the second element should always be `1` for a correctly implemented `Node`.

### Method Signature
```csharp
public static int[] CreateNode(int value)
```

### Expected Results
```
CreateNode(42)  -> [42, 1]
CreateNode(0)   -> [0, 1]
CreateNode(-5)  -> [-5, 1]
CreateNode(100) -> [100, 1]
```

# Part 2: Build List from Array

## Building a Singly Linked List from an Array
A singly linked list is a chain of nodes where each node holds a value and a reference to the next node. Unlike arrays, linked lists don't store elements in contiguous memory — each node simply "points" to the next one. Building a linked list from an array is a foundational operation that teaches you how nodes connect together to form a chain.

### How It Works
To build a linked list, you start by creating a head node from the first element. Then you walk through the remaining elements one by one, creating a new `Node` for each and linking it to the previous node's `Next` property. You keep track of which node you're currently at so you always know where to attach the next one.

Once the list is built, you traverse it by starting at the head and following `Next` references until you reach `null`, which signals the end of the list.

### The Node Class (provided in Node.cs)
You have a `Node` class available with:

```csharp
public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}
```

### Building a Chain — General Pattern
Consider how you might chain together a sequence of letters into a linked structure:

```csharp
// Creating nodes for letters A, B, C
Node nodeA = new Node('A');
Node nodeB = new Node('B');
Node nodeC = new Node('C');

// Linking them: A → B → C
nodeA.Next = nodeB;
nodeB.Next = nodeC;
```

This manual approach works for a few nodes, but when you have an entire array of unknown length, you need a loop. The key insight is to maintain a "current" reference that always points to the last node in the chain:

```csharp
// Conceptual pattern for chaining nodes in a loop
Node head = new Node(firstValue);
Node current = head;

// For each subsequent value:
//   1. Create a new node
//   2. Set current.Next to the new node
//   3. Advance current to the new node
```

### Traversal Pattern
To read all values from a linked list, you walk from head to tail:

```csharp
// Traversal example with a list of names
Node walker = headNode;
while (walker != null)
{
    // Process walker.Value here
    walker = walker.Next;
}
```

Each iteration moves `walker` forward by one node. When `walker` becomes `null`, you've visited every node.

### Useful Reference
| Concept | Description |
| :--- | :--- |
| `new Node(value)` | Creates a node with the given value and `Next` set to `null` |
| `node.Next = otherNode` | Links node to point to otherNode |
| `node.Next is null` | Indicates the end of the list |
| `List<int>` | A dynamic collection useful for gathering values during traversal |
| `list.ToArray()` | Converts a `List<int>` to an `int[]` |

## Your Task
Write a method `BuildList` that takes an `int[]` array and:

- Creates a singly linked list where each array element becomes a `Node`, linked in order
- Traverses the linked list from head to tail, collecting each node's value
- Returns the collected values as an `int[]`

If the input array is empty, return an empty array.

Use the `Node` class provided in Node.cs — do not use any built-in linked list classes.

### Method Signature
```csharp
public static int[] BuildList(int[] values)
```

### Expected Results
```
BuildList([3, 5, 7])    -> [3, 5, 7]
BuildList([10])         -> [10]
BuildList([])           -> []
BuildList([1, 2, 3, 4]) -> [1, 2, 3, 4]
```
