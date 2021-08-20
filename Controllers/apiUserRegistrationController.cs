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
                    apiuserregist = dbobj.getApiUserRegistration();//.ToString();

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
                    String result = dbobj.saveApiUserRegistration(userregistration);
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
                    apiuserregist = dbobj.getApiUserRegistration();//.ToString();
                    response.IsSuccess = true;
                    response.Data = apiuserregist;
                    response.StatusCode = 200;
                }
            }
            catch (Exception ex)
            {
                //ex.Message.ToString();
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.StatusCode = 500;
            }
            return Ok(response);
        }

        // POST api/<apiUserRegistration>
        [HttpPost]
        public IActionResult SaveUserRegistration(apiUserRegistrationModel userregistration)
        {
            ResponseFormat response = new ResponseFormat();
            //response.ResponseID = System.Guid.NewGuid().ToString();
            string message = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    String result = dbobj.saveApiUserRegistration(userregistration);
                    if (result == "Success")
                    {
                        message = "insert success";
                        response.IsSuccess = true;
                        response.Message = message;
                        response.Data = userregistration;
                        response.StatusCode = 200;

                        ModelState.Clear();
                    }
                    else
                    {
                        message = "id already taken";
                        response.IsSuccess = false;
                        response.Message = message;
                        response.StatusCode = 500;
                    }
                }
            }
            catch (Exception ex)
            {
                //ex.Message.ToString();
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.StatusCode = 500;
            }
            return Ok(response);
        }

        // PUT api/<apiUserRegistration>/5
        //[HttpPut("{id}")]
        [HttpPut]
        public IActionResult UpdateUserRegistration(apiUserRegistrationModel userregistration)
        {
            ResponseFormat response = new ResponseFormat();
            //response.ResponseID = System.Guid.NewGuid().ToString();
            String message = string.Empty;
            try
            {
                if (userregistration.id == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Id not found";
                    response.StatusCode = 404;

                    return NotFound(response);
                }
                if (ModelState.IsValid)
                {
                    dbobj.updateApiUserRegistration(userregistration);
                    message = "Update Success";
                    response.IsSuccess = true;
                    response.Message = message;
                    response.Data = userregistration;
                    response.StatusCode = 200;

                    ModelState.Clear();
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Update Fail";
                    response.StatusCode = 500;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.StatusCode = 500;
            }
            return Ok(response);
        }

        // DELETE api/<apiUserRegistration>/5
        //[HttpDelete("{id}")]
        [HttpDelete]
        public IActionResult DeleteUserRegistration(int? id)
        {
            ResponseFormat response = new ResponseFormat();
            //response.ResponseID = System.Guid.NewGuid().ToString();
            String message = string.Empty;
            try
            {
                if (id == null || id == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Id not found";
                    response.StatusCode = 404;

                    return NotFound(response);
                }
                if (ModelState.IsValid)
                {
                    dbobj.deleteApiUserRegistration(id);
                    message = "Delete Success";
                    response.IsSuccess = true;
                    response.Message = message;
                    response.StatusCode = 200;

                    ModelState.Clear();
                }
                else
                {
                    response.IsSuccess = false;
                    response.StatusCode = 500;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                response.StatusCode = 500;
            }
            return Ok(response);
        }


    }
}

