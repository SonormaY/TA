double f(double x, double y) => x + y;
double g(double x) => x;
double h(double x, double y, double z) => z + 1;

double PrimitiveRecursiveAddition(double x, double y)
{
    if (y == 0)
        return g(x);
    else
        return h(x, y - 1, PrimitiveRecursiveAddition(x, y - 1));
}

double PrimitiveRecursiveMultiplication(double x, double y)
{
    if (y == 0)
        return 0;
    else
        return f(x, PrimitiveRecursiveMultiplication(x, y - 1));
}

void MergeSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int middle = (left + right) / 2;
        MergeSort(arr, left, middle);
        MergeSort(arr, middle + 1, right);
        Merge(arr, left, middle, right);
    }
}

void Merge(int[] arr, int left, int middle, int right)
{
    int leftSize = middle - left + 1;
    int rightSize = right - middle;

    int[] leftArr = new int[leftSize];
    int[] rightArr = new int[rightSize];

    Array.Copy(arr, left, leftArr, 0, leftSize);
    Array.Copy(arr, middle + 1, rightArr, 0, rightSize);

    int i = 0, j = 0, k = left;

    while (i < leftSize && j < rightSize)
    {
        if (leftArr[i] <= rightArr[j])
        {
            arr[k++] = leftArr[i++];
        }
        else
        {
            arr[k++] = rightArr[j++];
        }
    }

    while (i < leftSize)
    {
        arr[k++] = leftArr[i++];
    }

    while (j < rightSize)
    {
        arr[k++] = rightArr[j++];
    }
}

int RecursiveFibonacci(int n)
{
    if (n <= 1)
        return n;
    else
        return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
}

//Console.Clear();
Console.WriteLine($"Primitive Recursive Addition of 3 and 4: {PrimitiveRecursiveAddition(3, 4)}"); // 7
Console.WriteLine($"Primitive Recursive Multiplication of 3 and 4: {PrimitiveRecursiveMultiplication(3, 4)}"); // 12

Console.WriteLine("\nMerge Sort:");
Random random = new Random();
int[] arr = new int[10];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = random.Next(0, 100);
    Console.Write($"{arr[i]} ");
}
MergeSort(arr, 0, arr.Length - 1);
Console.WriteLine("\nSorted:");
foreach (int i in arr)
{
    Console.Write($"{i} ");
}
Console.WriteLine("\n");

Console.WriteLine($"Recursive Fibonacci (10): {RecursiveFibonacci(10)}"); // 55
