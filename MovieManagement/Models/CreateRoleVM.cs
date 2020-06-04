using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

//this class is to add more properties columns to the user e.g. address,phone,etc.,it can be used instead of IdentityUser in application.
namespace MovieManagement.Models
{
    public class CreateRoleVM
    {
        [Display(Name="Role Name")]
        [Required]
        public string RoleName{get;set;}
    }
}