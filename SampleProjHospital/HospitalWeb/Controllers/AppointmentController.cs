namespace HospitalWeb.Controllers
{
    public class AppointmentController:Controller
    {
        private readonly ILogger<AppointmentController> _logger;
        public AppointmentController(ILogger<AppointmentController> logger)
        {
            logger=_logger;            
        }

        [HttpGet]
        public ActionResult GetPatient()
        {
            //todo:get patient by his name and dob info
            //display on screen
         return View();
        }
    }
}