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

    public static int[] ReverseList(int[] values)
    {
        if (values.Length == 0)
        {
            return new int[0];
        }

        // Build the linked list
        Node head = new Node(values[0]);
        Node tail = head;
        for (int i = 1; i < values.Length; i++)
        {
            tail.Next = new Node(values[i]);
            tail = tail.Next;
        }

        // Reverse the linked list
        Node prev = null;
        Node current = head;
        Node next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
        head = prev;

        // Traverse and collect values
        List<int> result = new List<int>();
        Node walker = head;
        while (walker != null)
        {
            result.Add(walker.Value);
            walker = walker.Next;
        }

        return result.ToArray();
    }
}
