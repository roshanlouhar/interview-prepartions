using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_interview_problems
{
    public class _2dArrayProblems
    {
        public _2dArrayProblems()
        {
            Console.WriteLine("Running 2D Array Problems...");
            Run();
            Console.WriteLine("Finished 2D Array Problems.");
        }
        public void Run()
        {
            // merge intervals which are overlapping
            int[][] matrix = new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            var result = Merge(matrix);

            // Example operation: Print the matrix
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    Console.Write(result[i][j] + " ");
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }

        public int[][] Merge(int[][] intervals)
        {

            if (intervals.Length <= 1) { return intervals; }

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> result = new List<int[]>();

            result.Add(intervals[0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                int[] interval = intervals[i];

                // Case 1: Interval range is unique and needs to be added to result
                if (result.Last()[1] < interval[0])
                { // Current interval's start i
                    result.Add(interval);
                }
                else
                { // Case 2: Latest interval range in result needs to be merged
                    result.Last()[1] = Math.Max(result.Last()[1], interval[1]);
                }
            }

            return result.ToArray();
        }
    }
}
