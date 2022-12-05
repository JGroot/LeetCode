namespace LeetCode
{
    public class LinkedLists
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            
            var top = l1;
            var bottom = l2;
            int carry = 0;
            ListNode dummy = new(0);
            var result = dummy;

            while (top != null || bottom != null)
            {
                var x = top == null? 0: top.val;
                var y = bottom == null? 0: bottom.val;
                int sum = x + y + carry;
                carry = sum / 10;
                result.next = new ListNode(sum % 10);

                if (top != null)
                    top = top.next;
                if (bottom != null)
                    bottom = bottom.next;

                result = result.next;
            }

            if (carry > 0)
                result.next = new ListNode(carry);

            return dummy.next;

        }


        public ListNode ReverseList(ListNode head)
        {
            //Given the head of a singly linked list, reverse the list, and return the reversed list.
            //1->2->3 to 1<-2<-3

            //placeholders used to traverse list
            var left = head;
            var right = head.next;

            //traverse list
            while (right != null)
            {
                //1st iter: left = 1, right = 2, right.next = 3
                //2nd iter: left = 2, right 3, right.next = 1
                //temp storage to hold prev value
                var temp = right.next;
                //shift to the left
                right.next = left;
                left = right;
                right = temp;
            }
            return left;
        }

        public ListNode RecursiveReverse(ListNode head)
        {
            //think about the origin link list : 1->2->3->4->5.Now assume that the last node has been reversed.Just like this:
            //1->2->3->4<-5.And this time you are at the node 3, you want to change 3->4 to 3<-4 , means let 3->next->next = 3.
            //(3->next is 4 and 4->next = 3 is to reverse it)
            // head 1, then 2, then 3
            if (head == null || head.next == null)
                return head;

            ListNode left = RecursiveReverse(head.next);
            head.next.next = head;
            head.next = null;
            return left;
        }

        public bool HasCycle(ListNode head)
        {
            //if single item then no cyle
            if (head == null || head.next == null)
                return false;

            Dictionary<ListNode, int> seen = new();
            var pos = 0;
            var current = head;
            while (current != null && current.next != null)
            {
                if (seen.TryGetValue(current.next, out int node))
                    return true;

                seen[current] = 0;
                current = current.next;
                pos++;
            }

            return false;
        }

        public bool HasCycleRace(ListNode head)
        {
            //race to see if there is a cycle
            if (head == null)
                return false;

            var slow = head;
            var fast = head.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                    return false;
                slow = slow.next;
                fast = fast.next.next; //moving faster and will eventually catch up to head if there is a cycle
            }
            return true;
        }

        public int GetIntVal(ListNode head)
        {
            string holder = "0";
            var reversed = RecursiveReverse(head);
            while (reversed.next != null)
            {
                holder += reversed.val;
                reversed = reversed.next;
            }
            holder += reversed;
            return int.Parse(holder);
        }

        public ListNode GetLast(ListNode head)
        {
            var current = head;
            while (current.next != null)
                current = current.next;
            return current;
        }

        public ListNode AddTwoNumbersII(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return new ListNode(0);

            var top = ReverseNumbers(l1);
            var bottom = ReverseNumbers(l2);
            int carry = 0;
            ListNode starter = new(0);
            var current = starter;

            while (top != null || bottom != null)
            {
                var x = top == null ? 0 : top.val;
                var y = bottom == null ? 0 : bottom.val;
                var sum = x + y + carry;
                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
                if (top != null)
                    top = top.next;
                if (bottom != null) 
                    bottom = bottom.next;
            }

            if (carry > 0)
                current.next = new ListNode(carry);

            return ReverseNumbers(starter.next);

        }

        public ListNode ReverseNumbers(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            var left = ReverseNumbers(head.next);
            head.next.next = head;
            head.next = null;
            return left;
        }

    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
