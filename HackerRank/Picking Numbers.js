/* PROBLEM
Given an array of integers, find the longest subarray where the absolute difference between any two elements is less than or equal to .

Example
There are two subarrays meeting the criterion:  and . The maximum length subarray has  elements.

Function Description
Complete the pickingNumbers function in the editor below.

pickingNumbers has the following parameter(s):
int a[n]: an array of integers
Returns
int: the length of the longest subarray that meets the criterion
Input Format
The first line contains a single integer , the size of the array .
The second line contains  space-separated integers, each an .

Constraints
The answer will be .
Sample Input 0
6
4 6 5 3 3 1
Sample Output 0
3
Explanation 0
We choose the following multiset of integers from the array: . Each pair in the multiset has an absolute difference  (i.e.,  and ), so we print the number of chosen integers, , as our answer.
Sample Input 1
6
1 2 2 3 1 2
Sample Output 1
5
Explanation 1
We choose the following multiset of integers from the array: . Each pair in the multiset has an absolute difference  (i.e., , , and ), so we print the number of chosen integers, , as our answer.
*/

'use strict';

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', function(inputStdin) {
    inputString += inputStdin;
});

process.stdin.on('end', function() {
    inputString = inputString.split('\n');

    main();
});

function readLine() {
    return inputString[currentLine++];
}

/*
 * Complete the 'pickingNumbers' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts INTEGER_ARRAY a as parameter.
 */

function pickingNumbers(a) {
    // Write your code here
    const frequency = {};

    // Build the frequency dictionary
    for (let i = 0; i < a.length; i++) {
        const number = a[i];
        if (frequency[number]) {
            frequency[number]++;
        } else {
            frequency[number] = 1;
        }
    }

    let maxLength = 0;

    // Check pairs (number, number + 1)
    for (let number in frequency) {
        number = parseInt(number); // Convert the key back to an integer
        let currentLength = frequency[number];

        if (frequency[number + 1]) {
            currentLength += frequency[number + 1];
        }

        maxLength = Math.max(maxLength, currentLength);
    }

    return maxLength;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const n = parseInt(readLine().trim(), 10);

    const a = readLine().replace(/\s+$/g, '').split(' ').map(aTemp => parseInt(aTemp, 10));

    const result = pickingNumbers(a);

    ws.write(result + '\n');

    ws.end();
}
