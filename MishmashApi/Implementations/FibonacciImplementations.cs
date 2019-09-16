using System;
using System.Collections.Generic;

namespace MishmashApi.Implementations
{
    //Memoization
    public class FibonacciImplementations
    {
        //Example of implementation
        public static long ImperativeFibonacci(long n)

        {
            long a = 0;
            long b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (long i = 0; i < n; i++)
            {
                var temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        //Recursive way
        //Fibonacci(n) = Fibonacci(n-1) + Fibonacci(n-2)
        //Fibonacci(1) = 1
        //Fibonacci(0) = 0
        public static long FibonacciWithoutMemoization(long i) => throw new NotImplementedException();

        //Recursive way with memoization
        public static long FibonacciWithMemoization(long i, Dictionary<long, long> cache) => throw new NotImplementedException();

    }
}