/* PROBLEM
9. Palindrome Number
Easy
Given an integer x, return true if x is a palindrome, and false otherwise.

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

Follow up: Could you solve it without converting the integer to a string?
*/
public class Solution {
    public bool IsPalindrome(int x) {
        // First version
        /*
        string xs = x.ToString();
        string reverse = string.Empty;

        for (int i=xs.Length-1; i>=0; i--) {
            reverse += xs[i];
        }

        if (reverse == xs) {
            return true;
        } else {
            return false;
        }
        */
        // Improved version
        if(x<0)
            return false;

        int original = x;
        int reverse = 0;
        int last = 0;
        
        while (x > 0) {
            last = x % 10;
            reverse = (reverse*10) + last;
            x /= 10;
        }

        if (reverse == original) {
            return true;
        } else {
            return false;
        }
    }
}
