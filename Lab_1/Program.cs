static void Task1()
{
    /*1. Елементи двох лінійних масивів A[1..m] та B[1..n]	розташовані у порядку неспадання. 
    Скласти алгоритм, результатом якого є неспадний масив C[1..m+n], 
    у якому кожен елемент зустрічається стільки разів, 
    скільки разів він зустрічається в масивах A та B, разом. 
    Оцінка алгоритму не повинна перевищувати С*( m+n ).*/

    System.Console.WriteLine("Task 1");
    System.Console.WriteLine("Enter the size of the first array: ");
    int m = int.Parse(Console.ReadLine()); // розмір першого масиву
    System.Console.WriteLine("Enter the size of the second array: ");
    int n = int.Parse(Console.ReadLine()); // розмір другого масиву

    int[] A = new int[m]; // перший масив
    int[] B = new int[n]; // другий масив

    Random rand = new Random(); 
    for (int h = 0; h < A.Length; h++) 
    {
        A[h] = rand.Next(1, 10); // заповнення масиву A випадковими числами
    }
    for (int h = 0; h < B.Length; h++) 
    {
        B[h] = rand.Next(1, 10); // заповнення масиву B випадковими числами
    }
    Array.Sort(A); // сортування масиву A
    Array.Sort(B); // сортування масиву B

    System.Console.WriteLine("\nArray A: ");
    foreach (int item in A) // виведення елементів масиву A
    {
        System.Console.Write(item + " ");
    }
    System.Console.WriteLine("\nArray B: ");
    foreach (int item in B) // виведення елементів масиву B
    {
        System.Console.Write(item + " ");
    }
    System.Console.WriteLine("\nArray C: ");

    int[] C = new int[m + n]; // масив C
    int i = 0, j = 0, k = 0;

    // Порівнюємо елементи масивів A та B, та записуємо їх в масив C
    while (i < m && j < n)
    {
        if (A[i] < B[j])
        {
            C[k] = A[i];
            i++;
        }
        else
        {
            C[k] = B[j];
            j++;
        }
        k++;
    }

    // Записуємо елементи, які залишились в масивах A та B
    while (i < m)
    {
        C[k] = A[i];
        i++;
        k++;
    }

    while (j < n)
    {
        C[k] = B[j];
        j++;
        k++;
    }


    foreach (int item in C) // виведення елементів масиву C
    {
        System.Console.Write(item + " ");
    }
}

static void Task2(){
    /*Скласти алгоритм, аргументами якого є три неспадні масиви, 
    про які відомо, що існує хоча б одне число, яке зустрічається у кожному масиві. 
    Результатом роботи повинно бути найменше з таких чисел. 
    Кількість дій не повинна бути більшою деякої константи, 
    помноженої на загальну кількість елементів у всіх трьох масивах.*/

    System.Console.WriteLine("Task 2");
    System.Console.WriteLine("Enter the size of the first array: ");
    int m = int.Parse(Console.ReadLine()); // розмір першого масиву
    System.Console.WriteLine("Enter the size of the second array: ");
    int n = int.Parse(Console.ReadLine()); // розмір другого масиву
    System.Console.WriteLine("Enter the size of the third array: ");
    int o = int.Parse(Console.ReadLine()); // розмір третього масиву

    int[] A = new int[m]; // перший масив
    int[] B = new int[n]; // другий масив
    int[] C = new int[o]; // третій масив

    Random rand = new Random();
    for (int h = 0; h < A.Length; h++)
    {
        A[h] = rand.Next(1, 10); // заповнення масиву A випадковими числами
    }
    for (int h = 0; h < B.Length; h++)
    {
        B[h] = rand.Next(1, 10); // заповнення масиву B випадковими числами
    }
    for (int h = 0; h < C.Length; h++)
    {
        C[h] = rand.Next(1, 10); // заповнення масиву C випадковими числами
    }
    Array.Sort(A); // сортування масиву A
    Array.Sort(B); // сортування масиву B
    Array.Sort(C); // сортування масиву C

    System.Console.WriteLine("\nArray A: ");
    foreach (int item in A) // виведення елементів масиву A
    {
        System.Console.Write(item + " ");
    }
    System.Console.WriteLine("\nArray B: ");
    foreach (int item in B) // виведення елементів масиву B
    {
        System.Console.Write(item + " ");
    }
    System.Console.WriteLine("\nArray C: ");
    foreach (int item in C) // виведення елементів масиву C
    {
        System.Console.Write(item + " ");
    }
    System.Console.WriteLine("\n");

    int i = 0, j = 0, k = 0;
    while (i < m && j < n && k < o)
    {
        if (A[i] == B[j] && B[j] == C[k])
        {
            System.Console.WriteLine("The smallest number that is in all three arrays: " + A[i]);
            break;
        }
        else if (A[i] < B[j])
        {
            i++;
        }
        else if (B[j] < C[k])
        {
            j++;
        }
        else
        {
            k++;
        }
    }
}

static void Task3(){
    /* В прямокутному масиві A[1..m, 1..n] елементи в кожному рядку і в кожному стовпці не спадають. 
    Скласти алгоритм, який визначає чи є в масиві число х. 
    Кількість дій не повинна перевищувати С*( m+n ).*/

    System.Console.WriteLine("Task 3");
    System.Console.WriteLine("Enter the number of rows: ");
    int m = int.Parse(Console.ReadLine()); // кількість рядків
    System.Console.WriteLine("Enter the number of columns: ");
    int n = int.Parse(Console.ReadLine()); // кількість стовпців
    int[,] A = new int[m, n]; // прямокутний масив

    for (int h = 0; h < m; h++)
    {
        for (int g = 0; g < n; g++)
        {
            A[h, g] = h + g; // заповнення масиву
        }
    }
    
    System.Console.WriteLine("\n");
    System.Console.WriteLine("Array A: ");

    for (int h = 0; h < m; h++)
    {
        for (int g = 0; g < n; g++)
        {
            System.Console.Write(A[h, g] + " "); // виведення елементів масиву
        }
        System.Console.WriteLine();
    }

    System.Console.WriteLine("Enter the number to search: ");
    int x = int.Parse(Console.ReadLine()); // число, яке потрібно знайти

    int i = 0, j = n - 1;
    while (i < m && j >= 0)
    {
        if (A[i, j] == x)
        {
            System.Console.WriteLine($"{x} is found at position A[{i + 1}, {j + 1}].");
            return;
        }
        else if (A[i, j] > x)
        {
            j--;
        }
        else
        {
            i++;
        }
    }

    System.Console.WriteLine($"{x} is not found in the array.");

}

static void Task4(){
    /*Елементи масивів A[1..m] та B[1..n]	розташовані у порядку неспадання. 
    Скласти алгоритм, який визначає, чи можна з А викреслити деякі елементи так, щоб отримати В. 
    Кількість дій не повинна перевищувати С*(m+n).*/

    System.Console.WriteLine("\nTask 4");
    System.Console.WriteLine("Enter the size of the first array: ");
    int m = int.Parse(Console.ReadLine()); // розмір першого масиву
    System.Console.WriteLine("Enter the size of the second array: ");
    int n = int.Parse(Console.ReadLine()); // розмір другого масиву

    int[] A = new int[m]; // перший масив
    int[] B = new int[n]; // другий масив

    Random rand = new Random();
    for (int h = 0; h < A.Length; h++)
    {
        A[h] = rand.Next(1, 10); // заповнення масиву A випадковими числами
    }
    for (int h = 0; h < B.Length; h++)
    {
        B[h] = rand.Next(1, 10); // заповнення масиву B випадковими числами
    }
    Array.Sort(A); // сортування масиву A
    Array.Sort(B); // сортування масиву B

    System.Console.WriteLine("\nArray A: ");
    foreach (int item in A) // виведення елементів масиву A
    {
        System.Console.Write(item + " ");
    }
    System.Console.WriteLine("\nArray B: ");
    foreach (int item in B) // виведення елементів масиву B
    {
        System.Console.Write(item + " ");
    }
    System.Console.WriteLine("\n");

    int i = 0, j = 0;
    while (i < m && j < n)
    {
        if (A[i] == B[j])
        {
            i++;
            j++;
        }
        else if (A[i] < B[j])
        {
            i++;
        }
        else
        {
            System.Console.WriteLine("Array B cannot be obtained from array A.");
            return;
        }
    }
    System.Console.WriteLine("Array B can be obtained from array A.");
}
Task1();
System.Console.WriteLine("\n---------------------------------------------");
Task2();
System.Console.WriteLine("\n---------------------------------------------");
Task3();
System.Console.WriteLine("\n---------------------------------------------");
Task4();