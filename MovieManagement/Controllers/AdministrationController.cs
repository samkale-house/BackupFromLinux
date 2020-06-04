using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieManagement.Controllers
{
    public class AdministrationController:Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userMangaer;
         
         public AdministrationController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
         {
            _roleManager = roleManager;
            _userMangaer = userManager;
         }

         [HttpGet]
         public IActionResult CreateRole()
         {
             return View();
         }
         
         [HttpPost]
         public async Task<IActionResult> CreateRole(CreateRoleVM model)
         {
             if(ModelState.IsValid)
             {
             IdentityRole identityRole=new IdentityRole{Name=model.RoleName};
             var result = await _roleManager.CreateAsync(identityRole);  
             if(result.Succeeded)
             {
                 return RedirectToAction("ShowAllRoles","Administration");
             }  
             foreach(var error in result.Errors)
             {
               ModelState.AddModelError("",error.Description);
             }
             }
             return View(model);
         }

        [HttpGet]
         public IActionResult ShowAllRoles()
         {
           IQueryable<IdentityRole> roles=_roleManager.Roles;
           
           return View(roles);
         }
         

        // Role ID is passed from the URL to the action
[HttpGet]
public async Task<IActionResult> EditRole(string id)
{
    // Find the role by Role ID
    var role = await _roleManager.FindByIdAsync(id);

    if (role == null)
    {
        ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
        return View("NotFound");
    }

    var model = new EditRoleVM
    {
        Id = role.Id,
        RoleName = role.Name
    };

    // Retrieve all the Users
    foreach (var user in _userMangaer.Users)
    {
        // If the user is in this role, add the username to
        // Users property of EditRoleViewModel. This model
        // object is then passed to the view for display
        try{
            if (await _userMangaer.IsInRoleAsync(user, role.Name))
        {
            model.users.Add(user.UserName);
        }
        }catch(Exception e){var msg=e.Message;return View(model);}
    }

    return View(model);
}

// This action responds to HttpPost and receives EditRoleViewModel
[HttpPost]
public async Task<IActionResult> EditRole(EditRoleVM model)
{
    var role = await _roleManager.FindByIdAsync(model.Id);

    if (role == null)
    {
        ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
        return View("NotFound");
    }
    else
    {
        role.Name = model.RoleName;

        // Update the Role using UpdateAsync
        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            return RedirectToAction("ShowAllRoles");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }
}
         [HttpGet]
public async Task<IActionResult> EditUsersInRole(string roleId)
{
    ViewBag.roleId = roleId;

    var role = await _roleManager.FindByIdAsync(roleId);

    if (role == null)
    {
        ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
        return View("NotFound");
    }

    var model = new List<UserRoleViewModel>();

    foreach (var user in _userMangaer.Users)
    {
        var userRoleViewModel = new UserRoleViewModel
        {
            UserId = user.Id,
            UserName = user.UserName
        };

        if (await _userMangaer.IsInRoleAsync(user, role.Name))
        {
            userRoleViewModel.IsSelected = true;
        }
        else
        {
            userRoleViewModel.IsSelected = false;
        }

        model.Add(userRoleViewModel);
    }

    return View(model);
}

[HttpPost]
public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
{
    var role = await _roleManager.FindByIdAsync(roleId);

    if (role == null)
    {
        ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
        return View("NotFound");
    }

    for (int i = 0; i < model.Count; i++)
    {
        var user = await _userMangaer.FindByIdAsync(model[i].UserId);

        IdentityResult result = null;

        if (model[i].IsSelected && !(await _userMangaer.IsInRoleAsync(user, role.Name)))
        {
            result = await _userMangaer.AddToRoleAsync(user, role.Name);
        }
        else if (!model[i].IsSelected && await _userMangaer.IsInRoleAsync(user, role.Name))
        {
            result = await _userMangaer.RemoveFromRoleAsync(user, role.Name);
        }
        else
        {
            continue;
        }

        if (result.Succeeded)
        {
            if (i < (model.Count - 1))
                continue;
            else
                return RedirectToAction("EditRole", new { Id = roleId });
        }
    }

    return RedirectToAction("EditRole", new { Id = roleId });
}



    }
}