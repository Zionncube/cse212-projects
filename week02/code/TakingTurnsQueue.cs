/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    /// <summary>
    /// Internal class to track queue items with their turn information
    /// </summary>
    private class QueueItem
    {
        public string Name { get; }               // Person's name (immutable)
        public int OriginalTurns { get; }         // Original number of turns specified
        public int? RemainingTurns { get; set; }  // Remaining turns (null = infinite)

        /// <summary>
        /// Initialize a new queue item
        /// </summary>
        /// <param name="name">Person's name</param>
        /// <param name="turns">
        /// Number of turns: 
        ///   >0 : finite turns
        ///   ≤0 : infinite turns (marked with null)
        /// </param>
        public QueueItem(string name, int turns)
        {
            Name = name;
            OriginalTurns = turns;
            // Set remaining turns - null means infinite
            RemainingTurns = turns <= 0 ? null : turns;
        }
    }

    private readonly Queue<QueueItem> _queue = new();  // Main queue storage
    public int Length => _queue.Count;                 // Current queue length

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        // Create new QueueItem and add to end of queue
        _queue.Enqueue(new QueueItem(name, turns));
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_queue.Count == 0)  // Check if queue is empty
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Get next person from front of queue
        var item = _queue.Dequeue();
        
        // Handle infinite turns case (turns ≤ 0)
        if (!item.RemainingTurns.HasValue)
        {
            // Always requeue people with infinite turns
            _queue.Enqueue(item);
            // Return new Person with original turn count
            return new Person(item.Name, item.OriginalTurns);
        }
        
        // Handle finite turns case
        if (item.RemainingTurns > 1)
        {
            // Decrement turns and requeue if turns remain
            item.RemainingTurns--;
            _queue.Enqueue(item);
        }
        // Note: If RemainingTurns == 1, this was their last turn (don't requeue)

        // Return new Person with original turn count
        return new Person(item.Name, item.OriginalTurns);
    }

    /// <summary>
    /// Generate string representation of queue
    /// </summary>
    public override string ToString()
    {
        return string.Join(", ", _queue.Select(item => 
            $"{item.Name} ({item.RemainingTurns?.ToString() ?? "∞"})"));
    }
}
