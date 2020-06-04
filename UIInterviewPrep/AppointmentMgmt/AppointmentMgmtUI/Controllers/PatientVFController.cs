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
    public class PatientVF : Controller
    {
        private readonly ILogger _logger;
        public PatientVF(ILogger logger)
        {
            _logger=logger;
        }

        [HttpGet]
        public ActionResult getPatientDetails()
        {
            PatientMockRepo db=new PatientMockRepo();    
            Patient model=db.getPatient("Neha","Mahalle",new DateTime(1986, 11, 28));
            return View();
        }

        [HttpPost]
        public ActionResult PatientDetails(PatientVM model)
        {
            
            return View(model);
        }       

        
    }
}