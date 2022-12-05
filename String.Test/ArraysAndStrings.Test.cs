using LeetCode;
using Xunit;
using FluentAssertions;

namespace String.Test
{
    public class ArraysAndStringsTests
    {
        ArraysAndStrings _service = new();

        [Fact]
        public void TwoSum()
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var answer = new int[] { 0, 1 };

            var result = _service.TwoSum(nums, target);

            result.Should().BeEquivalentTo(answer);
        }

        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        [InlineData(" ", true)]
        [InlineData("aba", true)]
        public void ValidPalindrome(string s, bool answer)
        {
            var result = _service.IsPalindrome(s);
            result.Should().Be(answer);
        }
    }
}
