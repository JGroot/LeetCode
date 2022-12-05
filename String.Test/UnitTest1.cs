using Strings;
using Xunit;
using FluentAssertions;
namespace String.Test
{
    public class UnitTest1
    {
        StringFunctions _strings = new();

        [Theory]
        [InlineData("A blue sky", "sky blue A")]
        [InlineData(" ", "")]
        [InlineData("  Hey you  what do you mean", "mean you do what you Hey")]
        public void Test1(string s, string answer)
        {
            var result = _strings.ReverseString(s);

            result.Should().BeEquivalentTo(answer);
        }

        [Theory]
        [InlineData("A blue sky", "sky blue A")]
        [InlineData(" ", "")]
        [InlineData("  Hey you  what do you mean", "mean you do what you Hey")]
        public void Test2(string s, string answer)
        {
            var result = _strings.ReverseString2(s);

            result.Should().BeEquivalentTo(answer);
        }

        [Fact]
        public void TestReverseChars()
        {
            char[] s = new char[]   {'t', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' };
            var answer = new char[] {'b', 'l', 'u', 'e', ' ', 'i', 's', ' ', 's', 'k', 'y', ' ', 't', 'h', 'e'};
            var result = _strings.ReverseWords(s);

            result.Should().Equal(answer);
        }
    }
}