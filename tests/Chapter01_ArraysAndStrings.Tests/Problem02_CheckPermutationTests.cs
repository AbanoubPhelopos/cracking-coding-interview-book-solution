using CrackingTheCode.Chapter01.Problem02;

namespace CrackingTheCode.Tests.Chapter01;

public class Problem02_CheckPermutationTests
{
    [Theory]
    [InlineData("abc", "cba", true)]
    [InlineData("test", "estt", true)]
    [InlineData("dog", "god", true)]
    [InlineData("dog", "dog ", false)]
    [InlineData("dog", "God", false)]
    [InlineData("abc", "abd", false)]
    [InlineData("", "", true)]
    [InlineData("a", "a", true)]
    [InlineData("permutation", "noitatumrep", true)]
    public void UsingSorting_ReturnsExpectedResult(string s1, string s2, bool expected)
    {
        Assert.Equal(expected, CheckPermutation.UsingSorting(s1, s2));
    }

    [Theory]
    [InlineData("abc", "cba", true)]
    [InlineData("test", "estt", true)]
    [InlineData("dog", "god", true)]
    [InlineData("dog", "dog ", false)]
    [InlineData("dog", "God", false)]
    [InlineData("abc", "abd", false)]
    [InlineData("", "", true)]
    [InlineData("a", "a", true)]
    [InlineData("permutation", "noitatumrep", true)]
    public void UsingCharCount_ReturnsExpectedResult(string s1, string s2, bool expected)
    {
        Assert.Equal(expected, CheckPermutation.UsingCharCount(s1, s2));
    }
}
