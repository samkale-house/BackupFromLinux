using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AjaxAtClientPrj.Models;
using Newtonsoft.Json;

namespace AjaxAtClientPrj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpclient=new HttpClient();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {//way1
           /* var allMovieresponse=await _httpclient.GetAsync("https://localhost:6001/Movies");
            List<Movie> movieList=new List<Movie>();
            string apiresponse=await allMovieresponse.Content.ReadAsStringAsync();
            movieList= JsonConvert.DeserializeObject<List<Movie>>(apiresponse);    
            */

           // way2
  /*RestClient rClient = new RestClient();
  rClient.endPoint = "https://localhost:6001/Movies";
  string strJSON = string.Empty;
  strJSON = rClient.makeRequest();//Rest service should solve SSL certificate issue first
  
  var movieList= JsonConvert.DeserializeObject<List<Movie>>(strJSON);
  return View(movieList);*/
        
        return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
