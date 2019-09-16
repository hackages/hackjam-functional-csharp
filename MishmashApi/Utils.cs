using Microsoft.AspNetCore.Mvc;
using MishmashApi.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MishmashApi
{
    public static class Utils
    {
        public static IActionResult BenchAndResponse<T>(Func<T> func)
        {
            var sw = Stopwatch.StartNew();

            var result = func();

            sw.Stop();
            var elapsedTime = sw.ElapsedMilliseconds;
            var elapsedTicks = sw.ElapsedTicks;

            return new OkObjectResult(new Response<T> { Result = result, Ticks = elapsedTicks, Time = elapsedTime });
        }
    }
}
