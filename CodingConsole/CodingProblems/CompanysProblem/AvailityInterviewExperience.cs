using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace test_interview_problems.CompanysProblem
{
    public class AvailityInterviewExperience
    {
        public AvailityInterviewExperience()
        {

        }

        #region drawign robot problem explainations
        //The task describes a drawing robot that starts at coordinate(0, 0) on a 2D plane.
        //You are given a string called moves, where each character tells the robot to move one step in a specific direction.
        //According to the referenced problem description:

        //^ → move the robot up to(x, y + 1)
        //v → move the robot down to(x, y – 1)
        //< → move the robot left to(x – 1, y)
        //> → move the robot right to(x + 1, y)
        // [brainly.com]

        //        Each time the robot moves, it draws a line between its previous and new position.
        //        The robot follows the instructions in the exact order provided in the string.
        //Special Conditions

        //The robot will never revisit any point except possibly(0,0).
        //The robot may visit(0,0) exactly twice:

        //once at the beginning,
        //possibly once again at the end of its movement sequence.
        // [brainly.com]



        //Goal of the Task
        //You must determine whether the set of all line segments drawn by the robot forms a single rectangle after executing all moves.
        //To summarize, you are checking:

        //Does the robot trace out a shape where all sides form a proper rectangle?
        //Does the robot return to the origin(0,0) at the end — and only at the end?
        //Does the path avoid self‑intersection except at the beginning/end?
        #endregion
        public int DrawingRobotProblems(int[] A)
        {
            int n = A.Length;

            // Step 1: Replace negatives, zeros, and values > n with a placeholder
            for (int i = 0; i < n; i++)
            {
                if (A[i] <= 0 || A[i] > n)
                    A[i] = n + 1;
            }

            // Step 2: Mark presence using index as a hash
            for (int i = 0; i < n; i++)
            {
                int val = Math.Abs(A[i]);
                if (val >= 1 && val <= n)
                {
                    if (A[val - 1] > 0)
                        A[val - 1] = -A[val - 1];
                }
            }

            // Step 3: First positive index + 1 is the missing integer
            for (int i = 0; i < n; i++)
            {
                if (A[i] > 0)
                    return i + 1;
            }

            // Step 4: Otherwise, all 1..N exist → answer is N+1
            return n + 1;
        }

        #region Frog Distance Problem
        //The problem describes a scenario with:

        //N blocks, numbered from 0 to N–1.
        //Each block has a height, given in an array blocks[].
        //Two frogs initially stand on the same block.
        //The frogs want to jump away from each other, one going left and one going right.

        //⭐ Jumping Rules
        //A frog may jump from block i to block i–1 (left) or i+1 (right) only if:

        //The next block’s height is greater than or equal to the current block’s height.

        //This means:

        //A frog can climb to equal or higher height,
        //but cannot jump down to lower height.

        //⭐ Goal of the Problem
        //For every possible starting block, each frog jumps as far as possible in its direction (left or right).
        //Your task is to compute:

        //The maximum possible distance between the two frogs after they finish jumping.

        //In other words:

        //Pick a starting block k
        //Frog A jumps left from k as far as allowed
        //Frog B jumps right from k as far as allowed
        //Measure:
        //distance = right_most_reachable_position − left_most_reachable_position


        //Try this for all k, and return the largest distance found.


        //✅ Example
        //If:
        //blocks = [2, 6, 8, 5]

        //Try starting at each index:
        //Start at index 1 (height = 6):


        //Left frog:

        //From 1 → 0 (2 is lower → cannot move)
        //So left position = 1



        //Right frog:

        //From 1 → 2 (8 ≥ 6) → OK
        //From 2 → 3 (5 < 8) → STOP
        //So right position = 2



        //Distance = 2 – 1 = 1
        //You check this for every starting index and take the maximum.
        #endregion
        public int FrogDistanceProblem(int[] blocks)
        {

            int n = blocks.Length;
            int[] left = new int[n];
            int[] right = new int[n];

            // Compute how far we can go left from each index
            left[0] = 0;
            for (int i = 1; i < n; i++)
            {
                if (blocks[i] >= blocks[i - 1])
                    left[i] = left[i - 1];
                else
                    left[i] = i;
            }

            // Compute how far we can go right from each index
            right[n - 1] = n - 1;
            for (int i = n - 2; i >= 0; i--)
            {
                if (blocks[i] >= blocks[i + 1])
                    right[i] = right[i + 1];
                else
                    right[i] = i;
            }

            // Compute the max distance between left and right expansions
            int maxDist = 0;
            for (int i = 0; i < n; i++)
            {
                int dist = right[i] - left[i] + 1; // +1 because distance in blocks
                if (dist > maxDist)
                    maxDist = dist;
            }

            return maxDist;

        }             
    }

    #region Custom Memory Allocator.
    //What You Are Given
    //You must implement a class called Allocator that manages a simulated memory space.
    //✔ Memory size
    //You receive N bytes of memory.
    //N is guaranteed to be a power of 2 (e.g., 8, 16, 32, 64…).
    //✔ You must support two operations:

    //allocate(size)
    //free(address)


    //🔹 Operation 1: allocate(size)
    //This function must:

    //Allocate a block of memory of size 1, 4, or 8 bytes.
    //Follow strict alignment rules:

    //A 1‑byte variable can be placed anywhere.
    //A 4‑byte variable must be placed at an address divisible by 4.
    //An 8‑byte variable must be placed at an address divisible by 8.



    //Example:
    //If you request allocate(4) → The starting address must be one of:
    //0, 4, 8, 12, ...

    //✔ Additional Rules:


    //You must return the starting address of the allocated block.


    //Allocations must use the leftmost available space that satisfies the alignment and size requirement.


    //If memory cannot fit the block:
    //→ return -1


    //If the exact address range is already allocated
    //→ return -1



    //🔹 Operation 2: free(address)

    //This frees the variable that starts at the given address.
    //After freeing, the freed bytes become available again for future allocations.


    //🔹 Constraints That Must Be Enforced

    //Blocks must not overlap.
    //Allocations must follow alignment constraints.
    //Freeing must correctly restore free space.
    //If allocate() requests memory but no suitable space exists → return -1.


    //🔹 Example
    //If N = 16 bytes:
    //Memory positions: 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15


    //allocate(1) → returns 0
    //allocate(4) → next aligned is 4 → returns 4
    //allocate(8) → next aligned is 8 → if 8–15 is free, returns 8
    //free(4) → frees the 4‑byte region starting at address 4
    #endregion
    public class Allocator
    {
        private int[] memory;               // stores allocation IDs (0 = free)
        private Dictionary<int, List<int>> allocations; // ID -> list of indices

        public Allocator(int n)
        {
            memory = new int[n];
            allocations = new Dictionary<int, List<int>>();
        }

        // Allocate 'size' cells with allocation ID = 'mID'
        public int Allocate(int size, int mID)
        {
            int n = memory.Length;

            for (int start = 0; start <= n - size; start++)
            {
                bool isFree = true;

                // Check if block [start, start+size) is free
                for (int j = 0; j < size; j++)
                {
                    if (memory[start + j] != 0)
                    {
                        isFree = false;
                        break;
                    }
                }

                if (isFree)
                {
                    // Mark memory with mID
                    for (int j = 0; j < size; j++)
                    {
                        memory[start + j] = mID;
                    }

                    // Track allocated indices
                    if (!allocations.ContainsKey(mID))
                        allocations[mID] = new List<int>();

                    for (int j = 0; j < size; j++)
                    {
                        allocations[mID].Add(start + j);
                    }

                    return start;  // starting index of allocated block
                }
            }

            return -1; // no space
        }

        // Free all memory blocks allocated by mID
        public int Free(int mID)
        {
            if (!allocations.ContainsKey(mID))
                return 0;

            int freed = 0;

            foreach (int index in allocations[mID])
            {
                memory[index] = 0;
                freed++;
            }

            allocations.Remove(mID);
            return freed;
        }
    }
}
