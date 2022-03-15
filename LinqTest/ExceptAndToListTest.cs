using System.Collections.Generic;
using System.Linq;
using LinqTest.Models;
using Xunit;
using Xunit.Abstractions;

namespace LinqTest;

public class ExceptAndToListTest
{
    private readonly ITestOutputHelper _output;

    public ExceptAndToListTest(ITestOutputHelper output)
    {
        _output = output;
    }

    // Passed
    [Fact]
    public void ClassObjectExceptToListTest()
    {
        IReadOnlyCollection<DummyClass> expectedCollection = new List<DummyClass>
                                                             {
                                                                 new(1),
                                                                 new(2),
                                                                 new(2),
                                                                 new(3),
                                                                 new(4)
                                                             };
        var emptyList = new List<DummyClass>();

        List<DummyClass> actualList = expectedCollection
                                     .Except(emptyList)
                                     .ToList();

        Assert.Equal(expectedCollection.Count, actualList.Count);
    }

    // Failed
    [Fact]
    public void IntegerToListTest()
    {
        IReadOnlyCollection<int> expectedCollection = new List<int> { 1, 2, 2, 3, 4 };

        var emptyList = new List<int>();

        List<int> actualList = expectedCollection.Except(emptyList)
                                                 .ToList();

        var collectionStr = string.Join(" | ", actualList);
        _output.WriteLine($"int list -> {collectionStr}");

        Assert.Equal(expectedCollection.Count, actualList.Count);
    }

    // Failed
    [Fact]
    public void StringToListTest()
    {
        IReadOnlyCollection<string> expectedCollection = new List<string> { "1", "2", "2", "3", "4" };

        var emptyList = new List<string>();

        List<string> actualList = expectedCollection.Except(emptyList)
                                                    .ToList();

        var collectionStr = string.Join(" | ", actualList);
        _output.WriteLine($"string list -> {collectionStr}");

        Assert.Equal(expectedCollection.Count, actualList.Count);
    }

    // Failed
    [Fact]
    public void RecordObjectExceptToListTest()
    {
        IReadOnlyCollection<DummyRecord> expectedCollection = new List<DummyRecord>
                                                              {
                                                                  new(1),
                                                                  new(2),
                                                                  new(2),
                                                                  new(3),
                                                                  new(4)
                                                              };
        var emptyList = new List<DummyRecord>();

        List<DummyRecord> actualList = expectedCollection.Except(emptyList)
                                                         .ToList();

        string collectionStr = string.Join(" | ", actualList.Select(r => r.IntValue));
        _output.WriteLine($"int list -> {collectionStr}");
        
        Assert.Equal(expectedCollection.Count, actualList.Count);
    }

    // Failed
    [Fact]
    public void RecordObjectExceptWithNonEmptyListToListTest()
    {
        IReadOnlyCollection<DummyRecord> expectedCollection = new List<DummyRecord>
                                                              {
                                                                  new(1),
                                                                  new(2),
                                                                  new(2),
                                                                  new(3),
                                                                  new(4)
                                                              };
        var dummy1 = new List<DummyRecord>() { new(1) };

        List<DummyRecord> actualList = expectedCollection.Except(dummy1)
                                                         .ToList();

        string collectionStr = string.Join(" | ", actualList.Select(r => r.IntValue));
        _output.WriteLine($"int list -> {collectionStr}");
        
        Assert.Equal(4, actualList.Count);
    }
}