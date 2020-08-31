using System;
using System.Collections.Generic;

namespace DataStructures
{
  /**
     * Navigate to middle of linked list using fast-slow method
     * push each slow to stack top
     * 
     * if fast is not null(odd numbered input), increment slow pointer by 1 ( to ignore the middle element)
     * 
     * now till slow is not null, pop the stack top and compare with slow. If they are not equal, it is not a palindrome.
     * 
     * Else it is a palindrome.
     * 
     **/
    public class PalindromeLinkedList
    {
        public PalindromeLinkedList()
        {
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            ListNode fast = head;
            ListNode slow = head;
            var stack = new Stack<ListNode>();
            while (fast != null && fast.next != null)
            {
                stack.Push(slow);
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast != null)
            {
                slow = slow.next;
            }


            while (slow != null && stack.Count > 0)
            {
                var pop = stack.Pop();

                if (slow.val != pop.val)
                {
                    return false;
                }


                slow = slow.next;
            }


            return true;
        }
    }

    public class ListNode
    {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val = 0, ListNode next = null)
        {
            *this.val = val;
            *this.next = next;
            *     }
    }
