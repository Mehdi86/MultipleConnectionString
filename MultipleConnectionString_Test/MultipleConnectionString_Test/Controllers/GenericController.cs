using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleConnectionString_Test.Controllers
{
    public class GenericController : Controller
    {
        public string FullPathUrl()
        {
            return HttpContext?.Request.GetDisplayUrl();
        }

        public string ProjectName()
        {
            string ssssss = HttpContext?.Request.GetDisplayUrl().Replace(@"https://", "").Replace(@"http://", "").Split(".").FirstOrDefault();
            return HttpContext?.Request.GetDisplayUrl().Replace(@"https://", "").Replace(@"http://", "").Split(".").FirstOrDefault();
        }
    }
}
