using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Quiz_App.Areas.Main.Models;
using Microsoft.AspNetCore.Authorization;

namespace Quiz_App.Areas.Main.Controllers
{
   [Area("Main")]
    public class NoticeBoardController : Controller
    {
        DAL dbobj = new DAL();
        string msg = string.Empty;

        GeoInfoProvider geoInfoProvider = new GeoInfoProvider();
        GeoInfoViewModel geoInfoModel = new GeoInfoViewModel();



        public IActionResult NoticeBoardData()
        {

            return RedirectToAction("NoticeBoardSave", "NoticeBoard");
            //return View();
        }

        [HttpGet]
        public async Task<IActionResult> NoticeBoardSave()
        {

            geoInfoModel = await geoInfoProvider.GetGeoInfo();
            contributor cont = new contributor();
            ViewBag.LocationOfAdmin = geoInfoModel.City + ", " + geoInfoModel.RegionName + ", " + geoInfoModel.CountryName;
            TempData["LocationOfAdmin"] = ViewBag.LocationOfAdmin;
            return View();
        }
        
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NoticeBoardSave(NoticeBoardProperties nb)
        {
            
            try
            {
                if(ModelState.IsValid)
                {
                    
                    String username = TempData["username"].ToString();
                    String res = dbobj.apiNoticeBoardSave(nb,username);
                    if(res== "Success")
                    {
                        TempData["msg"] = res;
                        ModelState.Clear();
                        nb.NoticeTitle = string.Empty;
                        nb.NoticeDescription = string.Empty;
                        nb.NoticeDateExpiry = string.Empty;
                        return View(nb);
                    }
                    else
                    {
                        TempData["msg"] = "Failure";
                        return View();
                    }
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            
            return View();
        }


        [HttpGet]
        public IActionResult NoticeBoardDisplay()
        {

            DataSet ds = new DataSet();
            try
            {
                if(ModelState.IsValid)
                {
                    ds = dbobj.apiNoticeBoardDisplay();
                    ViewBag.Notice = ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult NoticeBoardUpdate(int id)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    DataSet ds = new DataSet();
                    ds = dbobj.apiNoticeBoardDisplayByID(id);
                    ViewBag.NoticeBoardById = ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NoticeBoardUpdate(NoticeBoardProperties nb)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    dbobj.apiNoticeBoardUpdate(nb);
                    return RedirectToAction("NoticeBoardDisplay", "NoticeBoard");

                    //string res = dbobj.normalAdminUpdate(na);
                    //TempData["msg"] = res;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return View(nb);
        }

        public IActionResult NoticeBoardDelete(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    dbobj.apiNoticeBoardDelete(id);
                    TempData["msg"] = "Deleted Successfuly";

                }

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;

            }
            return RedirectToAction("NoticeBoardDisplay", "NoticeBoard");
        }


        public IActionResult NoticeBoardReject()
        {
            return RedirectToAction("NoticeBoardDisplay", "NoticeBoard");

        }

    }
}
