using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz_App.Models;
using System.Data;
using System.Data.SqlClient;

namespace Quiz_App.Controllers
{
    public class ContributorController : Controller
    {
        db dbObj = new db();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult getContributor()
        {
            try
            {
                DataSet ds = dbObj.getContributor();
                ViewBag.contributor = ds.Tables[0];
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        public IActionResult ContributorData()
        {
            return RedirectToAction("getContributor", "Contributor");
        }

        [HttpGet]
        public IActionResult getContributorById(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataSet ds = dbObj.getContributorById(id);
                    ViewBag.adminbyid = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult saveContributor(contributor cont)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbObj.saveContributor(cont);
                    if (res == "Success")
                    {
                        TempData["msg"] = res;
                        ModelState.Clear();
                        cont.fullName = string.Empty;
                        cont.address = string.Empty;
                        cont.mobileNo = string.Empty;
                        cont.emailId = string.Empty;
                        cont.userName = string.Empty;
                        cont.password = string.Empty;
                        cont.adminLocation = string.Empty;
                        return View(cont);
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
            return View(cont);
            // return RedirectToAction("normalAdminDisplay", "Account");
        }

        [HttpPost]
        public IActionResult updateContributor(contributor cont)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbObj.updateContributor(cont);
                    return RedirectToAction("getContributor", "Contributor");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return View(cont);
        }

        [HttpPost]
        public IActionResult deleteContributor(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbObj.deleteContributor(id);
                    TempData["msg"] = "Deleted Successfuly";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("normalAdminDisplay", "Account");
        }

    }
}
