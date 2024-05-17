using SuperDuperMenuLib;

namespace Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
          SuperDuperMenu menu = new SuperDuperMenu();            
          menu.AddEntry("Run NDTM", () => {
            Console.Write("Enter input string: ");
            string input = Console.ReadLine();
            NDTM ndtm = new NDTM(input);
            ndtm.Run();

            Console.WriteLine("NDTM accepted: " + ndtm.IsAccepted());
          });


          menu.Run();
        }
    }
}
