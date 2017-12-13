using System;
using System.Collections.Generic;
using System.Linq;

public class ReverseNumbersStartUp
{
    static void Main()
    {
        IEnumerable<int> numberersInput = Console.ReadLine().Split(new char[] {' '}, options: StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
        Stack<int> numbers = new Stack<int>();
        foreach (int number in numberersInput)
        {
            numbers.Push(number);
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}