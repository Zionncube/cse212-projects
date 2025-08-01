using System.Collections;

// Define a static class named Recursion, meaning all the methods inside will be accessible without creating an object.
public static class Recursion
{
    /// Problem 1: Sum of Squares
    /// Using recursion, calculate the sum of squares: 1² + 2² + 3² + ... + n²
    /// Base case: if n <= 0, return 0
    /// Recursive case: n² + SumSquaresRecursive(n-1)
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0; // Base case
        return n * n + SumSquaresRecursive(n - 1); // Recursive case
    }

    /// Problem 2: Generate all permutations of a certain size from a set of letters
    /// Each letter is unique and you want to build all possible combinations of the given size
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: when the word has reached the desired size
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Loop through each letter and recurse
        foreach (char letter in letters)
        {
            // If the letter is not already used in the current word
            if (!word.Contains(letter))
            {
                // Add letter to word and continue building
                PermutationsChoose(results, letters, size, word + letter);
            }
        }
    }

    /// Problem 3: Count the number of ways to climb stairs
    /// A person can take 1, 2, or 3 steps at a time
    /// Use memoization to store results for performance
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // If already calculated, return saved result
        if (remember.ContainsKey(s))
            return remember[s];

        // Otherwise, calculate and store the result
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// Problem 4: Generate all binary strings from a pattern with wildcards '*'
    /// Example: "1*0" → ["100", "110"]
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // If pattern has no '*', add it as a complete result
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace '*' with '0' and recurse
        string patternWith0 = pattern.Substring(0, index) + "0" + pattern.Substring(index + 1);
        WildcardBinary(patternWith0, results);

        // Replace '*' with '1' and recurse
        string patternWith1 = pattern.Substring(0, index) + "1" + pattern.Substring(index + 1);
        WildcardBinary(patternWith1, results);
    }

    /// Problem 5: Solve a maze using recursion
    /// You start at (0,0) and want to reach the end point
    /// The maze is explored using all possible paths
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize the current path if it's null (first time running the function)
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Check if the current position is out of bounds or is a wall
        if (!maze.IsInMaze(x, y) || !maze.IsOpen(x, y) || currPath.Contains((x, y))) return;

        // Add the current position to the path
        currPath.Add((x, y));

        // Check if we've reached the goal
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Explore all 4 directions
            SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath)); // Down
            SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath)); // Up
            SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath)); // Right
            SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath)); // Left
        }
    }
}
