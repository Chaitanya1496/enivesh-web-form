using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using enivesh_web_form.Models;
using enivesh_web_form.Services;
using enivesh_web_form.Constants;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace enivesh_web_form.Controllers
{
    public class PersonController : ApiController
    {
        public string GetPersonModel(int userID)
        {
            Dictionary<int, PersonalInformationModel> personalInformationModels = PersonalInformationService.GetPersonalInformation(userID);
            string jsonData = JsonConvert.SerializeObject(personalInformationModels);
            return jsonData;
        }

        public static void InsPersonalInformationModel(JToken data, int userID)
        {
            int count = 1;
            foreach (JToken item in data)
            {
                PersonalInformationModel personalInfoModel = PersonalInformationModel.populateModel(item, count, userID);
                PersonalInformationService.InsUpdPersonalInformation(AppConstant.insertOperation, personalInfoModel);
                count += 1;
            }
        }
    }
}
