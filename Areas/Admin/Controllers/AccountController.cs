using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Quiz_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Session;
using Quiz_App.Areas.Admin.Models;
using Quiz_App.Areas.Models;

namespace Quiz_App.Areas.Controllers
{
    
    [Area("Admin")]    
    public class AccountController : Controller
    {
        
         DAL dbobj = new DAL();
        
        String msg;

        public IActionResult Index()
        {


          return View();
        }

        [HttpGet]
        public async Task<IActionResult> normalAdminLogout()
        {


            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("normalAdminLogin", "Account");

            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> SuperAdminLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SuperAdmin", "Account");
        }

        [HttpGet]
        public IActionResult SuperAdmin()
        {

           // return RedirectToAction("normalAdminSaveUpdate", "Account");

           return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SuperAdmin(SuperAdmin_Login sa)
        {

            int res = dbobj.LoginCheck(sa);
            if (res == 1)
            {
                // TempData["msg"] = "You are Welcome to admin section";
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,sa.supAdminPassword)
                };
                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                var props = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

                return RedirectToAction("normalAdminSaveUpdate", "Account");
            }
            else
            {
                TempData["msg"] = "Super Admin password  is wrong. !";
            }

            return View();
        }

        [HttpGet]
        public IActionResult normalAdminLogin()
        {
            return View();
            

        }

        [AllowAnonymous]
        [HttpPost]
        public  async Task<IActionResult> normalAdminLogin(SuperAdmin_Login sa,string ReturnUrl)
        {       
           
             int res = dbobj.normalAdminLoginCheck(sa);
            if (res == -1)
            {

                TempData["msg"] = "Wrong User Name!";
                // return RedirectToAction("normalAdminSaveUpdate", "Account");            
                
            }
            if(res==-2)
            {
                TempData["msg"] = "Wrong Password";
            }
            if(res==1)
            {
                String username = string.Empty;
                username = sa.normalAdminUserName;
                 TempData["username"] = username;
                ViewBag.user = username;


                

                
               
               // HttpContext.Current.Session.Add("UserFullName", username);
                

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,sa.normalAdminUserName)
                };
                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimsIdentity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();                
                return RedirectToAction("NoticeBoardSave", "NoticeBoard", new {area="Main"});
                
            }
            
            return View();
        }

      
        [HttpGet]
        public IActionResult normalAdminSaveUpdate()

        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult normalAdminSaveUpdate( [Bind] normalAdmin na)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbobj.normalAdminSaveUpdate(na);
                    if (res== "Success") { 
                    TempData["msg"] = res;
                    ModelState.Clear();
                    na.adminName = string.Empty;
                    na.adminMobile = string.Empty;
                    na.adminUserName = string.Empty;
                    na.adminUserPassword = string.Empty;
                     return View(na);
                    }
                    else
                    {

                        TempData["msg"] = "This User ID already exists. Try with another.";
                        return View();
                    }


                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
               
            }
            
             return View(na);
           // return RedirectToAction("normalAdminDisplay", "Account");

        }

        [HttpGet]
        public IActionResult normalAdminDisplay()
        {

            try
            {
                if(ModelState.IsValid)
                {

                    DataSet ds = dbobj.normalAdminDisplay();
                    ViewBag.emp = ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        public IActionResult NormalAdminData()
        {

            return RedirectToAction("normalAdminDisplay", "Account");
            //return View();
        }
        [HttpGet]
        public IActionResult normalAdminUpdate(int id)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    DataSet ds = dbobj.normalAdminDisplayByID(id);
                    ViewBag.adminbyid = ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult normalAdminUpdate(normalAdmin na)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    dbobj.normalAdminUpdate(na);
                    return RedirectToAction("normalAdminDisplay", "Account");

                    //string res = dbobj.normalAdminUpdate(na);
                    //TempData["msg"] = res;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return View(na);
        }
        public IActionResult normalAdminDelete(int id)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    dbobj.normalAdminDelete(id);
                    TempData["msg"] = "Deleted Successfuly";
                    
                }

            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return RedirectToAction("normalAdminDisplay", "Account");

        }

       


    }
}
