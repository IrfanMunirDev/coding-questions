using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Hash_Maps_And_Sets
{
    internal class TwoSum
    {
        /*
         Given an array of integers, return the indexes of any two numbers 
        that add up to a target. The order of the indexes in the result doesn't matter. 
        If no pair is found, return an empty array.

Example:
Input: nums = [-1, 3, 4, 2], target = 3
Output: [0, 2]
Explanation: nums[0] + nums[2] = -1 + 4 = 3

Constraints:
The same index cannot be used twice in the result.
         
         */

        public int[] TwoSumDevTry1(int[] nums, int target)
        {
            Console.WriteLine("TwoSumDevTry1 called with nums: " + string.Join(", ", nums) + " and target: " + target);
            //nested loop
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 };
        }

        public int[] TwoSumUsingDictionary(int[] nums, int target)
        {
            Console.WriteLine("TwoSumUsingDictionary called with nums: " + string.Join(", ", nums) + " and target: " + target);

            Dictionary<int, int> numDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numDict.ContainsKey(complement))
                {
                    return new int[] { numDict[complement], i };
                }
                numDict[nums[i]] = i;
            }
            return new int[] { -1, -1 };
        }
    }
}
