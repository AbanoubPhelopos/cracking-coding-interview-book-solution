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

    public static int[] DeleteByValue(int[] values, int target)
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

        // Delete by value
        if (head.Value == target)
        {
            head = head.Next;
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Value == target)
                {
                    current.Next = current.Next.Next;
                    break;
                }
                current = current.Next;
            }
        }

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
