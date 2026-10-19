using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Palindrome
    {
        /*
            Is Palindrome Valid
Easy
A palindrome is a sequence of characters that reads the same forward and backward.

Given a string, determine if it's a palindrome after removing all non-alphanumeric characters. A character is alphanumeric if it's either a letter or a number.

Example 1:
Input: s = 'a dog! a panic in a pagoda.'
Output: True
Example 2:
Input: s = 'abc123'
Output: False
Constraints:
The string may include a combination of lowercase English letters, numbers, spaces, and punctuations.
         
         */

        public bool IsPalindrome(string s)
        {
            string cleanedString = s.Trim().ToLower();
            //remove all non-alphanumeric characters
            for(int i = 0; i < cleanedString.Length; i++)
            {
                if (!char.IsLetterOrDigit(cleanedString[i]))
                {
                    cleanedString = cleanedString.Remove(i, 1);
                    i--;
                }
            }
            
            // Check if the cleaned string is a palindrome
            int left = 0;
            int right = cleanedString.Length - 1;
            while (left < right)
            {
                if (cleanedString[left] != cleanedString[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }
    }
}
