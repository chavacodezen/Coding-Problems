/* PROBLEM
345. Reverse Vowels of a String
Solved
Easy
Topics
Companies

Given a string s, reverse only all the vowels in the string and return it.
The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

Example 1:
Input: s = "IceCreAm"
Output: "AceCreIm"

Explanation:
The vowels in s are ['I', 'e', 'e', 'A']. On reversing the vowels, s becomes "AceCreIm".

Example 2:
Input: s = "leetcode"
Output: "leotcede"

Constraints:
1 <= s.length <= 3 * 105
s consist of printable ASCII characters.
*/
/**
 * @param {string} s
 * @return {string}
 */
var reverseVowels = function(s) {
    const vowels = new Set('AEIOUaeiou');
    let arr = s.split('');
    let left = 0;
    let right = arr.length - 1;
    
    // While the left pointer is less than the right pointer
    while (left < right) {
        // Move left pointer to the next vowel
        if (!vowels.has(arr[left])) {
            left++;
            continue;
        }
        
        // Move right pointer to the previous vowel
        if (!vowels.has(arr[right])) {
            right--;
            continue;
        }
        
        // Swap the vowels at the left and right pointers
        [arr[left], arr[right]] = [arr[right], arr[left]];
        
        // Move both pointers towards the center
        left++;
        right--;
    }
    
    // Convert the array back to a string and return it
    return arr.join('');
};
