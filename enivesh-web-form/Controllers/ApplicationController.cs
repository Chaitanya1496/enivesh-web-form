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
    public class ApplicationController : ApiController
    {
        [EnableCors("*","*","*")]
        [System.Web.Http.Route("api/insertData")]
        [HttpPost]
        public string InsertData([FromBody] RequestDataModel webFormData)
        {
            UserModel userModel = new UserModel();
            try
            {
                // First add user to master table and extract the latest entered data
                userModel.userID = UserService.InsUser();

                JObject formObject = JObject.Parse(webFormData.webFormData);
                PersonController.InsPersonalInformationModel(formObject["personalInfo"], userModel.userID);
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            return "false";
        }
    }
}
