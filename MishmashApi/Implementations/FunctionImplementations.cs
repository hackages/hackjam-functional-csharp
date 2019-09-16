using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Data.Edm.Library.Annotations;
using static MishmashApi.Implementations.HighOrderFunctions;
using static MishmashApi.Implementations.CurriedFunction;

namespace MishmashApi.Implementations
{
    public class FunctionImplementations
    {
        //AzErTy -> yTrEzA
        public Func<string, string> ToReverse => throw new NotImplementedException();

        //hello world -> HelloWorld
        //hEllO wOrLd -> HelloWorld
        public Func<string, string> ToPascalCase => throw new NotImplementedException();

        //hello world -> helloWorld
        //hEllO wOrLd -> helloWorld
        public Func<string, string> ToCamelCase => throw new NotImplementedException();

        //hello world -> hhheeellllllooo wwwooorrrlllddd
        public Func<string, string> Repeat3Times => throw new NotImplementedException();

        //hello world -> DlrowOlleh
        public Func<string, string> ToReverseAndPascalCase => throw new NotImplementedException();

        //hello world -> dlrowOlleh
        public Func<string, string> ToReverseAndCamelCase => throw new NotImplementedException();

        //hello world -> dddddlllllrrrrrooooowwwww     ooooollllleeeeehhhhh
        public Func<string, string> ToReverseAndRepeat5Times => throw new NotImplementedException();

        //hello world -> hello
        public Func<string, string> GetTheFirstFourCharacters => throw new NotImplementedException();

        //hello world -> lllllllleeeehhhh
        public Func<string, string> GetTheFirstFourCharactersThenReverseAndRepeat4Times => throw new NotImplementedException();

        //6 -> 13
        public Func<int, int> AddFive => throw new NotImplementedException();

        //[1,2,3,4,5] -> [8,9,10,11,12]
        public Func<int[], int[]> AddSevenToEachNumber => throw new NotImplementedException();

        //[1,2,3,4,5] -> [12,15,18,21,24]
        public Func<int[], int[]> AddThreeAndMultiplyByThreeEachNumber => throw new NotImplementedException();

    }
    
    public static class HighOrderFunctions
    {
        
        /// <summary>
        /// Return a function that calls each function passing the result of the previous function as the input for the next one.
        /// The first parameter being passed is the value argument
        /// </summary>
        /// <typeparam name="TValue">The type returned</typeparam>
        /// <param name="value">The first parameter</param>
        /// <param name="functions">The list of function to execute</param>
        /// <returns>The resulting value</returns>
        public static Func<TValue, TValue> Pipe<TValue>(params Func<TValue, TValue>[] functions) => throw new NotImplementedException();

        /// <summary>
        /// Return a Repeat function who repeats n times each letter of the string
        /// </summary>
        /// <param name="n">The number of times that we repeat each character</param>
        /// <returns>The function</returns>
        public static Func<string, string> Repeat(int n) => str =>
            str.ToCharArray().Select(c => new string(c, n))
                .Aggregate(string.Empty, (acc, curr) => acc + curr);
    }

    public static class CurriedFunction
    {
        /// <summary>
        /// Curried version of the Add(x,y) function.
        /// </summary>
        /// <param name="first">The number to add parameter</param>
        /// <returns>The partially applied Add function</returns>
        public static Func<int, int> Add(int first) => throw new NotImplementedException();

        // <summary>
        /// Curried version of the Add(x,y) function.
        /// </summary>
        /// <param name="first">The number to add parameter</param>
        /// <returns>The partially applied Add function</returns>
        public static Func<int, int> Multiply(int first) => throw new NotImplementedException();

        // <summary>
        /// Curried version of the Substring(start, length, string) function.
        /// </summary>
        /// <param name="first">The start of the substring</param>
        /// <returns>The partially applied Substring function</returns>
        public static Func<int, Func<string, string>> GetSubstring(int start) => throw new NotImplementedException();


    }
}
