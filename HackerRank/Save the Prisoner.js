/* PROBLEM
A jail has a number of prisoners and a number of treats to pass out to them. Their jailer decides the fairest way to divide the treats is to seat the prisoners around a circular table in sequentially numbered chairs. A chair number will be drawn from a hat. Beginning with the prisoner in that chair, one candy will be handed to each prisoner sequentially around the table until all have been distributed.
The jailer is playing a little joke, though. The last piece of candy looks like all the others, but it tastes awful. Determine the chair number occupied by the prisoner who will receive that candy.

Example
There are  prisoners,  pieces of candy and distribution starts at chair . The prisoners arrange themselves in seats numbered  to . Prisoners receive candy at positions . The prisoner to be warned sits in chair number .

Function Description
Complete the saveThePrisoner function in the editor below. It should return an integer representing the chair number of the prisoner to warn.

saveThePrisoner has the following parameter(s):
int n: the number of prisoners
int m: the number of sweets
int s: the chair number to begin passing out sweets from

Returns
int: the chair number of the prisoner to warn

Input Format
The first line contains an integer, , the number of test cases.
The next  lines each contain  space-separated integers:
: the number of prisoners
: the number of sweets
: the chair number to start passing out treats at

Constraints

Sample Input 0
2
5 2 1
5 2 2

Sample Output 0
2
3

Explanation 0
In the first query, there are  prisoners and  sweets. Distribution starts at seat number . Prisoners in seats numbered  and  get sweets. Warn prisoner .
In the second query, distribution starts at seat  so prisoners in seats  and  get sweets. Warn prisoner .
Sample Input 1
2
7 19 2
3 7 3

Sample Output 1
6
3

Explanation 1
In the first test case, there are  prisoners,  sweets and they are passed out starting at chair . The candies go all around twice and there are  more candies passed to each prisoner from seat  to seat .
In the second test case, there are  prisoners,  candies and they are passed out starting at seat . They go around twice, and there is one more to pass out to the prisoner at seat .
*/

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'saveThePrisoner' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER m
     *  3. INTEGER s
     */

    public static int saveThePrisoner(int n, int m, int s)
    {
        int chair=s;
        for(int i=1; i<m; i++) {
            chair++;
            if(chair>n) chair=1;
        }
        return chair;
        
        // Improved code
        int lastPosition = (s - 1 + m) % n;
        if (lastPosition == 0)
        {
            lastPosition = n;
        }
        return lastPosition;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int s = Convert.ToInt32(firstMultipleInput[2]);

            int result = Result.saveThePrisoner(n, m, s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
