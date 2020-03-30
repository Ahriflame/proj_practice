using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Laba1.Controllers
{
    
    [ApiController]
    [Route("fibonacci/{index}")]
    public class FibonacciController : ControllerBase
    {
        
        private static double GetFibonacci(double index)
        {
            if (index == 0 || index == 1)
            {
                return index;
            }
            else
            {
                return GetFibonacci(index - 1) + GetFibonacci(index - 2);
            }
        }

        public double Get(double index)
        {
            return GetFibonacci(index);
        }
    }
}
