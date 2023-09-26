using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Easy
{
    internal class PalindromeNumber
    {
        /*
         Given an integer x, return true if x is a 
        palindrome
        , and false otherwise.

 

        Example 1:

        Input: x = 121
        Output: true
        Explanation: 121 reads as 121 from left to right and from right to left.
        Example 2:

        Input: x = -121
        Output: false
        Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
        Example 3:

        Input: x = 10
        Output: false
        Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 

        Constraints:

        -231 <= x <= 231 - 1
         */

        public static bool Approach1(int x)
        {
            return x.ToString() == string.Join("", x.ToString().ToCharArray().Reverse().ToList());
        }
        public static bool Approach2(int x)
        {
            if (x < 0)
            {
                return false; // Negative numbers can't be palindromes
            }

            int original = x;
            int reversed = 0;

            while (x > 0)
            {
                int digit = x % 10;
                reversed = reversed * 10 + digit;
                x /= 10;
            }

            return original == reversed;

        }
    }
}
