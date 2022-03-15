using System.Collections.Generic;
using System.Linq;
using LinqTest.Models;
using Xunit;

namespace LinqTest;

public class ToListTest
{
    [Fact]
    public void IntegerToListTest()
    {
        IReadOnlyCollection<int> expectedCollection = new List<int> { 1, 2, 2, 3, 4 };

        List<int> actualList = expectedCollection.ToList();

        Assert.Equal(expectedCollection.Count, actualList.Count);
    }

    [Fact]
    public void ClassObjectToListTest()
    {
        IReadOnlyCollection<DummyClass> expectedCollection = new List<DummyClass>
                                                             {
                                                                 new(1),
                                                                 new(2),
                                                                 new(2),
                                                                 new(3),
                                                                 new(4)
                                                             };

        List<DummyClass> actualList = expectedCollection.ToList();

        Assert.Equal(expectedCollection.Count, actualList.Count);
    }

    [Fact]
    public void RecordObjectToListTest()
    {
        IReadOnlyCollection<DummyRecord> expectedCollection = new List<DummyRecord>
                                                              {
                                                                  new(1),
                                                                  new(2),
                                                                  new(2),
                                                                  new(3),
                                                                  new(4)
                                                              };

        List<DummyRecord> actualList = expectedCollection.ToList();

        Assert.Equal(expectedCollection.Count, actualList.Count);
    }
}