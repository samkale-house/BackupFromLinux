using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReportGenerationPrj.Models;

namespace ReportGenerationPrj.Controllers
{
    public class ManageProductsController : Controller
    {
        private readonly ILogger<ManageProductsController> _logger;

        public ManageProductsController(ILogger<ManageProductsController> logger)
        {
            _logger = logger;
           
        }

        public IActionResult AllProducts()
        {
           List<SamProduct> products=new List<SamProduct>();
          SamProduct prod1=new SamProduct();
          prod1.Product_id=1;
          prod1.ProductLaunched=DateTime.Today;
          prod1.ProductName="Product1";
          prod1.ProductPrice=12;
          prod1.STATUS="ACTV";
          products.Add(prod1);
          SamProduct prod2=new SamProduct();
          prod2.Product_id=2;
          prod2.ProductLaunched=DateTime.Today;
          prod2.ProductName="Product2";
          prod2.ProductPrice=11;
          prod2.STATUS="ACTV";
          products.Add(prod2);
          SamProduct prod3=new SamProduct();
          prod3.Product_id=18;
          prod3.ProductLaunched=DateTime.Today;
          prod3.ProductName="Product3";
          prod3.ProductPrice=23;
          prod3.STATUS="ACTV";
          products.Add(prod3);
          SamProduct prod4=new SamProduct();
          prod4.Product_id=5;
          prod4.ProductLaunched=DateTime.Today;
          prod4.ProductName="Product4";
          prod4.ProductPrice=20;
          prod4.STATUS="ACTV";
          products.Add(prod4);
          SamProduct prod5=new SamProduct();
          prod5.Product_id=11;
          prod5.ProductLaunched=DateTime.Today;
          prod5.ProductName="Product5";
          prod5.ProductPrice=5;
          prod5.STATUS="ACTV";
          products.Add(prod5);

            return View(products);
        }

        /*public IActionResult ExportToCSV()
        {//use csvhelper
            var stream = new MemoryStream();
var writer = new StreamWriter(stream);
var csv = new CsvWriter(writer);
csv.WriteRecords(records);
return File( stream, "text/csv", "MyFile.csv" );
            return new CsvHelperFileResult<RecordType, RecordCsvMap>(records, ";")
{
    FileDownloadName = "my-csv-file.csv"
};
                    }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
