using System;

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

    public static bool SearchList(int[] values, int target)
    {
        if (values.Length == 0)
        {
            return false;
        }

        // Build the linked list
        Node head = new Node(values[0]);
        Node current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.Next = new Node(values[i]);
            current = current.Next;
        }

        Node walker = head;
        while (walker is not null)
        {
            if (walker.Value == target) return true;
            walker = walker.Next;
        }
        return false;
    }
}
