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
expression = 3+5-4*4
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
/* PROBLEM 3
ANAGRAMS
Rearange with the following rules:
- Characters must remain in the same case (not A to a).
- Uppercase and non-alpha must remain in the same position.
- Numbers are not allowed input.
- No characters may be added to or substract from the string.
input = "Mother-in-law"
return "Mtoher-in-law" || "Mthoer-in-law" || "Mother-an-liw"
*/
static string AnagramShuffler(string input) {
    var rng = new Random();
    var chars = input.ToCharArray();
    var indices = new List<int>();
    var letters = new List<char>();

    for (int i = 0; i < chars.Length; i++) {
        if (char.IsLower(chars[i])) {
            indices.Add(i);
            letters.Add(chars[i]);
        }
    }

    if (letters.Count < 2) return input;

    string original = new string(letters.ToArray());
    int attempts = 0;

    do {
        // Fisher-Yates shuffle inline
        for (int n = letters.Count - 1; n > 0; n--) {
            int k = rng.Next(n + 1);
            (letters[k], letters[n]) = (letters[n], letters[k]);
        }
        attempts++;
    } while (new string(letters.ToArray()) == original && attempts < 50);

    for (int i = 0; i < indices.Count; i++)
        chars[indices[i]] = letters[i];

    return new string(chars);
}
/* PROBLEM 4
LETTER HACKER
Write a function, given the number of characters as a parameter,
display all possible well ordered strings with that many characters.
Example:
"aBLy" well ordered, because of alphabet order.
"aBLe" not well ordered.
Example: If you know the password length is 2, then "ab", "cJ", "Lx", are valid passwords,
but "Aa", "vB", are not.
For reference A-Z in ASCII decimal values are 65-90, and a-z are 97-122.
*/
static List<string> LetterHacker(int length)
{
    var results = new List<string>();
    char[] current = new char[length];

    void Backtrack(int pos, int previousIndex)
    {
        if (pos == length)
        {
            results.Add(new string(current));
            return;
        }

        for (int letter = previousIndex + 1; letter < 26; letter++)
        {
            current[pos] = (char)('a' + letter);
            Backtrack(pos + 1, letter);

            current[pos] = (char)('A' + letter);
            Backtrack(pos + 1, letter);
        }
    }

    Backtrack(0, -1);
    return results;
}
