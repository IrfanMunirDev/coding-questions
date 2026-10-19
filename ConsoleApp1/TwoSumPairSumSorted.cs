using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Pair Sum - Sorted
    Easy
    Given an array of integers sorted in ascending order and a target value, return the indexes of any pair of numbers in the array that sum to the target. The order of the indexes in the result doesn't matter. If no pair is found, return an empty array.

    Example 1:
    Input: nums = [-5, -2, 3, 4, 6], target = 7
    Output: [2, 3]
    Explanation: nums[2] + nums[3] = 3 + 4 = 7

    Example 2:
    Input: nums = [1, 1, 1], target = 2
    Output: [0, 1]
    Explanation: other valid outputs could be [1, 0], [0, 2], [2, 0], [1, 2] or [2, 1].
     
     */

    internal class TwoSumPairSumSorted
    {
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

        public int[] TwoSumDevTry2(int[] nums, int target)
        {
            Console.WriteLine("TwoSumDevTry2 called with nums: " + string.Join(", ", nums) + " and target: " + target);

            Dictionary<int, int> numDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                //we dont need to check for target - num[i] == newValue will be a  vakue that we need to search in the array                
                //trick here is that we get a compliment value and if that compelment value is in the dictionry we return compelint, and the loop index, necuase they sum up to target
                int complement = target - nums[i];
                if (numDict.ContainsKey(complement))
                {
                    return new int[] { numDict[complement], i };
                }

                //keep adding in dictionary , value , and then index
                numDict[nums[i]] = i;
            }
            return new int[] { -1, -1 }; // Return (-1, -1) if no solution is found
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Console.WriteLine("TwoSum called with nums: " + string.Join(", ", nums) + " and target: " + target);
            Dictionary<int, int> numDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {

                int complement = target - nums[i];

                if (numDict.ContainsKey(complement))
                {
                    return new int[] { numDict[complement], i };
                }
                //Console.WriteLine($"Adding {nums[i]} at index {i} to the dictionary.");
                numDict[nums[i]] = i;
            }

            return new int[] { -1, -1 }; // Return (-1, -1) if no solution is found
        }
    }
}
