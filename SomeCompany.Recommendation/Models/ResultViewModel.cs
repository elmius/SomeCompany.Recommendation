using System.Collections.Generic;
using SomeCompany.Shared;

namespace SomeCompany.Recommendation.Models
{
    public class ResultViewModel
    {
        public List<Suggestions> Suggestions { get; set; }

        public List<string> Genre { get; set; }
    }
}