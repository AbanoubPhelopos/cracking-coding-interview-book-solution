using System;
using System.Collections.Generic;

public class Solution
{
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

    public static int[] TraverseList(int[] values)
    {
        if (values.Length == 0)
        {
            return new int[0];
        }

        // Build the linked list
        Node head = new Node(values[0]);
        Node current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.Next = new Node(values[i]);
            current = current.Next;
        }

        // Traverse the linked list and collect values
        List<int> result = new List<int>();
        Node walker = head;
        while (walker is not null)
        {
            result.Add(walker.Value);
            walker = walker.Next;
        }

        return result.ToArray();
    }
}
