using System;

namespace CalculateDeposits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = Calculate(input);
            Console.WriteLine(sum.ToString().Replace(',', '.'));
        }

        public static double Calculate(string userInput)
        {
            var values = userInput.Split(' ');
            double deposit = Convert.ToDouble(values[0]);
            double percent = Convert.ToDouble(values[1]);
            int mounths = Convert.ToInt32(values[2]);

            return deposit * Math.Pow(1 + percent / 12 / 100, mounths);
        }

    }
}
