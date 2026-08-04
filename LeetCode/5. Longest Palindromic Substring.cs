/* PROBLEM
5. Longest Palindromic Substring
Medium
Given a string s, return the longest palindromic substring in s.

Example 1:
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.

Example 2:
Input: s = "cbbd"
Output: "bb"

Constraints:
1 <= s.length <= 1000
s consist of only digits and English letters.
*/
public class Solution {
    public string LongestPalindrome(string s) {
        string palindrome = String.Empty;
        string candidate = String.Empty;

        for(int i=0; i<s.Length; i++) {
            candidate = Expand(s, i, i);
            if(candidate.Length > palindrome.Length) {
                palindrome = candidate;
            }

            candidate = Expand(s, i, i + 1);
            if(candidate.Length > palindrome.Length) {
                palindrome = candidate;
            }
        }

        return palindrome;
    }

    public string Expand(string s, int left, int right) {
        int start = 0;
        int maxLength = 0;

        while(left >= 0 && right < s.Length && s[left] == s[right]) {
            int length = right - left + 1;
            if(length > maxLength) {
                start = left;
                maxLength = length;
            }
            left--;
            right++;
        }

        return s.Substring(start, maxLength);
    }
}
