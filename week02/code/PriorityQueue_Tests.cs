[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Basic queue with different priorities
    // Expected: Highest priority items dequeued first
    // Test Case Covers: Basic dequeue by priority
    public void TestPriorityQueue_BasicPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 3);
        pq.Enqueue("Medium", 2);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same priority
    // Expected: FIFO order for same priority
    // Test Case Covers: FIFO behavior with equal priorities
    public void TestPriorityQueue_EqualPriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 1);
        pq.Enqueue("Second", 1);
        pq.Enqueue("Third", 1);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Empty queue dequeue attempt
    // Expected: Throws InvalidOperationException
    // Test Case Covers: Empty queue handling
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Mixed priorities with duplicates
    // Expected: Correct priority order with FIFO for duplicates
    // Test Case Covers: Complex priority handling
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);
        pq.Enqueue("D", 3);
        pq.Enqueue("E", 1);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("E", pq.Dequeue());
    }
}
