using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Easy
{
    internal class TwoSum
    {
        /*
         Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

        You may assume that each input would have exactly one solution, and you may not use the same element twice.

        You can return the answer in any order.

 

        Example 1:

        Input: nums = [2,7,11,15], target = 9
        Output: [0,1]
        Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
        Example 2:

        Input: nums = [3,2,4], target = 6
        Output: [1,2]
        Example 3:

        Input: nums = [3,3], target = 6
        Output: [0,1]
 

        Constraints:

        2 <= nums.length <= 104
        -109 <= nums[i] <= 109
        -109 <= target <= 109
        Only one valid answer exists.

        Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
 
         */


        public static int[] TwoSum1(int[] nums, int target)
        {
            Dictionary<int, int> dictionary = nums.Select((num, index) => new { Key = index, Value = num })
                                           .ToDictionary(item => item.Key, item => item.Value);
            Dictionary<int, int> indices = new Dictionary<int, int>();


            //var skipList = dictionary.Where(x => x.Value <= target);
            foreach (var currentNum in dictionary)
            {

                if (indices.Any() && indices.Values.Sum() == target)
                {
                    break;
                }
                var subList = dictionary.Where(x => x.Key > currentNum.Key).ToList();
                foreach (var subItems in subList)
                {
                    if (currentNum.Value + subItems.Value == target)
                    {
                        indices.Add(currentNum.Key, currentNum.Value);
                        indices.Add(subItems.Key, subItems.Value);
                        break;
                    }
                }
            }
            // Console.WriteLine($" Data  {string.Join(",", indices.Keys)}");
            return indices.Keys.ToArray();
        }
        public static int[] Approach2(int[] nums, int target)
        {
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numToIndex.ContainsKey(complement))
                {
                    // We found a pair that adds up to the target
                    return new int[] { numToIndex[complement], i };
                }

                // Store the current number and its index in the dictionary
                if (!numToIndex.ContainsKey(nums[i]))
                {
                    numToIndex[nums[i]] = i;
                }
            }
            // Console.WriteLine($" Data  {string.Join(",", indices.Keys)}");
            return new int[] { };
        }
        public static int[] Approach3(int[] nums, int target)
        {
            HashSet<int> numSet = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numSet.Contains(complement))
                {
                    // We found a pair that adds up to the target
                    return new int[] { numSet.ToList().IndexOf(complement), i };
                }

                // Add the current number to the set
                numSet.Add(nums[i]);
            }

            // If no solution is found, return an empty array
            return new int[] { };
        }
    }
}
