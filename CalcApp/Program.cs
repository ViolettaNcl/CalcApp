using System;
using static System.Console;
using CalcApp;

namespace CalcApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                if (double.TryParse(args[0], out double number1) &&
                    double.TryParse(args[2], out double number2))
                {
                    try
                    {
                        WriteLine($"{number1} {args[1]} {number2} = {Calculator.Compute(number1, number2, args[1]):F2}");
                    }
                    catch (Exception ex)
                    {
                        WriteLine($"Error: {ex.Message}");
                    }
                }
                return;
            }

            string answer = "y";
            while (answer == "y")
            {
                DoOperation();
                Write("Repeat(y/n)?: ");
                answer = ReadLine() ?? ""; // Исправление null-значения
            }
        }

        static void DoOperation()
        {
            Write("Enter number1: ");
            if (!double.TryParse(ReadLine(), out double number1))
            {
                WriteLine("Error: Invalid number1!");
                return;
            }

            Write("Enter operation (+ - * / :): ");
            string operationSign = ReadLine() ?? ""; // Исправление null-значения

            Write("Enter number2: ");
            if (!double.TryParse(ReadLine(), out double number2))
            {
                WriteLine("Error: Invalid number2!");
                return;
            }

            try
            {
                WriteLine($"{number1} {operationSign} {number2} = {Calculator.Compute(number1, number2, operationSign):F2}");
            }
            catch (Exception ex)
            {
                WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
