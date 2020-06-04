using Microsoft.AspNetCore.Http;
using MovieManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.ViewModels
{
    public class EditRoleVM    {
        public EditRoleVM()
        {
            users=new List<string>();
        }
        public string Id {get;set;}
        public string RoleName { get; set; }

        public List<string> users{get;set;}
    }
}

