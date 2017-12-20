namespace PascalTriangle
{
    using System;

    public class PascalTriangleStartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[,] triangle = new long[n, n+1];
            triangle[0, 1] = 1;

            for (int i = 1; i < triangle.GetLength(0); i++)
            {
                for (int j = 1; j < triangle.GetLength(1); j++)
                {
                    triangle[i, j] = triangle[i - 1, j - 1] + triangle[i - 1, j];
                }
            }

            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                for (int j = 1; j < triangle.GetLength(1); j++)
                {
                    if (triangle[i, j] == 0)
                    {
                        break;
                    }

                    Console.Write(triangle[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}