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
}    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3

        // Solve using recursion
        decimal ways = CountWaysToClimb(s - 1) + CountWaysToClimb(s - 2) + CountWaysToClimb(s - 3);
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null) {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // currPath.Add((1,2)); // Use this syntax to add to the current path

        // TODO Start Problem 5
        // ADD CODE HERE

        // results.Add(currPath.AsString()); // Use this to add your path to the results array keeping track of complete maze solutions when you find the solution.
    }
}
