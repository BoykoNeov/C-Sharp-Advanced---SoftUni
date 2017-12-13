/// <summary>
/// We are given the following sequence of numbers:
///•	S1 = N
///•	S2 = S1 + 1
///•	S3 = 2* S1 + 1
///•	S4 = S1 + 2
///•	S5 = S2 + 1
///•	S6 = 2* S2 + 1
///•	S7 = S2 + 2
///•	…
///Using the Queue<T> class, write a program to print its first 50 members for given N
/// </summary>
using System;
using System.Collections.Generic;

public class CalculateSequenceWithQueue
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        List<decimal> results = new List<decimal>();
        Queue<decimal> queue = new Queue<decimal>();
        queue.Enqueue(n);
        results.Add(n);

        while (results.Count < 50)
        {
            decimal k = queue.Dequeue();

            decimal firstOperator = k + 1;
            decimal secondOperator = (k * 2) + 1;
            decimal thirdOperator = k + 2;

            queue.Enqueue(firstOperator);
            queue.Enqueue(secondOperator);
            queue.Enqueue(thirdOperator);

            results.Add(firstOperator);

            //it really should contain one more such a check for adding the last element, but currently it works fine for n = 50 ;)
            if (results.Count == 50)
            {
                break;
            }
            results.Add(secondOperator);
            results.Add(thirdOperator);
        }

        Console.WriteLine(string.Join(" ", results));
    }
}