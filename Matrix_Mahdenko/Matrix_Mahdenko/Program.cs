using System;
using System.IO;

namespace Matrix_Mahdenko
{
    class Program
    {
        static void Main()
        {
            try
            {
                Matrix FirstMatrix = Matrix.ReadFromFile("FirstMatrix.txt");
                Matrix SecondMatrix = Matrix.ReadFromFile("SecondMatrix.txt");

                Console.WriteLine("First matrix:");
                FirstMatrix.Print();

                Console.WriteLine("Second matrix:");
                SecondMatrix.Print();

                Matrix sumMatrix = Matrix.Add(FirstMatrix, SecondMatrix);
                Console.WriteLine("\nAdd matrix:");
                sumMatrix.Print();

                Matrix differenceMatrix = Matrix.Difference(FirstMatrix, SecondMatrix);
                Console.WriteLine("\nDiference matrix:");
                differenceMatrix.Print();

                Matrix multiplyMatrix = Matrix.Multiply(FirstMatrix, SecondMatrix);
                Console.WriteLine("\nMultiply matrix:");
                multiplyMatrix.Print();

                using (StreamWriter writer = new StreamWriter("Result.txt", false)) /*false, який вказує на те, що файл не повинен бути очищений перед використанням*/
                {
                    writer.WriteLine("\nAdd matrix:");
                    sumMatrix.WriteToFile(writer);

                    writer.WriteLine("\nDifference matrix:");
                    differenceMatrix.WriteToFile(writer);

                    writer.WriteLine("\nMultiply matrix:");
                    multiplyMatrix.WriteToFile(writer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
