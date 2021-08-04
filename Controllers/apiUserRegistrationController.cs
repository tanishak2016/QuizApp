using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Quiz_App.Models;
using Microsoft.Extensions.Configuration;
using System.IO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz_App.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class apiUserRegistrationController : ControllerBase
    {
        db dbobj = new db();
        // GET: api/<apiUserRegistration>

        [HttpGet]
        public List<apiUserRegistrationModel> DisplayUserRegistrationOld()
        {
            List<apiUserRegistrationModel> apiuserregist = new List<apiUserRegistrationModel>();
            try
            {
                if (ModelState.IsValid)
                {
                    apiuserregist = dbobj.apiUserRegistrationDisplay();//.ToString();

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return apiuserregist;
        }

        // GET api/<apiUserRegistration>/5
        [HttpGet("{id}")]
        public string GetByID(int id)
        {
            return "value";
        }

        // POST api/<apiUserRegistration>
        [HttpPost]
        public string SaveUserRegistrationOld(apiUserRegistrationModel userregistration)
        {
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    String result = dbobj.apiUserRegistrationSave(userregistration);
                    if (result == "Success")
                    {
                        message = "insert success";
                        ModelState.Clear();
                    }
                    else
                    {
                        message = "id already taken";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return message;
        }



        [HttpGet]
        public IActionResult DisplayUserRegistration()
        {
            ResponseFormat response = new ResponseFormat();
            response.ResponseID = System.Guid.NewGuid().ToString();
            List<apiUserRegistrationModel> apiuserregist = new List<apiUserRegistrationModel>();
            try
            {
                if (ModelState.IsValid)
                {
                    apiuserregist = dbobj.apiUserRegistrationDisplay();//.ToString();
                    response.IsSuccess = true;
                    response.Data = apiuserregist;
                }
            }
            catch (Exception ex)
            {
                //ex.Message.ToString();
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.ErrorCode = "500";
            }
            return Ok(response);
        }

        // POST api/<apiUserRegistration>
        [HttpPost]
        public IActionResult SaveUserRegistration(apiUserRegistrationModel userregistration)
        {

            ResponseFormat response = new ResponseFormat();
            response.ResponseID = System.Guid.NewGuid().ToString();
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    String result = dbobj.apiUserRegistrationSave(userregistration);
                    if (result == "Success")
                    {
                        message = "insert success";
                        response.IsSuccess = true;
                        response.Message = message;

                        ModelState.Clear();
                    }
                    else
                    {
                        message = "id already taken";
                        response.IsSuccess = false;
                        response.Message = message;
                        response.ErrorCode = "E500";
                    }
                }
            }
            catch (Exception ex)
            {
                //ex.Message.ToString();
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.ErrorCode = "500";
            }
            return Ok(response);
        }


        // PUT api/<apiUserRegistration>/5
        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult UpdateUserRegistration(apiUserRegistrationModel userregistration)
        {

            ResponseFormat response = new ResponseFormat();
            response.ResponseID = System.Guid.NewGuid().ToString();
            String message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    dbobj.apiUserRegistrationUpdate(userregistration);
                    message = "Update Success";
                    response.IsSuccess = true;
                    response.Message = message;
                    ModelState.Clear();
                }
                else
                {
                    response.IsSuccess = false;
                    response.ErrorCode = "E500";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.ErrorCode = "500";
            }
            return Ok(response);

        }

        // DELETE api/<apiUserRegistration>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUserRegistration(int id)
        {

            ResponseFormat response = new ResponseFormat();
            response.ResponseID = System.Guid.NewGuid().ToString();
            String message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    dbobj.apiUserRegistrationDelete(id);
                    message = "Delete Success";
                    response.IsSuccess = true;
                    response.Message = message;
                    ModelState.Clear();
                }
                else
                {
                    response.IsSuccess = false;
                    response.ErrorCode = "E500";

                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.ErrorCode = "500";
            }
            return Ok(response);


        }
    }
    }

