using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SomeCompany.Shared;

namespace SomeCompany.Recommendation.Models
{
    public class FilterViewModel
    {
        public DateTime Year { get; set; }

        public string Artist { get; set; }
    }
}