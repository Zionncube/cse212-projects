public class TakingTurnsQueue
{
    private class PersonNode
    {
        public Person Person { get; }
        public int RemainingTurns { get; set; }

        public PersonNode(Person person)
        {
            Person = person;
            RemainingTurns = person.Turns;
        }
    }

    private readonly Queue<PersonNode> _queue = new();

    public int Length => _queue.Count;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _queue.Enqueue(new PersonNode(person));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var node = _queue.Dequeue();

        if (node.Person.Turns <= 0) // Infinite turns
        {
            _queue.Enqueue(node);
            return node.Person;
        }

        if (node.RemainingTurns > 1)
        {
            node.RemainingTurns--;
            _queue.Enqueue(node);
        }

        return node.Person;
    }
}
