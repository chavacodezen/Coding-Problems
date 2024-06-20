/* PROBLEM
There is a string, , of lowercase English letters that is repeated infinitely many times. Given an integer, , find and print the number of letter a's in the first  letters of the infinite string.

Example
The substring we consider is , the first  characters of the infinite string. There are  occurrences of a in the substring.
Function Description
Complete the repeatedString function in the editor below.
repeatedString has the following parameter(s):
s: a string to repeat
n: the number of characters to consider
Returns
int: the frequency of a in the substring
Input Format
The first line contains a single string, .
The second line contains an integer, .

Constraints
For  of the test cases, .
Sample Input
Sample Input 0
aba
10
Sample Output 0
7
Explanation 0
The first  letters of the infinite string are abaabaabaa. Because there are  a's, we return .
Sample Input 1
a
1000000000000
Sample Output 1
1000000000000
Explanation 1
Because all of the first  letters of the infinite string are a, we return .
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
 * Complete the 'repeatedString' function below.
 *
 * The function is expected to return a LONG_INTEGER.
 * The function accepts following parameters:
 *  1. STRING s
 *  2. LONG_INTEGER n
 */

function repeatedString(s, n) {
    // Write your code here
    if(s.length == 1) {
        return n;
    }
    
    let newlists = [];
    let turns = 0;
    for(let i=0; i<n; i++) {
        newlists.push(s[turns]);
        if(turns<s.length-1) {
            turns++;
        } else {
            turns=0;
        }
    }
    
    let str = newlists.join('');
    const charCount = new Map();
    for (let char of str) {
        charCount.set(char, (charCount.get(char) || 0) + 1);
    }

    let maxChar = '';
    let maxCount = 0;
    for (let [char, count] of charCount) {
        if (count > maxCount) {
            maxChar = char;
            maxCount = count;
        }
    }

    return maxCount;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const s = readLine();

    const n = parseInt(readLine().trim(), 10);

    const result = repeatedString(s, n);

    ws.write(result + '\n');

    ws.end();
}
