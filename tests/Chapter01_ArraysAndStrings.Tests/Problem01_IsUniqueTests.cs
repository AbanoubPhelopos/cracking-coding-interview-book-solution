using CrackingTheCode.Chapter01.Problem01;

namespace CrackingTheCode.Tests.Chapter01;

public class Problem01_IsUniqueTests
{
    #region HashSet Approach Tests

    [Fact]
    public void UsingHashSet_UniqueCharacters_ReturnsTrue()
    {
        // Arrange
        string input = "abcdef";

        // Act
        bool result = IsUnique.UsingHashSet(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsingHashSet_DuplicateCharacters_ReturnsFalse()
    {
        // Arrange
        string input = "hello";

        // Act
        bool result = IsUnique.UsingHashSet(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UsingHashSet_EmptyString_ReturnsTrue()
    {
        // Arrange
        string input = "";

        // Act
        bool result = IsUnique.UsingHashSet(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsingHashSet_SingleCharacter_ReturnsTrue()
    {
        // Arrange
        string input = "a";

        // Act
        bool result = IsUnique.UsingHashSet(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsingHashSet_CaseSensitive_ReturnsTrue()
    {
        // Arrange
        string input = "aA";

        // Act
        bool result = IsUnique.UsingHashSet(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsingHashSet_NullString_ReturnsTrue()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = IsUnique.UsingHashSet(input!);

        // Assert
        Assert.True(result);
    }

    #endregion

    #region Bit Vector Approach Tests

    [Fact]
    public void UsingBitVector_UniqueCharacters_ReturnsTrue()
    {
        // Arrange
        string input = "abcdef";

        // Act
        bool result = IsUnique.UsingBitVector(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsingBitVector_DuplicateCharacters_ReturnsFalse()
    {
        // Arrange
        string input = "hello";

        // Act
        bool result = IsUnique.UsingBitVector(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UsingBitVector_EmptyString_ReturnsTrue()
    {
        // Arrange
        string input = "";

        // Act
        bool result = IsUnique.UsingBitVector(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsingBitVector_LongerThan26Chars_ReturnsFalse()
    {
        // Arrange - 27 characters, must have duplicates
        string input = "abcdefghijklmnopqrstuvwxyz" + "a";

        // Act
        bool result = IsUnique.UsingBitVector(input);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Brute Force Approach Tests

    [Fact]
    public void UsingBruteForce_UniqueCharacters_ReturnsTrue()
    {
        // Arrange
        string input = "abcdef";

        // Act
        bool result = IsUnique.UsingBruteForce(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsingBruteForce_DuplicateCharacters_ReturnsFalse()
    {
        // Arrange
        string input = "hello";

        // Act
        bool result = IsUnique.UsingBruteForce(input);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Sorting Approach Tests

    [Fact]
    public void UsingSorting_UniqueCharacters_ReturnsTrue()
    {
        // Arrange
        string input = "abcdef";

        // Act
        bool result = IsUnique.UsingSorting(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UsingSorting_DuplicateCharacters_ReturnsFalse()
    {
        // Arrange
        string input = "hello";

        // Act
        bool result = IsUnique.UsingSorting(input);

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Theory Tests - All Approaches

    [Theory]
    [InlineData("", true)]
    [InlineData("a", true)]
    [InlineData("ab", true)]
    [InlineData("aa", false)]
    [InlineData("abcdefghij", true)]
    [InlineData("abcdefghija", false)]
    public void AllApproaches_VariousInputs_ReturnExpectedResults(string input, bool expected)
    {
        // Test all approaches with the same input
        Assert.Equal(expected, IsUnique.UsingHashSet(input));
        Assert.Equal(expected, IsUnique.UsingBruteForce(input));
        Assert.Equal(expected, IsUnique.UsingSorting(input));

        // Bit vector only works for lowercase a-z
        if (input.All(c => c >= 'a' && c <= 'z'))
        {
            Assert.Equal(expected, IsUnique.UsingBitVector(input));
        }
    }

    #endregion
}
