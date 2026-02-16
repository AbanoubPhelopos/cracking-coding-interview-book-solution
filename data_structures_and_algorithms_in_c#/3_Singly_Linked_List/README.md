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
