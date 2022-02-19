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
using enivesh_web_form.Constants;
using Newtonsoft.Json;
using System.Threading;

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

                // Insert Personal Information
                PersonalInformationModel.insertData(formObject[AppConstant.formPersonalInformation], userModel.userID);
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            return "false";
        }
        [EnableCors("*", "*", "*")]
        [System.Web.Http.Route("api/getData")]
        [HttpGet]
        public string GetData([FromUri] int userID)
        {
            Dictionary<string, string> userData = new Dictionary<string, string>();
            string userJsonData = string.Empty;
            try
            {
                // Fetch personal information
                string personalInformationData = PersonalInformationModel.getData(userID);
                userData.Add(AppConstant.formPersonalInformation, personalInformationData);

                // Fetch assets liquid information
                string assetsLiquidData = AssetsLiquidModel.getData(userID);
                userData.Add(AppConstant.formLiquidAssets, assetsLiquidData);

                userJsonData = JsonConvert.SerializeObject(personalInformationData);
            }
            catch (Exception ex)
            {
                Log.LogMessage(ex.Message);
            }
            return userJsonData;
        }
    }
}
