namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "443.2";
            bool isNum=int.TryParse(input, out int num);
            Console.WriteLine(isNum);
        }
    }
}
