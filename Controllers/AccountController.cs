using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Quiz_App.Models;

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
                return RedirectToAction("createNormalAdmin", "Account");
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
                    adminDateCreate = dr["DateCreated"].ToString(),
                    adminDateModified = dr["DateModified"].ToString()
                });

            }

            return View(list);
        }
        [HttpGet]
        public IActionResult createNormalAdmin()
        {


            return View();
        }
        [HttpPost]
        public IActionResult createNormalAdmin([Bind] normalAdmin na)
        {

            try
            {
                na.flag = "insert";
                dbobj.normalAdminSaveUpdate(na, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            //return View();
            return RedirectToAction("createNormalAdmin", "Home");

        }

    }
}
