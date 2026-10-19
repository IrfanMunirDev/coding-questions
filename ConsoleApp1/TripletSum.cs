using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class TripletSumToZero
    {
        /*
            Triplet Sum
            Medium
            Given an array of integers, return all triplets [a, b, c] such that a + b + c = 0 . 
            The solution must not contain duplicate triplets (e.g., [1, 2, 3] and [2, 3, 1] are considered duplicates). If no such triplets are found, return an empty array.

            Each triplet can be arranged in any order, and the output can be returned in any order.

            Example:
            Input: nums = [0, -1, 2, -3, 1]
            Output: [[-3, 1, 2], [-1, 0, 1]]
         
         */

        public List<Numbers> TripletSum(int[] numbers)
        {
            List<Numbers> triplets = new List<Numbers>();

           for(int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 0)
                        {
                            if(!triplets.Exists(t => (t.x1 == numbers[i] && t.x2 == numbers[j] && t.x3 == numbers[k]) ||
                                                (t.x1 == numbers[i] && t.x2 == numbers[k] && t.x3 == numbers[j]) ||
                                                (t.x1 == numbers[j] && t.x2 == numbers[i] && t.x3 == numbers[k]) ||
                                                (t.x1 == numbers[j] && t.x2 == numbers[k] && t.x3 == numbers[i]) ||
                                                (t.x1 == numbers[k] && t.x2 == numbers[i] && t.x3 == numbers[j]) ||
                                                (t.x1 == numbers[k] && t.x2 == numbers[j] && t.x3 == numbers[i])))
                            {
                                triplets.Add(new Numbers { x1 = numbers[i], x2 = numbers[j], x3 = numbers[k] });
                            }
                        }
                    }
                }
            }
            return triplets;
        }

        public List<Numbers> TripletSumDevTry2(int[] numbers)
        {
            List<Numbers> triplets = new List<Numbers>();

            
            
            
            return triplets;
        }

        public List<Numbers> TripletSumDevTry3(int[] numbers)
        {
            //its generate by github copilot I doidnt write it
            List<Numbers> triplets = new List<Numbers>();
            Array.Sort(numbers);
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (i > 0 && numbers[i] == numbers[i - 1]) continue;
                int left = i + 1;
                int right = numbers.Length - 1;
                while (left < right)
                {
                    int sum = numbers[i] + numbers[left] + numbers[right];
                    if (sum == 0)
                    {
                        triplets.Add(new Numbers { x1 = numbers[i], x2 = numbers[left], x3 = numbers[right] });
                        while (left < right && numbers[left] == numbers[left + 1]) left++;
                        while (left < right && numbers[right] == numbers[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }
            return triplets;
        }

        public record Numbers
        {
           public int x1, x2, x3;
        }
    }
}
