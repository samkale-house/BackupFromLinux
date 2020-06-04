using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppointmentMgmtLibrary.RepositoryStore;
using AppointmentMgmtLibrary.Model;
using AppointmentMgmtUI.Models;
using AppointmentMgmtUI.ViewModel;


namespace AppointmentMgmtUI.Controllers
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
            PatientMockRepo db=new PatientMockRepo();    
            Patient model=db.getPatient("Neha","Mahalle",new DateTime(1986, 11, 28));
            
            return View(model);
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
