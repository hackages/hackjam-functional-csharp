using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MishmashApi.Implementations;

namespace MishmashApi.Controllers
{
    public class FunctionController : Controller
    {
        private readonly FunctionImplementations _function;

        public FunctionController(FunctionImplementations function)
        {
            _function = function;
        }

        //GET -> Function/Reverse?s=XXX
        public IActionResult Reverse(string s) => Utils.BenchAndResponse(() => _function.ToReverse(s));
        
        //GET -> Function/PascalCase?s=XXX
        public IActionResult PascalCase(string s) => Utils.BenchAndResponse(() => _function.ToPascalCase(s));

        //GET -> Function/CamelCase?s=XXX
        public IActionResult CamelCase(string s) => Utils.BenchAndResponse(() => _function.ToCamelCase(s));

        //GET -> Function/Repeat3Times?s=XXX
        public IActionResult Repeat3Times(string s) => Utils.BenchAndResponse(() => _function.Repeat3Times(s));

        //GET -> Function/ReverseAndPascalCase?s=XXX
        public IActionResult ReverseAndPascalCase(string s) => Utils.BenchAndResponse(() => _function.ToReverseAndPascalCase(s));

        //GET -> Function/ReverseAndCamelCase?s=XXX
        public IActionResult ReverseAndCamelCase(string s) => Utils.BenchAndResponse(() => _function.ToReverseAndCamelCase(s));

        //GET -> Function/ReverseAndRepeat5Times?s=XXX
        public IActionResult ReverseAndRepeat5Times(string s) => Utils.BenchAndResponse(() => _function.ToReverseAndRepeat5Times(s));

        //GET -> Function/Add5?s=XXX
        public IActionResult Add5(int n) => Utils.BenchAndResponse(() => _function.AddFive(n));

        //GET -> Function/AddSevenToEachNumber?s=XXX
        public IActionResult AddSevenToEachNumber(int[] n) => Utils.BenchAndResponse(() => { Console.WriteLine(n.Length); return _function.AddSevenToEachNumber(n); });

        //GET -> Function/AddThreeAndMultiplyByThreeEachNumber?s=XXX
        public IActionResult AddThreeAndMultiplyByThreeEachNumber(int[] n) => Utils.BenchAndResponse(() => _function.AddThreeAndMultiplyByThreeEachNumber(n));

        //GET -> Function/GetTheFirstFourCharacters?s=XXX
        public IActionResult GetTheFirstFourCharacters(string s) => Utils.BenchAndResponse(() => _function.GetTheFirstFourCharacters(s));

        //GET -> Function/GetTheFirstFourCharactersThenReverseAndRepeat4Times?s=XXX
        public IActionResult GetTheFirstFourCharactersThenReverseAndRepeat4Times(string s) => Utils.BenchAndResponse(() => _function.GetTheFirstFourCharactersThenReverseAndRepeat4Times(s));
    }

}
