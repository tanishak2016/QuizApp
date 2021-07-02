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
        public List<apiUserRegistrationModel> DisplayUserRegistration()
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
        public void SaveUserRegistration([FromBody] apiUserRegistrationModel userregistration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    String result = dbobj.apiUserRegistrationSave(userregistration);
                    if (result == "Success")
                    {
                        String msg = "insert success";
                        ModelState.Clear();
                    }
                    else
                    {
                        String err = "id elready taken";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        // PUT api/<apiUserRegistration>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<apiUserRegistration>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
