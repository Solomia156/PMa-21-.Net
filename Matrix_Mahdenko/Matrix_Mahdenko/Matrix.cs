using System;
using System.Collections.Generic;
using System.IO;

namespace Matrix_Mahdenko
{
    public class Matrix
    {
        public List<List<int>> Data { get; set; }

        public Matrix(List<List<int>> data)
        {
            Data = data;
        }

        public static Matrix ReadFromFile(string filename)
        {
            List<List<int>> matrixData = new List<List<int>>();

            using (StreamReader reader = new StreamReader(filename)) /*блок using для автоматичного закриття ресурсів, таких як StreamReader, після завершення використання.*/
            {
                //створення екземпляра StreamReader, який відповідає за читання тексту з файлу.
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    List<int> row = new List<int>();

                    foreach (string value in line.Split(','))
                    {
                        row.Add(int.Parse(value.Trim()));
                    }

                    matrixData.Add(row);
                }
            }

            return new Matrix(matrixData);
        }

        public void Print()
        {
            foreach (var row in Data) /*foreach використовується для ітерації(перебору) елементів колекції або послідовності.*/
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        public static Matrix Add(Matrix matrixFirst, Matrix matrixSecond)
        {
            if (matrixFirst.Data.Count != matrixSecond.Data.Count || matrixFirst.Data[0].Count != matrixSecond.Data[0].Count)
            {
                throw new ArgumentException("Matrix must be same size for add");
            }

            int rows = matrixFirst.Data.Count;
            int cols = matrixFirst.Data[0].Count;

            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < rows; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < cols; j++)
                {
                    row.Add(matrixFirst.Data[i][j] + matrixSecond.Data[i][j]);
                }
                result.Add(row);
            }

            return new Matrix(result);
        }

        public static Matrix Difference(Matrix matrixFirst, Matrix matrixSecond)
        {
            if (matrixFirst.Data.Count != matrixSecond.Data.Count || matrixFirst.Data[0].Count != matrixSecond.Data[0].Count)
            {
                throw new ArgumentException("Matrices must be same size for difference");
            }

            int rows = matrixFirst.Data.Count;
            int cols = matrixFirst.Data[0].Count;

            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < rows; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < cols; j++)
                {
                    row.Add(matrixFirst.Data[i][j] - matrixSecond.Data[i][j]);
                }
                result.Add(row);
            }

            return new Matrix(result);
        }

        public static Matrix Multiply(Matrix matrixFirst, Matrix matrixSecond)
        {
            int rowsFirst = matrixFirst.Data.Count;
            int colsFirst = matrixFirst.Data[0].Count;
            int rowsSecond = matrixSecond.Data.Count;
            int colsSecond = matrixSecond.Data[0].Count;

            if (colsFirst != rowsSecond)
            {
                throw new ArgumentException("The number of columns of the first matrix isn't equal to the number of rows of the second matrix");
            }

            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i < rowsFirst; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < colsSecond; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < colsFirst; k++)
                    {
                        sum += matrixFirst.Data[i][k] * matrixSecond.Data[k][j];
                    }
                    row.Add(sum);
                }
                result.Add(row);
            }

            return new Matrix(result);
        }

        public void WriteToFile(StreamWriter writer)
        {
            foreach (var row in Data)
            {
                writer.WriteLine(string.Join(",", row));
            }
        }
    }
}