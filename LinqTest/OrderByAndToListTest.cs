using System.Collections.Generic;
using System.Linq;
using LinqTest.Models;
using Xunit;

namespace LinqTest;

public class OrderByAndToListTest
{
    [Fact]
    public void IntegerOrderByToListTest()
    {
        IReadOnlyCollection<int> expectedCollection = new List<int> { 1, 2, 2, 3, 4 };

        List<int> actualList = expectedCollection.OrderBy(i => i)
                                                 .ToList();

        Assert.Equal(5, actualList.Count);
        Assert.Equal(expectedCollection.Count, actualList.Count);
        Assert.All(expectedCollection, i => Assert.Contains(i, actualList));
    }

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
        List<DummyClass> actualList = expectedCollection
                                     .OrderBy(c => c.IntValue)
                                     .ToList();

        Assert.Equal(5, actualList.Count);
        Assert.Equal(expectedCollection.Count, actualList.Count);
        Assert.All(expectedCollection, i => Assert.Contains(i, actualList));
    }

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
        List<DummyRecord> actualList = expectedCollection.OrderBy(r => r.IntValue)
                                                         .ToList();

        Assert.Equal(5, actualList.Count);
        Assert.Equal(expectedCollection.Count, actualList.Count);
        Assert.All(expectedCollection, i => Assert.Contains(i, actualList));
    }
}