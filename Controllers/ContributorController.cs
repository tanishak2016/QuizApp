﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz_App.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace Quiz_App.Controllers
{
    public class ContributorController : Controller
    {
        db dbObj = new db();
        public IActionResult Index()
        {
            return View();
        }

        //display all contributors details
        [HttpGet]
        public IActionResult getContributor()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DataSet ds = dbObj.getContributor();
                    ViewBag.contributor = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        public IActionResult getContributorData()
        {
            return RedirectToAction("getContributor", "Contributor");
        }

        public IActionResult saveContributorData()
        {
            return RedirectToAction("saveContributor", "Contributor");
        }

        [HttpGet]
        public IActionResult saveContributor()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveContributor(contributor cont)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string res = dbObj.saveContributor(cont);
                    if (res == "Success")
                    {
                        TempData["msg"] = "Contributor Record saved successfully!";
                        ModelState.Clear();
                        cont.fullName = string.Empty;
                        cont.address = string.Empty;
                        cont.mobileNo = string.Empty;
                        cont.emailId = string.Empty;
                        cont.userName = string.Empty;
                        cont.password = string.Empty;
                        cont.contributor_createdBy = string.Empty;
                        cont.adminLocation = string.Empty;
                        return View(cont);
                    }
                    else if (res.Contains("Error") == true)
                    {
                        TempData["msg"] = res;
                        return View();
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

        //for Edit mode fetch data by id
        [HttpGet]
        public IActionResult updateContributor(int id)
        {
            contributor cont = null;
            try
            {
                if (ModelState.IsValid)
                {
                    cont = dbObj.getContributorById(id);
                    ViewBag.contributorById = cont;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View(cont);
        }

        [HttpPost]
        public IActionResult updateContributor(contributor cont)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbObj.updateContributor(cont);
                    return RedirectToAction("getContributorData", "Contributor");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return View(cont);
        }

        [HttpGet]
        public IActionResult deleteContributor(int? id)
        {
            contributor cont = null;
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    cont = dbObj.getContributorById(id);
                    ViewBag.delContById = cont;
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
            return RedirectToAction("getContributor", "contributor");
        }

    }
}
