using Lab_6;

TuringMachine turingMachine = new TuringMachine();
while (true)
{
    Console.Clear();
    Console.Write("Enter number of Task: ");
    int task = int.Parse(Console.ReadLine());
    switch (task)
    {
        case 1:
            Console.Clear();
            Console.Write("Enter first unary number: ");
            string firstNumber = Console.ReadLine();
            Console.Write("Enter second unary number: ");
            string secondNumber = Console.ReadLine();
            Console.Write("Result: ");
            Console.WriteLine(turingMachine.TuringMachineRun(firstNumber, secondNumber, 0));
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;
        case 2:
            Console.Clear();
            Console.Write("Enter first binary number: ");
            string firstBinaryNumber = Console.ReadLine();
            Console.Write("Enter second binary number: ");
            string secondBinaryNumber = Console.ReadLine();
            Console.Write("Result: ");
            Console.WriteLine(turingMachine.TuringMachineRun(firstBinaryNumber, secondBinaryNumber, 1));
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            break;
        case 3:
            Console.Clear();
            Console.Write("Enter first unary number: ");
            string firstUnaryNumber = Console.ReadLine();
            Console.Write("Enter second unary number: ");
            string secondUnaryNumber = Console.ReadLine();
            Console.Write("Result: ");
            Console.WriteLine(turingMachine.TuringMachineRun(firstUnaryNumber, secondUnaryNumber, 2));
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            break;
        case 4:
            Console.Clear();
            Console.Write("Enter first unary number: ");
            string firstUnaryNumber1 = Console.ReadLine();
            Console.Write("Enter second unary number: ");
            string secondUnaryNumber1 = Console.ReadLine();
            Console.Write("Result: ");
            Console.WriteLine(turingMachine.TuringMachineRun(firstUnaryNumber1, secondUnaryNumber1, 3));
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            break;
        case 5:
            Console.Clear();
            break;
        case 0:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Invalid Task Number");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            break;
    }
}