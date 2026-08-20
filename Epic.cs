/* PROBLEM 1
CHUNCKING
The Medical Records Number has to be splited by an "-" based on the array.
Reversing the MRN in chunks
MRN = 8126595812
array = [2,3,4,1]
return = 12-958-1265-8
*/
static string Chunking(string mrn, int[] chunks)
{
    var parts = new List<string>();
    int position = mrn.Length;
    foreach (int size in chunks)
    {
        int start = position - size;
        parts.Add(mrn.Substring(start, position - start));
        position = start;
    }
    return string.Join("-", parts);
}
