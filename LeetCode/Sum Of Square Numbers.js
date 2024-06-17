/* PROBLEM
633. Sum of Square Numbers
Attempted
Medium
Topics
Companies
Given a non-negative integer c, decide whether there're two integers a and b such that a2 + b2 = c.

Example 1:
Input: c = 5
Output: true
Explanation: 1 * 1 + 2 * 2 = 5
Example 2:

Input: c = 3
Output: false
 
Constraints:
0 <= c <= 231 - 1
*/

/**
 * @param {number} c
 * @return {boolean}
 */
var judgeSquareSum = function (c) {
    // O(n^2)
    for (let a = 0; a*a <= c; a++) {
        for (let b = 0; b*b <= c; b++) {
            if (a*a + b*b == c) return true;
        }
    }
    return false;

    // O(n)
    for (let a = 0; a * a <= c; a++) {
        let b = Math.sqrt(c - a*a);
        if (b*b == c - a*a) return true;
    }
    return false;

    // O(n)
    let a = 0;
    let b = Math.floor(Math.sqrt(c));
    while (a <= b) {
      let res = a * a + b * b;
      if (res == c) return true;
      else if (res < c) a++;
      else b--;
    }

    return false;
};