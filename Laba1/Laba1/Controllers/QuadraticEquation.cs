using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Laba1.Controllers
{
    [ApiController]
    [Route("quadraticequation")]
    public class QuadraticEquation : ControllerBase
    {
        public string[] GetTheRoots(int a, int b, int c)
        {
            var D = Math.Pow(b, 2) - 4 * a * c;
            if (D > 0 || D == 0)
            return (new[] { (-b + Math.Sqrt(D)) / (2 * a),
               (-b - Math.Sqrt(D)) / (2 * a)}).Select(x => Convert.ToString(x)).ToArray();
            return new[] { "Действительных корней нет" };
        }
    }
}
