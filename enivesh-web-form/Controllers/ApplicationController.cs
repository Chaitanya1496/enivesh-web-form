using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using enivesh_web_form.ErrorLog;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using enivesh_web_form.Services;
using enivesh_web_form.Models;

namespace enivesh_web_form.Controllers
{
    public class MyModel
    {
        public string webFormData { get; set; }
    }
    public class ApplicationController : ApiController
    {
        [EnableCors("*","*","*")]
        [System.Web.Http.Route("api/insertData")]
        [HttpPost]
        public string InsertData([FromBody] MyModel formData)
        {
            UserModel userModel = new UserModel();
            try
            {
                // First add user to master table
                userModel.userID = UserService.InsUser();
                //Newtonsoft.Json.Linq.JObject.Parse(key.key)["personalInfo"][0]["firstName"].ToString()
                JObject formObject = JObject.Parse(formData.webFormData);
                PersonController.InsPersonalInformationModel(formObject["personalInfo"], userModel.userID);
            }
            catch (Exception ex)
            {
                Log errorLog = new Log();
                errorLog.LogMessage(ex.Message);
            }
            return "false";
        }
    }
}
