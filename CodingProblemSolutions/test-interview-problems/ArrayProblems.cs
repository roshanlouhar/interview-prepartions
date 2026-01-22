using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_interview_problems
{
    public class ArrayProblems
    {
        public ArrayProblems()
        {
            //int result = RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 });
            int[] result = TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3, 4, 4, 4, 4 }, 3);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // Input: nums = [1, 1, 1, 2, 2, 3], k = 2
        // Output: [1, 2]
        // Input: nums = [1], k = 1
        // Output: [1]
        // int[] nums = [0, 0, 1, 1, 1, 1, 2, 3, 3];
        // RemoveDuplicates(nums);
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> maps = new Dictionary<int, int>();
            PriorityQueue<int, int> priority = new PriorityQueue<int, int>();
            int[] result = new int[k];

            for (int i = 0; i < nums.Length; i++)
            {
                maps[nums[i]] = maps.GetValueOrDefault(nums[i], 0) + 1;
            }

            foreach (var queue in maps)
            {
                priority.Enqueue(queue.Key, queue.Value);

                if (priority.Count > k)
                {
                    priority.Dequeue();
                }
            }

            for (int i = 0; i < k; i++)
            {
                result[i] = priority.Dequeue();
            }

            return result;

            //return nums.GroupBy(num => num).OrderByDescending(num => num.Count()).Take(k).Select(c => c.Key).ToArray();
        }

        static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int unique = 1;
            int length = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1] || length < 2)
                {
                    nums[unique] = nums[i - length];
                    length = 0;
                    unique++;
                }
                else
                {
                    length++;
                }
            }

            for (int i = 0; i < nums.Length; i++)
                Console.Write(nums[i] + "  ");

            return unique;
        }

        //int[] nums = [2, 7, 11, 15];
        //TwoSum(nums, 9);
        static int[] TwoSum(int[] nums, int target)
        {
            int minus = 0;
            Dictionary<int, int> set = new Dictionary<int, int>();
            set.Add(nums[0], 0);
            for (int i = 1; i < nums.Length; i++)
            {
                minus = target - nums[i];
                var numberExist = set.ContainsKey(minus);
                if (numberExist)
                {
                    return new int[] { set[minus], i };
                }
                else
                {
                    if (!set.ContainsKey(minus))
                        set.Add(nums[i], i);
                }
            }
            return new int[] { };
        }

        //int[] nums1 = [1, 3];
        //int[] nums2 = [2, 4];
        //Console.WriteLine(FindMedianSortedArrays(nums1, nums2));
        static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergeArr = nums1.Concat(nums2).ToArray();
            Array.Sort(mergeArr);
            var mid = mergeArr.Length / 2;
            double median = 0;
            if (mergeArr.Length % 2 == 0)
            {
                median = ((double)mergeArr[mid] + mergeArr[mid - 1]) / 2;
            }
            else
            {
                median = mergeArr[mid];
            }
            return median;
        }

        static void BinarySearch(int[] nums, int target)
        {
            int result = Array.BinarySearch(nums, target);

            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    Console.WriteLine($"Target found at index: {mid}");
                    return;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            Console.WriteLine("Target not found in the array.");
        }

    }
}
