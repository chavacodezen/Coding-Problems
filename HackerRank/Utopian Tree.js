/* PROBLEM
The Utopian Tree goes through 2 cycles of growth every year. Each spring, it doubles in height. Each summer, its height increases by 1 meter.
A Utopian Tree sapling with a height of 1 meter is planted at the onset of spring. How tall will the tree be after  growth cycles?
For example, if the number of growth cycles is , the calculations are as follows:
Period  Height
0          1
1          2
2          3
3          6
4          7
5          14

Function Description
Complete the utopianTree function in the editor below.
utopianTree has the following parameter(s):
int n: the number of growth cycles to simulate

Returns
int: the height of the tree after the given number of cycles

Input Format
The first line contains an integer, , the number of test cases.
subsequent lines each contain an integer, , the number of cycles for that test case.
Constraints
Sample Input
3
0
1
4
Sample Output
1
2
7
Explanation
There are 3 test cases.
In the first case (), the initial height () of the tree remains unchanged.
In the second case (), the tree doubles in height and is  meters tall after the spring cycle.
In the third case (), the tree doubles its height in spring (, ), then grows a meter in summer (, ), then doubles after the next spring (, ), and grows another meter after summer (, ). Thus, at the end of 4 cycles, its height is  meters.
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
     * Complete the 'utopianTree' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int utopianTree(int n)
    {
        if(n==0) return 1;
        
        int h=1;
        for(int i=1; i<=n; i++) {
            if(i%2 != 0) {
                h=h*2;
            } else {
                h++;
            }
        }
        return h;
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.utopianTree(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
