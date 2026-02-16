using System;

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

public class Solution
{
    public static int[] CreateNode(int value)
    {
        Node node = new Node(value);
        int[] ans = new int[2];
        ans[0] = node.Value;
        if (node.Next is null)
        {
            ans[1] = 1;
        }
        else
        {
            ans[1] = 0;
        }

        return ans;
    }
}
