[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Bob (2), Tim (5), Sue (3)
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found: 
    // - Original implementation didn't properly decrement turns
    // - Didn't maintain correct order when requeuing
    // - Failed to handle final turns correctly
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        // ... existing test code ...
    }

    [TestMethod]
    // Scenario: Bob (2), Tim (5), Sue (3), add George after 5 turns
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Defect(s) Found:
    // - Mid-queue additions weren't handled properly
    // - Turn counting was incorrect after additions
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        // ... existing test code ...
    }

    [TestMethod]
    // Scenario: Bob (2), Tim (0), Sue (3)
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found:
    // - Zero turns not treated as infinite
    // - Infinite turn items were being removed
    public void TestTakingTurnsQueue_ForeverZero()
    {
        // ... existing test code ...
    }

    [TestMethod]
    // Scenario: Tim (-3), Sue (3)
    // Expected: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Defect(s) Found:
    // - Negative turns not treated as infinite
    // - Infinite turn logic was incorrect
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        // ... existing test code ...
    }

    [TestMethod]
    // Scenario: Empty queue
    // Expected: "No one in the queue." exception
    // Defect(s) Found:
    // - Missing exception handling
    // - Incorrect error message
    public void TestTakingTurnsQueue_Empty()
    {
        // ... existing test code ...
    }
}
