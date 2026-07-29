/* PROBLEM
4. Median of Two Sorted Arrays
Solved
Hard
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
The overall run time complexity should be O(log (m+n)).

Example 1:
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 
Constraints:
nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
*/
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var nums = new List<int>();
        double median = 0;

        nums.AddRange(nums1);
        nums.AddRange(nums2);
        nums.Sort();

        int medio = nums.Count / 2;

        if (nums.Count % 2 == 0) {
            median = (nums[medio - 1] + nums[medio]) / 2.0;
        } else {
            median = nums[medio];
        }

        return median;
    }
}
