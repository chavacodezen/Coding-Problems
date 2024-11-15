/* PROBLEM
605. Can Place Flowers
Solved
Easy
Topics
Companies

You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.
Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

Example 1:
Input: flowerbed = [1,0,0,0,1], n = 1
Output: true

Example 2:
Input: flowerbed = [1,0,0,0,1], n = 2
Output: false
 
Constraints:
1 <= flowerbed.length <= 2 * 104
flowerbed[i] is 0 or 1.
There are no two adjacent flowers in flowerbed.
0 <= n <= flowerbed.length
*/
/**
 * @param {number[]} flowerbed
 * @param {number} n
 * @return {boolean}
 */
var canPlaceFlowers = function(flowerbed, n) {
    if(flowerbed.length == 1) {
        if(flowerbed[0]==0){
            return true
        } else {
            return (n==0) ? true : false
        }
    }

    if (flowerbed[0] == 0 && flowerbed[1] == 0) {
        n--;
        flowerbed[0] = 1;
    }

    for (let i = 1; i < flowerbed.length - 1; i++) {
        if (flowerbed[i] == 0 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0) {
            flowerbed[i] = 1; 
            n--;
        }
    }

    if (flowerbed[flowerbed.length - 1] == 0 && flowerbed[flowerbed.length - 2] == 0) {
        n--;
    }

    return n <= 0;
};

// Updated solution
var canPlaceFlowers = function(flowerbed, n) {
    // First solve if array have only 1 value
    if(flowerbed.length==1) {
        if(flowerbed[0]==0 && n==1) return true
        if(flowerbed[0]==1 && n==0) return true
    }

    // Put a plant on the first index if available
    if(flowerbed[0]==0 && flowerbed[1]==0) {
        flowerbed[0]=1
        n--
    }

    // Put a plant on the last index if available
    if(flowerbed[flowerbed.length-1]==0 && flowerbed[flowerbed.length-2]==0) {
        flowerbed[flowerbed.length-1]=1
        n--
    }

    // Go through the array and check for spaces
    for(let i=1; i<flowerbed.length-1; i++) {
        if(flowerbed[i-1]==0 && flowerbed[i]==0 && flowerbed[i+1]==0) {
            flowerbed[i]=1
            n--
        }
    }

    // If everything went good n value should go to 0
    // Meaning we have planted all the required
    return (n<=0) ? true : false
};
