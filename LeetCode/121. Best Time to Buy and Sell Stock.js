/* PROBLEM
121. Best Time to Buy and Sell Stock
Attempted
Easy
Topics
Companies

You are given an array prices where prices[i] is the price of a given stock on the ith day.
You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

Example 2:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.

Constraints:
1 <= prices.length <= 105
0 <= prices[i] <= 104
*/
// Solution O(n^2)
var maxProfit = function(prices) {
    let profit = 0

    for(let i=0; i<prices.length-1; i++) {
        for(let j=i+1; j<prices.length; j++) {
            if(prices[j]-prices[i] > profit) profit = prices[j]-prices[i]
        }
    }

    return profit
};

// Optimized solution O(n)
var maxProfit = function(prices) {
    let profit = 0
    let min = Infinity

    for(let i=0; i<prices.length; i++) {
        if(prices[i] < min) min = prices[i]

        let currentProfit = prices[i] - min

        if(currentProfit>profit) profit = currentProfit
    }

    return profit
};
