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

    public static int[] LinkedListCapstone(int[] values, int insertPos, int insertValue, int deleteValue)
    {
        // 1. Build the linked list
        Node head = null;
        if (values.Length > 0)
        {
            head = new Node(values[0]);
            Node tail = head;
            for (int i = 1; i < values.Length; i++)
            {
                tail.Next = new Node(values[i]);
                tail = tail.Next;
            }
        }

        // 2. Insert at position
        Node newNode = new Node(insertValue);
        if (head == null || insertPos <= 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node current = head;
            int currentPos = 0;
            // Traverse to position insertPos - 1, or the end of the list
            while (current.Next != null && currentPos < insertPos - 1)
            {
                current = current.Next;
                currentPos++;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        // 3. Delete by value
        if (head != null)
        {
            if (head.Value == deleteValue)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    if (current.Next.Value == deleteValue)
                    {
                        current.Next = current.Next.Next;
                        break; // Delete only the first occurrence
                    }
                    current = current.Next;
                }
            }
        }

        // 4. Reverse the list
        Node prev = null;
        Node curr = head;
        Node next = null;

        while (curr != null)
        {
            next = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = next;
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
