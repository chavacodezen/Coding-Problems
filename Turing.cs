/*
Minimum Number of Chairs Required
Difficulty: Medium

Problem Statement
A company wants to minimize the number of chairs needed in a shared office space. Employees arrive and leave at different times throughout the day, and any employee can reuse a chair that has been vacated by another employee, as long as it is free at that moment.

Given the arrival and departure times of n employees for a single day, determine the minimum number of chairs required so that every employee has a chair available at all times while they are present.

A chair is considered occupied during the half-open interval [arrival, departure) — that is, if one employee leaves at exactly the same time another arrives, they can share the same chair (no overlap).

Input Format
timestamps: a 2D array of integers, where timestamps[i] = [arrival_i, departure_i] represents the arrival and departure time of the i-th employee, given in 24-hour format (e.g., 900 represents 9:00 AM, 1230 represents 12:30 PM).

Output Format
Return a single integer: the minimum number of chairs required to accommodate all employees.

Example
Input: timestamps = [[900, 1230], [1000, 1300], [1400, 1900], [2000, 2100]]
Output: 2
Explanation:
- Employee 1 (900-1230) and Employee 2 (1000-1300) overlap between 1000 and 1230, so they need 2 separate chairs during that window.
- Employee 3 (1400-1900) starts after both Employee 1 and Employee 2 have left, so they can reuse a chair.
- Employee 4 (2000-2100) also starts after Employee 3 has left.
- At no point are more than 2 employees present simultaneously, so the answer is 2.
*/

public int MinChairs(int[][] timestamps)
{
    int n = timestamps.Length;
    int[] starts = new int[n];
    int[] ends = new int[n];

    for (int i = 0; i < n; i++)
    {
        starts[i] = timestamps[i][0];
        ends[i] = timestamps[i][1];
    }

    Array.Sort(starts);
    Array.Sort(ends);

    int chairs = 0, maxChairs = 0;
    int s = 0, e = 0;

    while (s < n)
    {
        if (starts[s] < ends[e])
        {
            chairs++;
            maxChairs = Math.Max(maxChairs, chairs);
            s++;
        }
        else
        {
            chairs--;
            e++;
        }
    }

    return maxChairs;
}
