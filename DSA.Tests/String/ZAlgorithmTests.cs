using DSA.String;

namespace DSA.Tests.String;

public class ZAlgorithmTests
{
    [Fact]
    public void EmptyString()
    {
        int[] expected = [];
        int[] actual = ZAlgorithm.ComputePrefixArray(string.Empty);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SingleCharacterString()
    {
        int[] expected = [0];
        int[] actual = ZAlgorithm.ComputePrefixArray("a");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StringWithAllIdenticalCharacters()
    {
        int[] expected = [5, 4, 3, 2, 1, 0];
        int[] actual = ZAlgorithm.ComputePrefixArray("aaaaa");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StringWithRepeatingPattern()
    {
        int[] expected = [2, 1, 0, 2, 1, 0];
        int[] actual = ZAlgorithm.ComputePrefixArray("abcabc");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StringWithNoRepeatingPattern()
    {
        int[] expected = [0, 0, 0, 0, 0, 0];
        int[] actual = ZAlgorithm.ComputePrefixArray("abcdef");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StringWithOverlappingPatterns()
    {
        int[] expected = [3, 0, 1, 0, 3, 0, 1, 0];
        int[] actual = ZAlgorithm.ComputePrefixArray("abababab");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StringWithLongRepeatingPattern()
    {
        int[] expected = [0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0];
        int[] actual = ZAlgorithm.ComputePrefixArray("aaaaaaaaaa");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StringWithMixOfPatterns()
    {
        int[] expected = [3, 0, 1, 0, 0, 0, 0];
        int[] actual = ZAlgorithm.ComputePrefixArray("ababaxyz");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void StringWithSpecialCharacters()
    {
        int[] expected = [0, 0, 1, 0, 2, 0];
        int[] actual = ZAlgorithm.ComputePrefixArray("ab$ab$");
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void VeryLongString()
    {
        string longText = new string('a', 10000);
        int[] expected = Enumerable.Repeat(9999, 10000).ToArray();
        int[] actual = ZAlgorithm.ComputePrefixArray(longText);
        Assert.Equal(expected, actual);
    }
}