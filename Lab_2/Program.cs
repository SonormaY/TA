// Function to print an array with a visual separator
void PrintArray(int[] array)
{
    // Calculate the maximum number of digits in the array
    int maxDigits = (int)Math.Floor(Math.Log10(array.Max()) + 1);

    // Print a horizontal line based on the array size and maximum digits
    for (int i = 0; i < (1 + maxDigits) * array.Length + 3; i++)
    {
        Console.Write("-");
    }
    Console.Write("\n| ");

    // Print the elements of the array separated by spaces
    foreach (var item in array)
    {
        Console.Write(item + " ");
    }
    Console.Write("|\n");

    // Print another horizontal line
    for (int i = 0; i < (1 + maxDigits) * array.Length + 3; i++)
    {
        Console.Write("-");
    }
    Console.Write("\n");
}

// Function to generate an array of random integers within a specified range
int[] GenerateArray(int size, int min, int max)
{
    int[] array = new int[size];
    Random rand = new Random();

    for (int i = 0; i < size; i++)
    {
        array[i] = rand.Next(min, max);
    }

    return array;
}

// Function to get the value of a specific digit in a number
int GetDigitValue(int number, int digit)
{
    return (number / (int)Math.Pow(10, digit - 1)) % 10;
}

// Function to insert a value into a binary search tree
TreeNode Insert(TreeNode root, int value)
{
    if (root == null)
    {
        return new TreeNode(value);
    }

    if (value < root.Value)
    {
        root.Left = Insert(root.Left, value);
    }
    else
    {
        root.Right = Insert(root.Right, value);
    }

    return root;
}

// Function to perform in-order traversal of a binary search tree
void InOrderTraversal(TreeNode root, List<int> sortedList)
{
    if (root != null)
    {
        InOrderTraversal(root.Left, sortedList);
        sortedList.Add(root.Value);
        InOrderTraversal(root.Right, sortedList);
    }
}

// Function to perform Decision Tree Sort on a list of integers
List<int> DecisionTreeSort(List<int> unsortedList)
{
    TreeNode root = null;

    // Build a binary search tree from the unsorted list
    foreach (int value in unsortedList)
    {
        root = Insert(root, value);
    }

    // Perform in-order traversal to get the sorted list
    List<int> sortedList = new List<int>();
    InOrderTraversal(root, sortedList);

    return sortedList;
}

// Function to perform linear time sorting using Decision Tree Sort
void LinearTimeSort(int[] array)
{
    List<int> list = new List<int>(array);

    // Use Decision Tree Sort on the list and update the original array
    List<int> sortedList = DecisionTreeSort(list);
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = sortedList[i];
    }
}

// Function to perform Counting Sort on an array of integers
void CountingSort(int[] array)
{
    int max = array.Max();
    int[] count = new int[max + 1];

    // Count occurrences of each element in the array
    for (int i = 0; i < array.Length; i++)
    {
        count[array[i]]++;
    }

    int k = 0;

    // Reconstruct the sorted array based on the count
    for (int i = 0; i < count.Length; i++)
    {
        for (int j = 0; j < count[i]; j++)
        {
            array[k++] = i;
        }
    }
}

// Function to perform Counting Sort by a specific digit in each number
void CountingSortByDigit(int[] array, int digit)
{
    int n = array.Length;
    int[] output = new int[n];
    int[] count = new int[10]; // 0 to 9 digits

    // Count occurrences of each digit in the specified place
    for (int i = 0; i < n; i++)
    {
        int digitValue = GetDigitValue(array[i], digit);
        count[digitValue]++;
    }

    // Adjust the count to represent the positions in the output array
    for (int i = 1; i < 10; i++)
    {
        count[i] += count[i - 1];
    }

    // Build the output array based on the digit
    for (int i = n - 1; i >= 0; i--)
    {
        int digitValue = GetDigitValue(array[i], digit);
        output[count[digitValue] - 1] = array[i];
        count[digitValue]--;
    }

    // Copy the output array back to the original array
    for (int i = 0; i < n; i++)
    {
        array[i] = output[i];
    }
}

// Function to perform Radix Sort on an array of integers
void RadixSort(int[] array)
{
    int n = array.Length;
    int maxDigits = (int)Math.Floor(Math.Log10(array.Max()) + 1);

    // Perform Counting Sort for each digit place, from least significant to most significant
    for (int digit = 1; digit <= maxDigits; digit++)
    {
        CountingSortByDigit(array, digit);
    }
}

// Function to demonstrate the first sorting task
void Task1()
{
    Console.Clear();
    int[] array = GenerateArray(10, 0, 10);
    Console.WriteLine("Initial array:");
    PrintArray(array);
    LinearTimeSort(array);
    Console.WriteLine("Result:");
    PrintArray(array);
}

// Function to demonstrate the second sorting task
void Task2()
{
    Console.Clear();
    int[] array = GenerateArray(10, 0, 10);
    Console.WriteLine("Initial array:");
    PrintArray(array);
    CountingSort(array);
    Console.WriteLine("Result:");
    PrintArray(array);
}

// Function to demonstrate the third sorting task
void Task3()
{
    Console.Clear();
    int[] array = GenerateArray(10, 100, 999);
    Console.WriteLine("Initial array:");
    PrintArray(array);
    RadixSort(array);
    Console.WriteLine("Result:");
    PrintArray(array);
}

// Execute the tasks one by one
Task1();
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Task2();
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Task3();
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Console.Clear();

// Definition of the TreeNode class representing a node in a binary search tree
class TreeNode
{
    public int Value { get; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}
