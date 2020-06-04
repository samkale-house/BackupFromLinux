
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;


//use antiXSS cross side scripting library and use here to stop executing scripts inserted by users in input fields

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {   
            
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

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Blog()
        {
            BlogViewModel blog=new BlogViewModel();
            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Blog(BlogViewModel blog)
        {
            blog.posts.Add(new Post(){data = System.Web.HttpUtility.HtmlEncode(blog.Mypost.data,false)});
   //           blog.posts.Add(new Post(){data = AntiXssEncoder.HtmlEncode(blog.Mypost.data,false)});
            return View(blog);
        }
    }
}
