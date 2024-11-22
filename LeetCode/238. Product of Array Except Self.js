/* PROBLEM
238. Product of Array Except Self
Medium
Topics
Companies
Hint

Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
You must write an algorithm that runs in O(n) time and without using the division operation.

Example 1:
Input: nums = [1,2,3,4]
Output: [24,12,8,6]

Example 2:
Input: nums = [-1,1,0,-3,3]
Output: [0,0,9,0,0]
 
Constraints:
2 <= nums.length <= 105
-30 <= nums[i] <= 30
The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 
Follow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)
*/
// Bruteforce solution - O(n^2)
var productExceptSelf = function(nums) {
    const products = []
    let product = 1

    for(let i=0; i<nums.length; i++) {
        for(let j=0; j<nums.length; j++) {
            if(j !== i) product *= nums[j]
        }
        products.push(product)
        product = 1
    }

    return products
};

// Optimized Solution - 
