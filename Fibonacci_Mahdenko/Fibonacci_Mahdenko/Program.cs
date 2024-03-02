using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fibonacci_Mahdenko
{
    class Program
    {
        static void Main()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "MaxNumber.txt");
                int maxNumber = int.Parse(File.ReadAllText(filePath));
                string filePathSecond = Path.Combine(Directory.GetCurrentDirectory(), "FirstNumbers.txt");
                string firstNumbersText = File.ReadAllText(filePathSecond);
                string[] firstNumbersArray = firstNumbersText.Split(',');

                List<int> inputNumbers = firstNumbersArray.Select(int.Parse).ToList();

                Console.WriteLine("Fibonacci1");
                List<int> fibonacciLine = FibonacciCalculator.CalculateFibonacci(inputNumbers, maxNumber);
                Console.WriteLine($"Fibonacci Sequence: {string.Join(", ", fibonacciLine)}");
                Console.WriteLine($"Fibonacci steps: {FibonacciCalculator.Steps} \n");

                FibonacciCalculator.steps = 0;
                string filePathThird = Path.Combine(Directory.GetCurrentDirectory(), "CountSteps.txt");
                int steps = int.Parse(File.ReadAllText(filePathThird));
                int firstNumber = int.Parse(firstNumbersArray[0]);
                int secondNumber = int.Parse(firstNumbersArray[1]);

                Console.WriteLine("Fibonacci2");
                List<int> fibonacciLinee = FibonacciCalculator.FibonacciCalculate(new List<int> { firstNumber, secondNumber }, steps);
                Console.WriteLine($"Fibonacci Sequence: {string.Join(", ", fibonacciLinee)}");
                Console.WriteLine($"Fibonacci steps: {steps}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
