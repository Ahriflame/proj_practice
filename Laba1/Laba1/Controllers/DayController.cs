using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Laba1.Controllers
{
    [ApiController]
    [Route("day")]
    public class DayController : ControllerBase
    {     
        public string GetDay(string date)
        {
           var d = date.Split(".").Select(x => Convert.ToInt32(x)).ToArray();
           DateTime dateValue = new DateTime(d[2], d[1], d[0]);
           return dateValue.ToString("dddd");
        }
    }
}
