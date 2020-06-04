using System;
using System.ComponentModel.DataAnnotations;

namespace AjaxAtClientPrj.Models{
    
    public class Movie
    {
        
        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Genre { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }

        public string PhotoPath{get;set;}
    }
}