using SuperDuperMenuLib;

namespace Lab_8;

public class Program
{
    static void Main()
    {
        SuperDuperMenu menu = new SuperDuperMenu();
        Dictionary<string, Action> entries = new(){
          {"Task 1", () => {
            Console.Write("Enter numbers separated by space: ");
            string input = Console.ReadLine();
            var RAM = new RandomAccessMachine(input, RamRules.GetCommands(1));
            Console.WriteLine(RAM.Calculate());
                           }},
          {"Task 2", () => {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            var RAM = new RandomAccessMachine(input, RamRules.GetCommands(2));
            Console.WriteLine(RAM.Calculate());
                           }},
          {"Task 3", () => {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            var RAM = new RandomAccessMachine(input, RamRules.GetCommands(3));
            Console.WriteLine(RAM.Calculate());
                           }},
          {"Task 4", () => {
            Console.Write("Enter numbers separated by space: ");
            string input = Console.ReadLine();
            var RAM = new RandomAccessMachine(input, RamRules.GetCommands(4));
            Console.WriteLine(RAM.Calculate());
                           }},
          {"Task 5", () => {
            Console.Write("Enter numbers separated by space: ");
            string input = Console.ReadLine();
            var RAM = new RandomAccessMachine(input, RamRules.GetCommands(5));
            Console.WriteLine(RAM.Calculate());
                           }}
        };
        menu.LoadEntries(entries);
        menu.Run();
    }
}

