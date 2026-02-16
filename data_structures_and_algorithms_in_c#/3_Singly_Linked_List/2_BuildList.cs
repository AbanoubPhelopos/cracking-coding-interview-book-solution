using System;
using System.Collections.Generic;

public class Solution
{
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
            pref.Next = node;   // link previous -> new (not backwards!)
            pref = node;        // advance to the new node
        }

        List<int> ans = new List<int>();
        while (start is not null)   // visit ALL nodes including the last
        {
            ans.Add(start.Value);
            start = start.Next;
        }

        return ans.ToArray();
    }
}
