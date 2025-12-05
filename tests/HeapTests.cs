namespace DefaultNamespace.Tests;

using Xunit;

public class MinHeapTests
{
    [Fact]
    public void Add_SingleElement_CanPeekElement()
    {
        var heap = new MinHeap<string>();
        heap.Add("test", 5);

        Assert.Equal("test", heap.Peek());
    }

    [Fact]
    public void Add_MultipleElements_PeekReturnsMinimum()
    {
        var heap = new MinHeap<string>();
        heap.Add("high", 10);
        heap.Add("low", 1);
        heap.Add("medium", 5);

        Assert.Equal("low", heap.Peek());
    }

    [Fact]
    public void GetMin_MultipleElements_ReturnsInAscendingOrder()
    {
        var heap = new MinHeap<int>();
        heap.Add(100, 10);
        heap.Add(50, 5);
        heap.Add(200, 20);
        heap.Add(10, 1);
        heap.Add(150, 15);

        Assert.Equal(10, heap.GetMin());
        Assert.Equal(50, heap.GetMin());
        Assert.Equal(100, heap.GetMin());
        Assert.Equal(150, heap.GetMin());
        Assert.Equal(200, heap.GetMin());
    }

    [Fact]
    public void GetMin_AfterMultipleAdds_MaintainsHeapProperty()
    {
        var heap = new MinHeap<string>();
        heap.Add("item1", 5);
        heap.Add("item2", 3);
        heap.Add("item3", 7);
        heap.Add("item4", 1);

        Assert.Equal("item4", heap.GetMin()); // priority 1
        Assert.Equal("item2", heap.GetMin()); // priority 3
        Assert.Equal("item1", heap.GetMin()); // priority 5
        Assert.Equal("item3", heap.GetMin()); // priority 7
    }

    [Fact]
    public void Add_DuplicatePriorities_HandledCorrectly()
    {
        var heap = new MinHeap<string>();
        heap.Add("first", 5);
        heap.Add("second", 5);
        heap.Add("third", 5);

        var first = heap.GetMin();
        var second = heap.GetMin();
        var third = heap.GetMin();

        Assert.Contains(first, new[] { "first", "second", "third" });
        Assert.Contains(second, new[] { "first", "second", "third" });
        Assert.Contains(third, new[] { "first", "second", "third" });
    }

    [Fact]
    public void MinHeap_WithNegativePriorities_WorksCorrectly()
    {
        var heap = new MinHeap<string>();
        heap.Add("negative", -5);
        heap.Add("positive", 5);
        heap.Add("zero", 0);

        Assert.Equal("negative", heap.GetMin());
        Assert.Equal("zero", heap.GetMin());
        Assert.Equal("positive", heap.GetMin());
    }
}

public class MaxHeapTests
{
    [Fact]
    public void Add_SingleElement_CanPeekElement()
    {
        var heap = new MaxHeap<string>();
        heap.Add("test", 5);

        Assert.Equal("test", heap.Peek());
    }

    [Fact]
    public void Add_MultipleElements_PeekReturnsMaximum()
    {
        var heap = new MaxHeap<string>();
        heap.Add("high", 10);
        heap.Add("low", 1);
        heap.Add("medium", 5);

        Assert.Equal("high", heap.Peek());
    }

    [Fact]
    public void GetMax_MultipleElements_ReturnsInDescendingOrder()
    {
        var heap = new MaxHeap<int>();
        heap.Add(100, 10);
        heap.Add(50, 5);
        heap.Add(200, 20);
        heap.Add(10, 1);
        heap.Add(150, 15);

        Assert.Equal(200, heap.GetMax());
        Assert.Equal(150, heap.GetMax());
        Assert.Equal(100, heap.GetMax());
        Assert.Equal(50, heap.GetMax());
        Assert.Equal(10, heap.GetMax());
    }

    [Fact]
    public void GetMax_AfterMultipleAdds_MaintainsHeapProperty()
    {
        var heap = new MaxHeap<string>();
        heap.Add("item1", 5);
        heap.Add("item2", 3);
        heap.Add("item3", 7);
        heap.Add("item4", 1);

        Assert.Equal("item3", heap.GetMax()); // priority 7
        Assert.Equal("item1", heap.GetMax()); // priority 5
        Assert.Equal("item2", heap.GetMax()); // priority 3
        Assert.Equal("item4", heap.GetMax()); // priority 1
    }

    [Fact]
    public void Add_DuplicatePriorities_HandledCorrectly()
    {
        var heap = new MaxHeap<string>();
        heap.Add("first", 5);
        heap.Add("second", 5);
        heap.Add("third", 5);

        var first = heap.GetMax();
        var second = heap.GetMax();
        var third = heap.GetMax();

        Assert.Contains(first, new[] { "first", "second", "third" });
        Assert.Contains(second, new[] { "first", "second", "third" });
        Assert.Contains(third, new[] { "first", "second", "third" });
    }

    [Fact]
    public void MaxHeap_WithNegativePriorities_WorksCorrectly()
    {
        var heap = new MaxHeap<string>();
        heap.Add("negative", -5);
        heap.Add("positive", 5);
        heap.Add("zero", 0);

        Assert.Equal("positive", heap.GetMax());
        Assert.Equal("zero", heap.GetMax());
        Assert.Equal("negative", heap.GetMax());
    }
}

public class MaxHeapComparerTests
{
    [Fact]
    public void Compare_FirstLessThanSecond_ReturnsPositive()
    {
        var comparer = new MaxHeapComparer();
        var result = comparer.Compare(3, 5);

        Assert.Equal(1, result);
    }

    [Fact]
    public void Compare_FirstGreaterThanSecond_ReturnsNegative()
    {
        var comparer = new MaxHeapComparer();
        var result = comparer.Compare(5, 3);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void Compare_EqualValues_ReturnsZero()
    {
        var comparer = new MaxHeapComparer();
        var result = comparer.Compare(5, 5);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Compare_NegativeNumbers_WorksCorrectly()
    {
        var comparer = new MaxHeapComparer();

        Assert.Equal(1, comparer.Compare(-5, -3));
        Assert.Equal(-1, comparer.Compare(-3, -5));
        Assert.Equal(0, comparer.Compare(-5, -5));
    }

    [Fact]
    public void Compare_InvertsDefaultComparison()
    {
        var comparer = new MaxHeapComparer();
        var defaultComparison = 3.CompareTo(5);
        var customComparison = comparer.Compare(3, 5);

        Assert.Equal(-defaultComparison, customComparison);
    }
}
