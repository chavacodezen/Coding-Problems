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
     * Complete the 'appendAndDelete' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. STRING t
     *  3. INTEGER k
     */

    public static string appendAndDelete(string s, string t, int k)
    {
        /* First Solution 
        int min = Math.Min(s.Length, t.Length);
        int dif = 0;
        for (int i=0; i<min; i++) {
            if(s[i] != t[i]) {
                dif = (s.Length - i) + (t.Length - i);
                break;
            }
        }
        if(dif == 0){
            dif = (s.Length - min) + (t.Length - min);
        }
        if (dif > k)
        {
            return "No";
        }
        return "Yes";*/
        /* Improved Solution */
        int common = 0;
        while (common < s.Length && common < t.Length && s[common] == t[common])
        {
            common++;
        }
        int operations = (s.Length - common) + (t.Length - common);
        if (operations > k)
            return "No";
        if (k >= s.Length + t.Length)
            return "Yes";
        return ((k - operations) % 2 == 0) ? "Yes" : "No";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string t = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.appendAndDelete(s, t, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
