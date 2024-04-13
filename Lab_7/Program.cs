using SuperDuperMenuLib;
namespace Lab_7;

static class Program
{
    static void Main(string[] args)
    {
        var menu = new SuperDuperMenu();
        menu.AddEntry("Run a Turing Machine for palindrome", () =>
        {
            Console.WriteLine("Enter a word: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Word: {input} is palindrome?");
            Console.WriteLine(TuringMachine.RunTwoTapeMachine(1, input, String.Empty, true) == "A" ? "Accepted" : "Rejected");
        });

        menu.AddEntry("Run a Turing Machine for binay addition", () =>
        {
            Console.WriteLine("Enter two numbers: ");
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            Console.WriteLine($"Sum of {input1} and {input2} is {TuringMachine.RunThreeTapeMachine(2, input1, input2)}");
        });

        menu.AddEntry("Run a Turing Machine for n^2", () =>
        {
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Square of {input} is {TuringMachine.RunTwoTapeMachine(3, input, String.Empty, returnTape2: true)}");
        });

        menu.Run();
    }
}