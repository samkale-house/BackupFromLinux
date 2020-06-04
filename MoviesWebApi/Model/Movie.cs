using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MoviesWebApi.Models
{
    public class Movie
    {
        [FromQuery]
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
