# cse212-ww-student-template
This is the starting repository for student work for CSE 212 at BYU-Idaho. It should be used as a template repository for each student to start their own repo.

# Permissions to use
This code is used for class assignments for CSE 212 at Brigham Young University-Idaho. Copying this code is a violation of the BYU-Idaho Honor Code.

To ensure that you are learning the concepts of the course, any code that you add to this starter template should be your own work. If you have any questions about this, ask your teacher.


public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        return []; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}

Let's break down the problem and implement the MultiplesOf function and the RotateListRight function with comments.

MultiplesOf Function
The MultiplesOf function creates and returns an array of multiples of a number. The starting number and the number of multiples are provided as inputs to the function.

/// Creates and returns an array of multiples of a number.
/// <param name="startingNumber">The starting number.</param>
/// <param name="numberOfMultiples">The number of multiples.</param>
/// <returns>An array of multiples.</returns>

public static double[] MultiplesOf(double startingNumber, int numberOfMultiples)
{
    // Step 1: Create an array to store the multiples
    double[] multiples = new double[numberOfMultiples];

    // Step 2: Loop through the array and calculate each multiple
    for (int i = 0; i < numberOfMultiples; i++)
    {
        // Calculate the multiple by multiplying the starting number with the current index plus 1
        multiples[i] = startingNumber * (i + 1);
    }

    // Step 3: Return the array of multiples
    return multiples;
}


RotateListRight Function
The RotateListRight function rotates a list to the right by a specified amount.

/// Rotates a list to the right by a specified amount.
/// <param name="data">The list to rotate.</param>
/// <param name="amount">The amount to rotate.</param>

public static void RotateListRight(List<int> data, int amount)
{
    // Step 1: Calculate the effective rotation amount
    // This is done by taking the modulus of the amount with the count of the list
    // This handles cases where the amount is greater than the count of the list
    amount = amount % data.Count;

    // Step 2: Get the last 'amount' elements of the list
    List<int> lastElements = data.GetRange(data.Count - amount, amount);

    // Step 3: Remove the last 'amount' elements from the list
    data.RemoveRange(data.Count - amount, amount);

    // Step 4: Insert the last elements at the beginning of the list
    data.InsertRange(0, lastElements);
}


