/// <summary>
/// Represents a single node in the binary search tree.
/// </summary>
public class Node
{
    public int Data { get; set; }        // The data stored in the node
    public Node? Left { get; set; }      // Pointer to the left child
    public Node? Right { get; set; }     // Pointer to the right child

    public Node(int data)
    {
        Data = data;
    }

    /// <summary>
    /// Inserts a new value into the subtree starting from this node.
    /// </summary>
    public void Insert(int value)
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // Duplicate values are ignored (not added again)
    }

    /// <summary>
    /// Searches for a value in the subtree.
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else if (value < Data)
            return Left != null && Left.Contains(value);
        else
            return Right != null && Right.Contains(value);
    }

    /// <summary>
    /// Calculates the height of the subtree rooted at this node.
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
