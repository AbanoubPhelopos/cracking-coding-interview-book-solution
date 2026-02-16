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

    public static int[] InsertAtPosition(int[] values, int position, int newValue)
    {
        // Build the linked list
        Node head = null;
        Node tail = null;
        for (int i = 0; i < values.Length; i++)
        {
            Node node = new Node(values[i]);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
        }

        // Insert at position
        Node newNode = new Node(newValue);
        if (position == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node current = head;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        // Traverse and collect values
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
