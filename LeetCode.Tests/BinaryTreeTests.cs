using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using LeetCode.Models;

namespace LeetCode.Tests
{
    public class BinaryTreeTests
    {
        BinaryTrees _service = new();

        [Fact]
        public void BreadthFirstValues()
        {
            var result = _service.BreadthFirstValues(GetCharNode());
            char[] answer = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
            result.Should().BeEquivalentTo(answer);
        }

        [Fact]
        public void ComputeSum()
        {
            var result = _service.ComputeSum(GetIntNode());
            var recResult = _service.RecursiveSum(GetIntNode());
            result.Should().Be(25);
            recResult.Should().Be(25);

        }

        [Fact]
        public void DepthFirstValues()
        {
            var result = _service.DepthFirstValues(GetCharNode());
            char[] answer = new char[] { 'a', 'b', 'd', 'e', 'c', 'f' };
            result.Should().Equal(answer);
        }

        [Fact]
        public void HasPathSum()
        {
            var target = 14;
            var result = _service.HasPathSum(GetInvalidBTSNode2(), target);
            var result2 = _service.HasPathSum(Negatives(), -5);
            var result3 = _service.HasPathSum(NegativesAndPositive(), -1);
            var result4 = _service.HasPathSum(NegativesAndPositive(), 2);

            result.Should().BeTrue();
            result2.Should().BeTrue();
            result3.Should().BeTrue();
            result4.Should().BeFalse();

        }

        [Fact]
        public void InorderTraversal()
        {
            var results = _service.InorderTraversal(GetTraversal());

            List<int> answer = new() { 1, 3, 2 };
            results.Should().BeEquivalentTo(answer);
        }

        [Fact]
        public void IsSymmetric()
        {
            var result = _service.IsSymmetric(GetIntNode());
            var result2 = _service.IsSymmetric(GetLevel());
            var result3 = _service.IsSymmetric(GetSymmetric());

            var result4 = _service.IsSymmetricIterative(GetIntNode());
            var result5 = _service.IsSymmetricIterative(GetSymmetric());

            result.Should().BeFalse();
            result2.Should().BeFalse();
            result3.Should().BeTrue();

            result4.Should().BeFalse();
            result5.Should().BeTrue();
        }

        [Fact]
        public void IsValidBTS()
        {
            var result = _service.IsValidBST(GetValidBTSNode());
            var result2 = _service.IsValidBST(GetInvalidBTSNode());
            var recResult = _service.RecursiveIsValidBST(GetValidBTSNode());
            var recResult2 = _service.RecursiveIsValidBST(GetInvalidBTSNode());
            var recResult3 = _service.RecursiveIsValidBST(GetInvalidBTSNode2());

            result.Should().BeTrue();
            result2.Should().BeFalse();
            recResult.Should().BeTrue();
            recResult2.Should().BeFalse();
            recResult3.Should().BeFalse();
        }

        [Fact]
        public void LevelOrderTraversal()
        {
            IList<IList<int>> answer = new List<IList<int>>();
            IList<int> l1 = new List<int>() { 1 };
            IList<int> l2 = new List<int>() { 2, 3 };
            IList<int> l3 = new List<int>() { 4, 5 };
            answer.Add(l1);
            answer.Add(l2);
            answer.Add(l3);

            var result = _service.LevelOrder(GetLevel());
            var recResult = _service.RecursiveLevelOrder(GetLevel());
            result.Should().BeEquivalentTo(answer);
            recResult.Should().BeEquivalentTo(answer);
        }

        [Fact]
        public void MaxDepth()
        {
            var result = _service.MaxDepthTop(GetIntNode());
            var recResult = _service.MaxDepthTop(GetIntNode());
            result.Should().Be(3);
            recResult.Should().Be(3);
        }

        [Fact]
        public void MaxPathSum()
        {
            var result = _service.MaxPathSum(GetIntNode());
            result.Should().Be(18);
        }

        [Fact]
        public void PostorderTraversal()
        {
            var result = _service.PostorderTraversal(GetTraversal());
            List<int> answer = new() { 3, 2, 1 };
            result.Should().BeEquivalentTo(answer);
        }

        [Fact]
        public void PreorderTraversal()
        {
            var result = _service.PreorderTraversal(GetTraversal());
            var result2 = _service.RecursivePreorderTraversal(GetTraversal());
            List<int> answer = new() { 1, 2, 3 };
            result.Should().BeEquivalentTo(answer);
            result2.Should().BeEquivalentTo(answer);
        }
      
        [Fact]
        public void RecursiveDepthFirstValues()
        {
            var result = _service.RecursiveDepthFirstValues(GetCharNode());
            // char[] answer = new char[] { 'a', 'b', 'd', 'e', 'c', 'f' };
            string answer = "abdecf";
            result.Should().BeEquivalentTo(answer);
        }

        [Theory]
        [InlineData(10, 4, 6, true)]
        [InlineData(5, 3, 1, false)]
        public void RootEqualsSumOfChildren(int v, int l, int r, bool answer)
        {
            TreeNode left = new(l);
            TreeNode right = new(r);
            TreeNode root = new(v, left, right);
            var result = _service.RootEqualsSumOfChildren(root);

            result.Should().Be(answer);
        }
     
        [Theory]
        [InlineData('a', true)]
        [InlineData('z', false)]
        public void TreeIncludes(char value, bool answer)
        {
            var result = _service.TreeIncludes(GetCharNode(), value);
            var recResult = _service.RecursiveTreeIncludes(GetCharNode(), value);
            var nullResult = _service.RecursiveTreeIncludes(null, 'a');

            result.Should().Be(answer);
            recResult.Should().Be(answer);
            nullResult.Should().BeFalse();
        }

        [Fact]
        public void TreeMin()
        {
            var result = _service.TreeMin(GetIntNode());
            var recResult = _service.RecursiveTreeMin(GetIntNode());
            result.Should().Be(1);
            recResult.Should().Be(1);
        }

       

        private BNode<char> GetCharNode()
        {
            //      a
            //     / \
            //    b   c
            //   / \   \
            //  d   e   f

            BNode<char> a = new('a');
            BNode<char> b = new('b');
            BNode<char> c = new('c');
            BNode<char> d = new('d');
            BNode<char> e = new('e');
            BNode<char> f = new('f');

            a.Left = b;
            a.Right = c;
            b.Left = d;
            b.Right = e;
            c.Right = f;

            return a;
        }

        private BNode<int> GetIntNode()
        {
            BNode<int> a = new(3);
            BNode<int> b = new(11);
            BNode<int> c = new(4);
            BNode<int> d = new(4);
            BNode<int> e = new(2);
            BNode<int> f = new(1);

            a.Left = b;
            a.Right = c;
            b.Left = d;
            b.Right = e;
            c.Right = f;

            return a;
        }
      
        private BNode<int> GetInvalidBTSNode()
        {
            BNode<int> a = new(5);
            BNode<int> b = new(1);
            BNode<int> c = new(4);
            BNode<int> d = new(3);
            BNode<int> e = new(6);

            a.Left = b;
            a.Right = c;
            c.Left = d;
            c.Right= e;

            return a;
        }

        private BNode<int> GetInvalidBTSNode2()
        {
            //      5
            //     / \
            //    4   6
            //       / \
            //      3   7
            //[5,4,6,null,null,3,7]
            BNode<int> a = new(5);
            BNode<int> b = new(4);
            BNode<int> c = new(6);
            BNode<int> d = new(3);
            BNode<int> e = new(7);

            a.Left = b;
            a.Right = c;
            c.Left = d;
            c.Right = e;

            return a;
        }

        private BNode<int> GetLevel()
        {
            //      a
            //     / \
            //    b   c
            //   /     \
            //  d       e

            BNode<int> a = new(1);
            BNode<int> b = new(2);
            BNode<int> c = new(3);
            BNode<int> d = new(4);
            BNode<int> e = new(5);

            a.Left = b;
            a.Right = c;
            b.Left = d;
            c.Right = e;

            return a;
        }

        private BNode<int> GetSymmetric()
        {
            //      a1
            //     / \
            //    b2  c2
            //   /     \
            //  d3      e3

            BNode<int> a = new(1);
            BNode<int> b = new(2);
            BNode<int> c = new(2);
            BNode<int> d = new(3);
            BNode<int> e = new(3);

            a.Left = b;
            a.Right = c;
            b.Left = d;
            c.Right = e;

            return a;
        }

        private BNode<int> GetTraversal()
        {
            BNode<int> a = new(1);
            BNode<int> b = new(2);
            BNode<int> c = new(3);

            a.Right = b;
            b.Left = c;

            return a;
        }

        private BNode<int> GetValidBTSNode()
        {
            BNode<int> a = new(2);
            BNode<int> b = new(1);
            BNode<int> c = new(3);

            a.Left = b;
            a.Right = c;
            return a;
        }

        private BNode<int> Negatives()
        {
            //     a-2
            //      \
            //       b-3
            BNode<int> a = new(-2);
            BNode<int> b = new(-3);
            a.Right = b;
            return a;
        }

        private BNode<int> NegativesAndPositive()
        {
            //     a2
            //      \
            //       b-3
            BNode<int> a = new(2);
            BNode<int> b = new(-3);
            a.Right = b;
            return a;
        }
    }
}
