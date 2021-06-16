using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Quiz_App.Models;
using Microsoft.AspNetCore.Http;

namespace Quiz_App.Controllers
{
    public class AccountController : Controller
    {
        db dbobj = new db();
        String msg;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SuperAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SuperAdminCheck(SuperAdmin_Login sa)
        {

            int res = dbobj.LoginCheck(sa);
            if (res == 1)
            {
                // TempData["msg"] = "You are Welcome to admin section";
                return RedirectToAction("normalAdminSaveUpdate", "Account");
            }
            else
            {
                TempData["msg"] = "Super Admin password  is wrong. !";
            }

            return View();
        }

        [HttpGet]
        public IActionResult getNormalAdmin()
        {

            normalAdmin norAdmin = new normalAdmin();
            norAdmin.flag = "get";
            DataSet ds = dbobj.normalAdminGet(norAdmin, out msg);
            List<normalAdmin> list = new List<normalAdmin>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new normalAdmin
                {
                    adminID = Convert.ToInt32(dr["AdminID"]),
                    adminUserName = dr["AdminUserName"].ToString(),
                    adminUserPassword = dr["AdminUserPassword"].ToString(),
                    //adminDateCreate = dr["DateCreated"].ToString(),
                    //adminDateModified = dr["DateModified"].ToString()
                });

            }

            return View(list);
        }
        [HttpGet]
        public IActionResult normalAdminSaveUpdate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult normalAdminSaveUpdate(IFormCollection fc)
        {
            
            normalAdmin na = new normalAdmin();
            na.adminName = fc["name"];
            na.adminMobile = fc["phone"];
            na.adminUserName = fc["email"];
            na.adminUserPassword = fc["password"];
            na.adminDateCreate = DateTime.Now;
            dbobj.normalAdminSaveUpdate(na);
            TempData["msg"] = "Record Inserted Successfuly";
            return View();

        }

    }
}
