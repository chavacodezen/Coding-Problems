/* PROBLEM
3. Longest Substring Without Repeating Characters
Medium

Given a string s, find the length of the longest substring without duplicate characters.

Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3. Note that "bca" and "cab" are also correct answers.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Constraints:
0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var substringset = new HashSet<char>();
        int maxSubstring = 0;
        int index = 0;

        for (int i=0; i < s.Length; i++) {
            if(!substringset.Contains(s[i])) {
                substringset.Add(s[i]);
                if (substringset.Count > maxSubstring) {
                    maxSubstring = substringset.Count;
                }
            } else {
                while (substringset.Contains(s[i])) {
                    substringset.Remove(s[index]);
                    index++;
                }
                substringset.Add(s[i]);
            }
        }
        return maxSubstring;
    }
}
