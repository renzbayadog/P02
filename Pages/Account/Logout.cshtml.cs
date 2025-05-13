using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using codegen.Extensions.Identity;
using codegen.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace app.Pages.Account
{
    public class LogoutModel : PageModel
    {
        //private readonly SignInManager<User> _signInManager;

        //public LogoutModel(SignInManager<User> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

        public async Task<IActionResult> OnGet()
        {
        //    HttpContext.Session.SetObject("UserId", "");
        //    HttpContext.Session.SetObject("RoleId", "");
        //    HttpContext.Session.SetObject("UserRole", "");
        //    HttpContext.Session.SetObject("UserName", "");

        //    await _signInManager.SignOutAsync();

            return RedirectToPage("Login");
        }
    }
}