using FluentAssertions;
using Xunit;

namespace LeetCode.Tests
{
    public class LinkedListsTests
    {
        LinkedLists service = new();

        [Fact]
        public void ReverseList()
        {
            ListNode e = new(5);
            ListNode d = new(4, e);
            ListNode c = new(3, d);
            ListNode b = new(2, c);
            ListNode a = new(1, b); //head

            var result = service.ReverseList(a);
            result.val.Should().Be(5);
            result.next.val.Should().Be(4);
            result.next.next.val.Should().Be(3);
            result.next.next.next.val.Should().Be(2);
            result.next.next.next.next.val.Should().Be(1);
        }

        [Fact]
        public void RecursiveReverseListTest()
        {
            ListNode e = new(5);
            ListNode d = new(4, e);
            ListNode c = new(3, d);
            ListNode b = new(2, c);
            ListNode a = new(1, b); //head

            var result = service.RecursiveReverse(a);
            result.val.Should().Be(5);
            result.next.val.Should().Be(4);
            result.next.next.val.Should().Be(3);
            result.next.next.next.val.Should().Be(2);
            result.next.next.next.next.val.Should().Be(1);
        }

        [Fact]
        public void HasCycle()
        {
            ListNode d = new(-4);
            ListNode c = new(0, d);
            ListNode b = new(2, c);
            ListNode a = new(3, b);
            d.next = b;

            var result = service.HasCycle(a);

            result.Should().BeTrue();
        }

        [Fact]
        public void HasCycleRace()
        {
            ListNode d = new(-4);
            ListNode c = new(0, d);
            ListNode b = new(2, c);
            ListNode a = new(3, b);
            d.next = b;

            var result = service.HasCycleRace(a);

            result.Should().BeTrue();
        }

        [Fact]
        public void AddTwoNumbers()
        {
            ListNode c = new(2);
            ListNode b = new(4, c);
            ListNode a = new(3, b); //head

            ListNode c3 = new(5);
            ListNode b2 = new(6, c3);
            ListNode a1 = new(4, b2); //head

            var result = service.AddTwoNumbers(a, a1);

            result.val.Should().Be(7);
            result.next.val.Should().Be(0);
            result.next.next.val.Should().Be(8);
        }

        [Fact]
        public void AddTwoNumbersII()
        {
            // l1 = [7,2,4,3], l2 = [5,6,4]
            //answer = [7,8,0,7]

            ListNode d1 = new(3);
            ListNode c1 = new(4, d1);
            ListNode b1 = new(2, c1);
            ListNode a1 = new(7, b1);

            ListNode c2 = new(4);
            ListNode b2 = new(6, c2);
            ListNode a2 = new(5, b2);

            var result = service.AddTwoNumbersII(a1, a2);

            result.val.Should().Be(7);
            result.next.val.Should().Be(8);
            result.next.next.val.Should().Be(0);
            result.next.next.next.val.Should().Be(7);
        }
    }
}
