using LeetCode;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace LeetCode.Tests
{
    public class ArraysAndStringsTests
    {
        ArraysAndStrings _service = new();

        [Theory]
        [MemberData(nameof(OneIntArray.GetPivotIndex), MemberType = typeof(OneIntArray))]
        public void FindPivotIndex(OneIntArray data)
        {
            var result = _service.FindPivotIndex(data.Nums);

            result.Should().Be(data.Answer);
        }

        [Theory]
        [InlineData("badc", "baba", false)]
        [InlineData("egg", "add", true)]
        [InlineData("foo", "bar", false)]
        [InlineData("paper", "title", true)]
        public void IsIsomorphic(string s, string t, bool answer)
        {
            var result = _service.IsIsomorphic(s, t);

            result.Should().Be(answer);
        }
        
        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        [InlineData(" ", true)]
        [InlineData("aba", true)]
        public void IsPalindrome(string s, bool answer)
        {
            var result = _service.IsPalindrome(s);
            result.Should().Be(answer);
        }

        [Theory]
        [InlineData("abc", "ahbgdc", true)]
        [InlineData("axc", "ahbgdc", false)]
        public void IsSubsequence(string s, string t, bool answer)
        {
            var result = _service.IsSubsequence(s, t);

            result.Should().Be(answer);
        }

        [Fact]
        public void ReverseString()
        {
            var s = new char[] { 'H', 'a', 'n', 'n', 'a', 'h' };
            var s2 = new char[] { 'h', 'e', 'l', 'l', 'o' };
            var answer = new char[] { 'h', 'a', 'n', 'n', 'a', 'H' };
            var answer2 = new char[] { 'o', 'l', 'l', 'e', 'h' };

            var result1 = _service.ReverseString(s);
            var result2 = _service.ReverseString(s2);

            result1.Should().BeEquivalentTo(answer);
            result2.Should().BeEquivalentTo(answer2);

        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        public void IsValid(string s, bool answer)
        {
            var result = _service.IsValid(s);
            result.Should().Be(answer);
        }

        [Theory]
        [InlineData("the sky is blue", "blue is sky the")]
        [InlineData("   hello world", "world hello")]
        [InlineData("a good   example", "example good a")]
        public void ReverseWords(string s, string answer)
        {
            var result = _service.ReverseWords(s);
            result.Should().BeEquivalentTo(answer);
        }

        [Fact]
        public void ReverseWordsTwo()
        {
            char[] s = new char[] { 't', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' };
            var answer = new char[] { 'b', 'l', 'u', 'e', ' ', 'i', 's', ' ', 's', 'k', 'y', ' ', 't', 'h', 'e' };
            var result = _service.ReverseWordsTwo(s);

            result.Should().Equal(answer);
        }

        [Theory]
        [MemberData(nameof(TwoIntArrays.GetSumOneDArray), MemberType = typeof(TwoIntArrays))]
        public void RunningSumOneDArray(TwoIntArrays data)
        {
            var result = _service.RunningSumOneDArray(data.Nums);

            result.Should().Equal(data.Answer);
        }

        [Fact]
        public void SortedSquares()
        {
            int[] num = new int[] { -4, 1, 0, 3, 10 };
            var answer = new int[] { 0, 1, 9, 16, 100 };

            int[] num2 = new int[] { -7, -3, 2, 3, 11 };
            int[] answer2 = new int[] { 4, 9, 9, 49, 121 };

            var result = _service.SortedSquares(num);   
            result.Should().Equal(answer);

            var result2 = _service.SortedSquares(num2);
            result2.Should().Equal(answer2);
        }

        [Fact]
        public void TwoSum()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var answer = new int[] { 0, 1 };

            var result = _service.TwoSum(nums, target);

            result.Should().BeEquivalentTo(answer);
        }
    }
}