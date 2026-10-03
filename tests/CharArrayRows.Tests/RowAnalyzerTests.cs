using CharArrayRows;
using Xunit;

namespace CharArrayRows.Tests;

public class RowAnalyzerTests
{
    [Fact]
    public void Row_AllLowercase_ReturnsTrue()
        => Assert.True(RowAnalyzer.IsRowAllLowercase("привет".ToCharArray()));

    [Fact]
    public void Row_WithYo_ReturnsTrue()
        => Assert.True(RowAnalyzer.IsRowAllLowercase("ёжик".ToCharArray()));

    [Fact]
    public void Row_WithUppercase_ReturnsFalse()
        => Assert.False(RowAnalyzer.IsRowAllLowercase("пРивет".ToCharArray()));

    [Fact]
    public void Row_AllUppercase_ReturnsFalse()
        => Assert.False(RowAnalyzer.IsRowAllLowercase("ПРИВЕТ".ToCharArray()));

    [Fact]
    public void Row_Empty_ReturnsFalse()
        => Assert.False(RowAnalyzer.IsRowAllLowercase(Array.Empty<char>()));

    [Fact]
    public void FindRows_ReturnsCorrectNumbers()
    {
        var m = new char[,]
        {
            { 'а', 'б', 'в' },
            { 'а', 'Б', 'в' },
            { 'г', 'д', 'е' }
        };
        Assert.Equal(new List<int> { 1, 3 }, RowAnalyzer.FindLowercaseRows(m));
    }

    [Fact]
    public void FindRows_NoSuitableRows_ReturnsEmptyList()
    {
        var m = new char[,] { { 'А', 'Б' }, { 'В', 'г' } };
        Assert.Empty(RowAnalyzer.FindLowercaseRows(m));
    }
}