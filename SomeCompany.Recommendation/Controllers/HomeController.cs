using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using SomeCompany.Recommendation.Models;
using SomeCompany.Shared;

namespace SomeCompany.Recommendation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new FilterViewModel() { };

            return View(model);
        }

        public ActionResult Recommendation(string id)
        {
            var suggestions = FilterManager.GetSuggestions(id);
            var genres = FilterManager.GetGenres(suggestions);

            var viewModel = new ResultViewModel()
            {
                Suggestions = suggestions,
                Genre = genres
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GetArtist(string artist)
        {
            var artistSearch = FilterManager.SearchArtist(artist);

            return PartialView("Partial/Result", artistSearch);
        }
    }
}