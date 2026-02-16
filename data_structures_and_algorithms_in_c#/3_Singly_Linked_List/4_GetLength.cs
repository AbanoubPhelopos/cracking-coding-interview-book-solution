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

    public static int GetLength(int[] values)
    {
        if (values.Length == 0)
        {
            return 0;
        }

        // Build the linked list
        Node head = new Node(values[0]);
        Node current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.Next = new Node(values[i]);
            current = current.Next;
        }

        int ans = 0;
        Node walker = head;
        while (walker is not null)
        {
            ans++;
            walker = walker.Next;
        }

        return ans;
    }
}
