using System;

namespace CalcApp
{
    public static class Calculator
    {
        public static double Compute(double a, double b, string sign)
        {
            return sign switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" or ":" => b != 0 ? a / b : throw new DivideByZeroException("Division by zero"),
                _ => throw new ArgumentException("Invalid operation")
            };
        }
    }
}
