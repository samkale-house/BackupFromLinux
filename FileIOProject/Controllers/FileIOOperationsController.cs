using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileIOProject.Models;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace FileIOProject.Controllers
{
    public class FileIOOperations : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public FileIOOperations(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Report> allreports = new List<Report>();
            allreports = _appDbContext.UserReports.ToList();

            return View(allreports);
        }

        /*public ActionResult Index()
        {
            //use ef ,model to match report and user table in database
            //show userid and report columns
            //send the model to view
            //show in table format
        }*/

        public FileResult ShowReport(int id)
        {

            var reportentity = _appDbContext.UserReports.FirstOrDefault(x => x.StudentId == id);
            Byte[] byteArray = reportentity.ReportContent;
            return File(byteArray, "application/pdf");

            /*        DataTable dt=new DataTable();
                  //  if(getPDF(id)!=null)
                     {
                         dt=getPDF(id);
                         Byte[] byteArray=(Byte[])dt.Rows[0]["ReportContent"];
                         int ContentLength=(int)dt.Rows[0]["ContentLength"];
                         return File(byteArray,"application/pdf");
                    }
                //return ;
                */
        }

        private DataTable getPDF(int id)
        {

            String strConnString = "Data Source=localhost;database=FileIOReportDB;Uid=SA;Password=SAadmin123";
            SqlCommand cmd = new SqlCommand("select ReportName,ReportContent,ContentLength from UserReports where ReportId=@ReportId");
            cmd.Parameters.Add("@ReportId", SqlDbType.Int).Value = id;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            cmd.CommandType = CommandType.Text;

            cmd.Connection = con;

            try

            {

                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dataTable);
                con.Close();
                return dataTable;

            }

            catch (Exception ex)

            {

                Console.Write(ex.Message);

                return null;

            }

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
