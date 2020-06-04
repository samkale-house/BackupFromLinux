using System;

namespace ReportGenerationPrj.Models
{
    public class SamProduct
    {
         public SamProduct()
        {
            
        }
        public int Product_id{get;set;}
        public DateTime ProductLaunched{get;set;}
        public string ProductName{get;set;} 
        public int ProductPrice { get; set; }
        public string STATUS{get;set;} 
        
    }
}
