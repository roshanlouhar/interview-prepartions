using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_interview_problems
{
    public class SymmetricTreeProblems
    {
        public SymmetricTreeProblems()
        {
            var result = SymmetricTreeUsingQueues(new string[] { "4", "3", "4" });
        }

        //var Input = new string[] {"4", "3", "4"};
        //var Input2 = new string[] {"10", "2", "2", "#", "1", "1", "#"};
        //Console.WriteLine(SymmetricTree(Input2));
        public static string SymmetricTreeUsingQueues(string[] strArr)
        {
            // Empty tree is symmetric
            if (strArr.Length == 0)
                return "true";

            // Queue stores index pairs to compare
            Queue<(int, int)> queue = new Queue<(int, int)>();

            // Start with left and right of root
            queue.Enqueue((1, 2));

            while (queue.Count > 0)
            {
                var (i, j) = queue.Dequeue();

                // Both out of bounds → symmetric so far
                if (i >= strArr.Length && j >= strArr.Length)
                    continue;

                // Only one out of bounds → not symmetric
                if (i >= strArr.Length || j >= strArr.Length)
                    return "false";

                // Values must match
                if (strArr[i] != strArr[j])
                    return "false";

                // If not null, enqueue mirrored children
                if (strArr[i] != "#")
                {
                    queue.Enqueue((2 * i + 1, 2 * j + 2)); // left.left vs right.right
                    queue.Enqueue((2 * i + 2, 2 * j + 1)); // left.right vs right.left
                }
            }

            return "true";
        }

        // var Input = new string[] {"4", "3", "4"};
        // var Input2 = new string[] {"10", "2", "2", "#", "1", "1", "#"};
        // Console.WriteLine(SymmetricTreeIterative (Input2));
        public static string SymmetricTreeIterative(string[] strArr)
        {
            if (strArr.Length == 0)
                return "true";

            // Queue holds index pairs that should mirror each other
            Queue<(int, int)> queue = new Queue<(int, int)>();

            // Start with left and right children of the root
            queue.Enqueue((1, 2));

            while (queue.Count > 0)
            {
                var (i, j) = queue.Dequeue();

                // Both out of bounds → symmetric at this branch
                if (i >= strArr.Length && j >= strArr.Length)
                    continue;

                // One out of bounds → not symmetric
                if (i >= strArr.Length || j >= strArr.Length)
                    return "false";

                // Values must match
                if (strArr[i] != strArr[j])
                    return "false";

                // If not NULL (#), enqueue mirrored children
                if (strArr[i] != "#")
                {
                    // Left child of left ↔ Right child of right
                    queue.Enqueue((2 * i + 1, 2 * j + 2));

                    // Right child of left ↔ Left child of right
                    queue.Enqueue((2 * i + 2, 2 * j + 1));
                }
            }

            return "true";
        }

        //var Input = new string[] {"4", "3", "4"};
        //var Input2 = new string[] {"10", "2", "2", "#", "1", "1", "#"};
        //Console.WriteLine(SymmetricTreeRecursion(Input2));
        public static string SymmetricTreeRecursion(string[] strArr)
        {
            if (strArr.Length == 0)
                return "true";

            return IsMirror(strArr, 1, 2) ? "true" : "false";
        }
        static bool IsMirror(string[] arr, int i, int j)
        {
            // Both out of bounds → symmetric
            if (i >= arr.Length && j >= arr.Length)
                return true;

            // One out of bounds → not symmetric
            if (i >= arr.Length || j >= arr.Length)
                return false;

            // Values differ → not symmetric
            if (arr[i] != arr[j])
                return false;

            // If both are NULL, stop deeper comparison
            if (arr[i] == "#")
                return true;

            // Mirror recursion
            return IsMirror(arr, 2 * i + 1, 2 * j + 2)
                && IsMirror(arr, 2 * i + 2, 2 * j + 1);
        }
    }
}
