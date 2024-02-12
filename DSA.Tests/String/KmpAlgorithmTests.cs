using DSA.String;

namespace DSA.Tests.String;

public class KmpAlgorithmTests
{
    [Fact]
    public void FindOccurrences_WhenPatternIsNull_ShouldReturnEmptyArray()
    {
        // Arrange
        string text = "abcd";
        string pattern = null;

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FindOccurrences_WhenPatternIsEmpty_ShouldReturnZero()
    {
        // Arrange
        string text = "abcd";
        string pattern = "";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Equal(new int[] { 0 }, result);
    }

    [Fact]
    public void FindOccurrences_WhenTextIsNull_ShouldReturnEmptyArray()
    {
        // Arrange
        string text = null;
        string pattern = "ab";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FindOccurrences_WhenPatternIsLongerThanText_ShouldReturnEmptyArray()
    {
        // Arrange
        string text = "abc";
        string pattern = "abcd";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FindOccurrences_WhenNoOccurrence_ShouldReturnEmptyArray()
    {
        // Arrange
        string text = "abcdefgh";
        string pattern = "xyz";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FindOccurrences_WhenSingleOccurrence_ShouldReturnCorrectIndex()
    {
        // Arrange
        string text = "abcdabc";
        string pattern = "abc";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Equal(new int[] { 0, 4 }, result);
    }

    [Fact]
    public void FindOccurrences_WhenMultipleOccurrences_ShouldReturnCorrectIndices()
    {
        // Arrange
        string text = "ababcabab";
        string pattern = "ab";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Equal(new int[] { 0, 2, 5, 7 }, result);
    }

    [Fact]
    public void FindOccurrences_WhenPatternAtTheEnd_ShouldReturnCorrectIndex()
    {
        // Arrange
        string text = "abcdef";
        string pattern = "ef";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Equal(new int[] { 4 }, result);
    }

    [Fact]
    public void FindOccurrences_WhenPatternAtTheBeginning_ShouldReturnCorrectIndex()
    {
        // Arrange
        string text = "xyzabc";
        string pattern = "xyz";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Equal(new int[] { 0 }, result);
    }

    [Fact]
    public void FindOccurrences_WhenPatternOccursOnlyOnce_ShouldReturnCorrectIndex()
    {
        // Arrange
        string text = "abcdefgh";
        string pattern = "def";

        // Act
        var result = KmpAlgorithm.FindOccurrences(text, pattern);

        // Assert
        Assert.Equal(new int[] { 3 }, result);
    }
}
