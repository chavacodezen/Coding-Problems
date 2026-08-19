/* PROBLEM 1
CHUNCKING
The Medical Records Number has to be splited by an "-" based on the array.
Reversing the MRN in chunks
MRN = 8126595812
array = [2,3,4,1]
return = 12-958-1265-8
*/
static string Chunking(string mrn, int[] chunks) {
    string result = "";
    int position = mrn.Length - 1;

    for (int i = 0; i < chunks.Length; i++) {
        int size = chunks[i];

        // Si necesitamos un "-" antes del siguiente chunk
        if (result.Length > 0)
            result.Insert(0, "-");

        // Construir el chunk desde la derecha hacia la izquierda
        for (int j = 0; j < size; j++) {
            result.Insert(0, mrn[position]);
            position--;
        }
    }
    return result.ToString();
}
