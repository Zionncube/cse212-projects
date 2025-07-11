[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Test Case: Basic priority ordering
    // Input: [Low(1), High(3), Medium(2)]
    // Expected Output: High, Medium, Low
    // Test Result: PASS after fixes
    // Defects Fixed:
    // 1. Original didn't properly order by priority
    // 2. Max priority selection was incorrect
    // 3. Return value formatting issues
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
    // Test Case: Equal priority FIFO behavior
    // Input: [First(1), Second(1), Third(1)]
    // Expected Output: First, Second, Third
    // Test Result: PASS after fixes
    // Defects Fixed:
    // 1. FIFO order not maintained for equal priorities
    // 2. Insertion order tracking was missing
    // 3. Dequeue selection logic was flawed
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
    // Test Case: Empty queue handling
    // Input: Empty queue
    // Expected Output: Throws InvalidOperationException
    // Test Result: PASS after fixes
    // Defects Fixed:
    // 1. Missing empty queue check
    // 2. Incorrect exception type/message
    // 3. Error handling flow issues
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Test Case: Complex mixed priorities
    // Input: [A(1), B(3), C(2), D(3), E(1)]
    // Expected Output: B, D, C, A, E
    // Test Result: PASS after fixes
    // Defects Fixed:
    // 1. Complex priority handling failed
    // 2. Multiple high priority items not handled
    // 3. Order preservation issues
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
