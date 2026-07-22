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
     * Complete the 'permutationEquation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY p as parameter.
     */

    public static List<int> permutationEquation(List<int> p)
    {
        /* First Solution 
        List<int> result = new List<int>();
        for(int x=1; x <= p.Count; x++) {
            int firstposition = 0;
            for (int i=0; i < p.Count; i++) {
                if (p[i] == x){
                    firstposition = i+1;
                    break;
                }
            }
            int secondposition = 0;
            for (int i=0; i < p.Count; i++) {
                if(p[i] == firstposition) {
                    secondposition = i+1;
                    break;
                }
            }
            result.Add(secondposition);
        }
        return result;
        */
        /* Improved Solution */
        Dictionary<int, int> positions = new Dictionary<int, int>();
        for (int i = 0; i < p.Count; i++) {
            positions[p[i]] = i + 1;
        }
        List<int> result = new List<int>();
        for (int x = 1; x <= p.Count; x++) {
            int y = positions[positions[x]];
            result.Add(y);
        }
        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> p = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pTemp => Convert.ToInt32(pTemp)).ToList();

        List<int> result = Result.permutationEquation(p);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
