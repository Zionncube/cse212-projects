public class PriorityQueue
{
    private List<PriorityItem> _queue = new();  // Internal list to store queue items

    /// <summary>
    /// Add a new value to the queue with an associated priority.  
    /// The node is always added to the back of the queue regardless of the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        // Create a new priority item with given value and priority
        var newNode = new PriorityItem(value, priority);
        // Add to the end of the queue (O(1) operation)
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        // Check if queue is empty
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Initialize index of highest priority item to first element
        var highPriorityIndex = 0;
        
        // Traverse entire queue to find highest priority item
        for (int index = 1; index < _queue.Count; index++)  // Fixed: now checks all elements
        {
            // Update index if current item has HIGHER priority (not equal)
            // This maintains FIFO order for same-priority items
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Save value of highest priority item
        var value = _queue[highPriorityIndex].Value;
        // Remove item from queue (O(n) due to shifting elements)
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    public override string ToString()
    {
        // Create string representation of queue items
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    // Item value (e.g., task name)
    internal string Value { get; set; }
    // Priority (higher number = higher priority)
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        // Format: "Value (Pri:Number)"
        return $"{Value} (Pri:{Priority})";
    }
}
