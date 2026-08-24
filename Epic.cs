/* PROBLEM 1
CHUNCKING
The Medical Records Number has to be splited by an "-" based on the array.
Reversing the MRN in chunks
MRN = 8126595812
array = [2,3,4,1]
return = 12-958-1265-8
*/
static string Chunking(string mrn, int[] chunks) {
    var parts = new List<string>();
    int position = mrn.Length;
    foreach (int size in chunks) {
        int start = position - size;
        parts.Add(mrn.Substring(start, position - start));
        position = start;
    }
    return string.Join("-", parts);
}
/* PROBLEM 2
SIMPLIFIED ARITHMETIC
Evaluate the expression strictly from left to right, ignoring standard operator precedence.
x = 3+5-4*4
return = 16
*/
static int Evaluate(string expression) {
    var tokens = Regex.Matches(expression, @"\d+|[+\-*/]");
    int result = int.Parse(tokens[0].Value);

    for (int i = 1; i < tokens.Count; i += 2) {
        string op = tokens[i].Value;
        int num = int.Parse(tokens[i + 1].Value);

        switch (op) {
            case "+": result += num; break;
            case "-": result -= num; break;
            case "*": result *= num; break;
            case "/": result /= num; break;
        }
    }

    return result;
}
