static void Task4(ref int a, ref int b, ref int c)
{
    int tmp;
    if (a > b)
    {
        tmp = a;
        a = b;
        b = tmp;
    }
    if (b > c)
    {
        tmp = b;
        b = c;
        c = tmp;
    }
    if (a > b)
    {
        tmp = a;
        a = b;
        b = tmp;
    }
}

static int Task5(int[] seq)
{
    int max = seq.Max(), res = 0;
    for (int i = 0; i < seq.Length; i++)
    {
        if (seq[i] == max) res++;
    }
    return res - 1;
}

static double Task6(int n, double x)
{
    double s = 0;
    for (int i = 1; i <= n; i++)
    {
        if (i % 2 != 0)
        {
            if (i % 3 != 0) s += Math.Cos(i * Math.Pow(x, i));
            else s += Math.Sin(i * Math.Pow(x, i));
        }
        else
        {
            if (i % 3 != 0) s -= Math.Cos(i * Math.Pow(x, i));
            else s -= Math.Sin(i * Math.Pow(x, i));
        }
    }
    return s;
}

static int[,] Task7(int k1, int k2, int[,] arr)
{
    if (k1 > arr.GetLength(0) || k2 > arr.GetLength(0)
    || k1 < 0 || k2 < 0) return arr;
    int newRows = arr.GetLength(0) - (k2 - k1 + 1);
    int[,] newArr = new int[newRows, arr.GetLength(1)];
    int newRow = 0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        if (i < k1 || i > k2)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                newArr[newRow, j] = arr[i, j];
            }
            newRow++;
        }
    }
    return newArr;
}

static int[][] Task8(int[][] jaggedArray, int n, int k)
{
    if (k <= 0 || n <= 0) return jaggedArray;
    int originalLength = jaggedArray.Length;
    int[][] newArray = new int[originalLength + k][];
    int newIndex = 0;
    n--;
    for (int i = 0; i < n; i++)
    {
        newArray[newIndex++] = jaggedArray[i];
    }
    for (int i = 0; i < k; i++)
    {
        newArray[newIndex++] = new int[0];
    }
    for (int i = n; i < originalLength; i++)
    {
        newArray[newIndex++] = jaggedArray[i];
    }
    return newArray;
}

static double[] Task9(double[] arr)
{
    double avg = (double)arr.Sum() / arr.Length;
    int countAvg = 0;
    foreach (double elem in arr)
    {
        if (elem == avg) countAvg++;
    }
    double[] newArr = new double[arr.Length - countAvg];
    int index = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] != avg) newArr[index++] = arr[i];
    }
    return newArr;
}

static string Task10(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;
        string result = "";
        int wordIndex = 1, start = 0;
        for (int i = 0; i <= text.Length; i++)
        {
            if (i == text.Length || text[i] == ' ' || text[i] == '.' || text[i] == '!' || text[i] == '?')
            {
                int wordLength = i - start;
                if (wordLength > 0)
                {
                    string currentWord = "";
                    if (wordLength == wordIndex)
                    {
                        for (int j = i - 1; j >= start; j--)
                        {
                            currentWord += text[j];
                        }
                    }
                    else
                    {
                        currentWord = text.Substring(start, wordLength);
                    }
                    if (!string.IsNullOrEmpty(result))
                        result += " ";
                    result += currentWord;
                    wordIndex++;
                }
                if (i < text.Length && (text[i] == '.' || text[i] == '!' || text[i] == '?'))
                {
                    result += text[i];
                    wordIndex = 1;
                }
                if (i < text.Length && text[i] == ' ')
                {
                    result += " ";
                }
                start = i + 1;
            }
        }
        return result;
    }

// Console.WriteLine(Task10("В лесу родилась елка! В лесу она росла. Зимой и летом была стройная, зеленая!"));

// foreach (double elem in Task9([2, 2, 2, 3]))
// { Console.Write($"{elem} "); }

// static void PrintJaggedArray(int[][] jaggedArray)
// {
//     foreach (var row in jaggedArray)
//     {
//         Console.WriteLine(row.Length > 0 ? string.Join(", ", row) : "Пустая строка");
//     }
// }

// int[][] jaggedArray = {
//             new int[] { 1, 2, 3 },
//             new int[] { 4, 5 },
//             new int[] { 6, 7, 8, 9 }
//         };

// PrintJaggedArray(Task8(jaggedArray, 4, 2));

// static void PrintArray(int[,] array)
// {
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             Console.Write(array[i, j] + "\t");
//         }
//         Console.WriteLine();
//     }
// }

// int[,] array = {
//             { 1, 2, 3 },
//             { 4, 5, 6 },
//             { 7, 8, 9 },
//             { 10, 11, 12 }
//         };

// PrintArray(Task7(0, 1, array));

// Console.WriteLine($"Сумма = {Task6(6, 1)}");

// int[] seq = [1, 10, 2, 0, 10, 10];
// Console.WriteLine($"{Task5(seq)}");

// int a = 10, b = 4, c = 2;
// Task4(ref a, ref b, ref c);
// Console.WriteLine($"a = {a}, b = {b}, c = {c}");