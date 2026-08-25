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
static List<string> LetterHacker(int length) {
    var results = new List<string>();
    var letterIndex = new int[length];   // 0-25, position in alphabet
    var isUpper = new bool[length];      // case flag per position
    int pos = 0;
    letterIndex[0] = -1;

    while (pos >= 0) {
        if (pos == length) {
            var sb = new StringBuilder();
            for (int i = 0; i < length; i++)
                sb.Append((char)((isUpper[i] ? 'A' : 'a') + letterIndex[i]));
            results.Add(sb.ToString());
            pos--;
            continue;
        }

        int minAllowed = pos == 0 ? 0 : letterIndex[pos - 1] + 1;
        if (letterIndex[pos] < minAllowed) letterIndex[pos] = minAllowed;

        if (!isUpper[pos] && letterIndex[pos] <= 25) {
            isUpper[pos] = true; // try lowercase first, then uppercase before advancing
            pos++;
            if (pos < length) letterIndex[pos] = -1;
            continue;
        }

        if (isUpper[pos] && letterIndex[pos] <= 25) {
            letterIndex[pos]++;
            isUpper[pos] = false;
            if (25 - letterIndex[pos] + 1 < length - pos) {
                pos--;
                continue;
            }
            pos++;
            if (pos < length) letterIndex[pos] = -1;
            continue;
        }

        pos--;
    }

    return results;
}
