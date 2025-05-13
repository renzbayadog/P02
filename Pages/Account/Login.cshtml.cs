using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using codegen.Data;
//using codegen.Extensions.Identity;
using codegen.Helpers;
//using codegen.Interface.Identity;
//using codegen.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace app.Pages.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username is required")]
        [DisplayName("User Name:")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password:")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class LoginModel : PageModel
    {
        //private readonly AppDB1Context _context;
        //private readonly SignInManager<User> _signInManager;
        //private readonly UserManager<User> _userManager;
        //private readonly IMenuManager _menuManager;
        //private readonly IConfiguration _configuration;

        //public LoginModel(AppDB1Context context, 
        //                  SignInManager<User> signInManager,
        //                  UserManager<User> userManager,
        //                  IMenuManager menuManager, 
        //                  IConfiguration configuration)
        //{
        //    _context = context;
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //    _menuManager = menuManager;
        //    _configuration = configuration;
        //}


        [BindProperty]
        public LoginVM Login { get; set; }

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public IActionResult OnGet()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return Redirect("/");
            //}

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
                //User user = await _userManager.FindByNameAsync(Login.UserName);

                //if (user != null)
                //{
                //    if (user.IsDeleted == true)
                //    {
                //        Message = "Your account is disabled. Contact the system administrator.";

                //        Login = new LoginVM();
                //        return Page();
                //    }

                //    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(Login.UserName, Login.Password, Login.RememberMe, false);

                //    if (!result.Succeeded)
                //    {
                //        Message = "Username or Password is incorrect";

                //        Login = new LoginVM();
                //        return Page();
                //    }

                //    IdentityUserRole<int> userRole = _context.UserRoles.Where(u => u.UserId == user.Id).FirstOrDefault();
                //    if (userRole == null)
                //    {
                //        Message = "Role not assigned. Contact the system administrator.";

                //        Login = new LoginVM();
                //        return Page();
                //    }

                //    Role role = _context.Roles.Where(u => u.Id == userRole.RoleId).FirstOrDefault();

                //    // Get all root menu items associated with the role
                //    List<Menu> listMenuId = await _context.RoleMenus.Where(u => u.RoleId == role.Id)
                //                                            .Select(u => new Menu { MenuId = u.MenuId }).ToListAsync();


                //    HttpContext.Session.SetObject("UserFullName", $"{user.FirstName} {user.LastName}");
                //    HttpContext.Session.SetObject("UserId", user.Id);
                //    HttpContext.Session.SetObject("RoleId", role.Id);
                //    HttpContext.Session.SetObject("UserRole", role.Name);
                //    HttpContext.Session.SetObject("UserRoleDescription", role.RoleDescription);
                //    HttpContext.Session.SetObject("UserName", user.UserName);
                //    HttpContext.Session.SetObject("Menu", _menuManager.GenerateMenuForCurrUser(role.Id));

                //    switch (role.Name)
                //    {
                //        case "CC":
                //            HttpContext.Session.SetObject("Summary", "Sales Summary");
                //            break;
                //        case "RBM":
                //            HttpContext.Session.SetObject("Summary", "Sales Summary");
                //            break;
                //        default:
                //            HttpContext.Session.SetObject("Summary", "National");
                //            break;
                //    }

                    //var LoginVM = new LoginVM();
                    //LoginVM.Email = user.Email;
                    //LoginVM.UserName = Login.UserName;
                    //LoginVM.Password = Login.Password; 

                    //var authService = new AuthServices(_userManager, _context, _configuration);
                    //var resultToken = await authService.GetTokenAsync(LoginVM);
                    //AppHelper.SetRefreshTokenInCookie(resultToken.RefreshToken);

                    return Redirect("/");
                //}
                //else
                //{
                //    Message = "Your account doesn't exist in our database.";

                //    Login = new LoginVM();
                //    return Page();
                //}
        }

    }
}