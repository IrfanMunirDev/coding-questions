using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Timers;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal class ShiftZerosToTheEnd
    {
        /*
         Shift Zeros to the End
        Easy
        Given an array of integers, modify the array in place to move all zeros to the end while maintaining the relative order of non-zero elements.

        Example:
        Input: nums = [0, 1, 0, 3, 2]
        Output: [1, 3, 2, 0, 0]
         
         */

        public int[] ShiftZerosToEndTry1(int[] arr)
        {
           //move all zero to end of array, so we can keep swapping and if zero hit we add it to swap array and keep searning non zero, and if non zero hit we do a swap, and if ned hit we stop
           
            Console.WriteLine("ShiftZerosToEndTry1 called with arr: " + string.Join(", ", arr));

            for (int i=0; i<arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    int firstZeroIndex = i;
                    int firstNonZeroIndex = i;

                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] != 0)
                        {
                            firstNonZeroIndex = j;
                            break;
                        }
                    }

                    if (firstZeroIndex != firstNonZeroIndex)
                    {
                        int temp = arr[firstZeroIndex];
                        arr[firstZeroIndex] = arr[firstNonZeroIndex];
                        arr[firstNonZeroIndex] = temp;
                    }
                }

            }

            return arr;
        }
        /*
        Your approach works for basic examples like `[0, 1, 0, 3, 2]`, 
        but it has a few efficiency and design issues that make it suboptimal.

Here is a breakdown of why your current implementation can be improved, followed by an optimal solution.

---

### Critique of `ShiftZerosToEndTry1`

1. **Time Complexity ($O(n^2)$):**
Whenever your outer loop encounters a `0`, your inner loop scans ahead 
        to find the next non - zero element.In the worst-case scenario(such as an array filled with alternating zeros and numbers, or many leading zeros), this nested scanning results in quadratic time complexity, which will perform poorly on large arrays.
2. **Implicit Self-Swaps:**
When no non - zero elements are left after a zero, `firstNonZeroIndex` defaults to `i`, 
        causing the element to swap with itself.While this prevents crashes, it makes the logic harder to follow and maintain.
3. **Goal:**
This problem can be solved efficiently in a single pass or two clean passes with **$O(n)$ time complexity** and**$O(1)$ space complexity**.

---

### The Optimal Solution ($O(n)$ Time)

The standard and most efficient way 
        to solve this is using a ** two-pointer approach** (or a write-pointer strategy):

1. Iterate through the array and copy every non-zero element to the front of the array sequentially.
2. Keep track of the next available position to place a non-zero element (let's call it `insertPos`).
3. Once all non-zero elements are placed, fill the rest of the array from `insertPos` to the end with zeros.

Here is how you can write it cleanly in C#:

```csharp*/
public int[] ShiftZerosToEndOptimal(int[] arr)
    {
        if (arr == null || arr.Length <= 1) return arr;

        int insertPos = 0;

        // Step 1: Shift all non-zero elements to the front
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                arr[insertPos] = arr[i];
                insertPos++;
            }
        }

        // Step 2: Fill the remaining positions with zeros
        while (insertPos < arr.Length)
        {
            arr[insertPos] = 0;
            insertPos++;
        }

        return arr;
    }


        /*
        ### Alternative: Single-Pass Swap Approach

        If the problem strictly requires minimizing writes 
        or doing it in a single pass via swaps(similar to partition logic), 
        you can use a single pointer to track where the next non-zero element should be swapped:

        ```csharp
        */

        public int[] ShiftZerosToEndSinglePass(int[] arr)
        {
            //<this apprach is easy and udnerstandable >
            int nonZeroIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    // Swap current non-zero element with the element at nonZeroIndex
                    int temp = arr[nonZeroIndex];
                    arr[nonZeroIndex] = arr[i];
                    arr[i] = temp;

                    nonZeroIndex++;
                }
            }

            return arr;
        }

//```

//Both of these alternatives run in **$O(n)$ time**
//and use**$O(1)$ extra space**, making them much more scalable for coding interviews and production code!

        public static void ShiftZerosToEndOrderOfN(int[] arr)
        {
            int n = arr.Length;
            int count = 0; // Count of non-zero elements
            // Traverse the array. If element encountered is non-zero, then
            // replace the element at index 'count' with this element
            for (int i = 0; i < n; i++)
            {
                if (arr[i] != 0)
                {
                    arr[count++] = arr[i]; // here count is incremented
                }
            }
            // Now all non-zero elements have been shifted to front and 'count' is
            // set as index of first 0. Make all elements 0 from count to end.
            while (count < n)
            {
                arr[count++] = 0;
            }
        }
    }
}
