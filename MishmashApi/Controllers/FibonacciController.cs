using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;
using MishmashApi.Entities;
using MishmashApi;
namespace MishmashApi.Controllers
{
    public class FibonacciController : Controller
    {
        //GET -> Fibonacci/WithoutMemoization
        [HttpGet]
        public IActionResult WithoutMemoization(
            long n,
            [FromServices] Func<long, long> demonstration) => Utils.BenchAndResponse(() => demonstration(n));
        //GET -> Fibonacci/WithMemoization
        [HttpGet]
        public IActionResult WithMemoization(
            long n,
            [FromServices] Func<long, Dictionary<long, long>, long> demonstration) => Utils.BenchAndResponse(() => demonstration(n, new Dictionary<long, long>()));

    }

}