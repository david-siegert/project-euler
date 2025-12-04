# N-Gon Ring Solution Algorithm

The algorithm and code in Program.cs is 100% AI free and written by me (Testing the GitHub COpilot snooze function). However the rest of this description is entirely Copilot generated.

## Overview

This algorithm solves the N-Gon ring problem by finding all valid arrangements of numbers 1 through 2N that form an N-sided polygon ring where each line (triplet of numbers) sums to the same total.

## Algorithm Description

### 1. Initialization and Setup

The algorithm begins by setting up the problem parameters:

-   **N = 12**: The size of the N-Gon (12-sided polygon)
-   **n = 2N = 24**: Total numbers used (1 through 24)
-   **Tmax = (7N + 3) / 2**: Maximum possible sum per line
-   **Tmin = (10N + 6) / 4**: Minimum possible sum per line

The formulas for Tmin and Tmax are derived from the constraint that all numbers 1-24 must be used exactly once, and each line must sum to the same value T.

### 2. Pre-computation of Summands

**Function: `FindPossibleSummands()`**

For each possible sum value from (Tmin - n) to (Tmax - 1), the algorithm pre-computes all valid pairs (b, c) where:

-   b + c = sum
-   b ≠ c
-   Both b and c are in the range [1, n]

This creates a lookup dictionary that allows quick access to all possible ways to complete a triplet when the first number is known.

### 3. Main Search Loop

For each possible total T from Tmin to Tmax:

#### 3.1 Generate Starting Triplets

**Function: `FindSetsByTotalAndStartNumber(T, startNum)`**

For each starting number (1 to n):

-   Calculate the required complement: T - startNum
-   Look up all valid pairs (b, c) that sum to this complement
-   Create initial triplets (startNum, b, c) and (startNum, c, b)
-   Ensure b and c are different from startNum

#### 3.2 Recursive Search

**Function: `CheckNext(current, T)`**

This is the core recursive backtracking algorithm:

1. **Base Case**: If we've built N triplets:

    - Check if the last triplet's third number (c) equals the first triplet's second number (b)
    - This ensures the ring closes properly
    - If valid, add to solution set

2. **Recursive Case**: Build the next triplet:
    - The next triplet must start with the last triplet's ending number (c becomes the new b)
    - Calculate complement: T - b
    - Try all valid summand pairs (s1, s2) from the pre-computed dictionary
3. **Constraint Checking**:
    - **No duplicate numbers**: New numbers (s1 or s2) must not already appear in the current partial solution
    - **Ring closure exception**: The final triplet can reuse the starting number to close the ring
    - **Pruning**: Skip triplets already used in other solutions for this T value (tracked in `solutionTripplesForT`)

### 4. Solution Validation

The algorithm ensures validity through:

-   **Sum consistency**: All triplets sum to the same value T
-   **Uniqueness**: Each number 1-24 is used exactly once (enforced by `ContainsNumber()` checks)
-   **Ring structure**: The sequence of triplets forms a closed ring where each triplet shares a number with the next

### 5. Output Generation

**Function: `OutputOrderedStrings()`**

For each valid solution:

-   Concatenates all triplet numbers into a single string
-   Orders solutions by numeric value (descending)
-   Reports string length and value

## Algorithm Complexity

-   **Time**: O(T × n × k^N) where k is the average number of valid summand pairs
-   **Space**: O(T × k) for summand storage + O(N) for recursion depth
-   **Optimization**: Pre-computed summands and pruning via `solutionTripplesForT` significantly reduce the search space

## Key Design Choices

1. **Pre-computation**: Summand dictionary trades memory for speed
2. **Backtracking**: Recursive search with constraint checking allows early pruning
3. **Duplicate prevention**: HashSet tracking prevents exploring equivalent solution branches
4. **Flexible N value**: Algorithm works for any N-Gon size (though set to N=12)
