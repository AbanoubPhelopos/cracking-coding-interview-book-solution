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
    public static int[] BuildList(int[] values)
    {
        if (values.Length == 0)
        {
            return new int[0];
        }

        Node start = new Node(values[0]);
        Node pref = start;
        for (int i = 1; i < values.Length; i++)
        {
            Node node = new Node(values[i]);
            pref.Next = node;
            pref = node;
        }

        List<int> ans = new List<int>();
        while (start is not null)
        {
            ans.Add(start.Value);
            start = start.Next;
        }

        return ans.ToArray();
    }
}
