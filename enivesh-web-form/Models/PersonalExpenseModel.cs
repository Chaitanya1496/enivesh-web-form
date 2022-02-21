using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using enivesh_web_form.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using enivesh_web_form.Constants;
using System.Data;

namespace enivesh_web_form.Models
{
    public class PersonalExpenseModel
    {
        public int userID { get; set; }
        public double rent { get; set; }
        public double groceries { get; set;}
        public double eating { get; set; }
        public double utilities { get; set; }
        public double phone { get; set; }
        public double gas { get; set; }
        public double automobileExpense { get; set; }
        public double recreation { get; set; }
        public double daycare { get; set; }
        public double gifts { get; set; }
        public double domesticHelp { get; set; }
        public double clothing { get; set; }
        public double homeMaintenance { get; set; }
        public double homeFurnishing { get; set; }
        public double childSupport { get; set; }
        public double alimony { get; set; }
        public double entertainment { get; set; }
        public double vacations { get; set; }
        public double hobbies { get; set; }
        public double gym { get; set; }
        public double subscription { get; set; }
        public double petExpense { get; set; }
        public double booksMovies { get; set; }
        public double cableTv { get; set; }
        public double internet { get; set; }
        public double haircuts { get; set; }
        public double miscelleneous { get; set; }

        public static string getData(int userID)
        {
            PersonalExpenseModel model = new PersonalExpenseModel();
            DataSet ds = LifeInsuranceService.getData(userID);
            getModel(ref model, ds, userID);
            return JsonConvert.SerializeObject(model);
        }

        public static void getModel(ref PersonalExpenseModel model, DataSet ds, int userID)
        {
            if (ds != null && ds.Tables[AppConstant.dsPersonalExpense] != null && ds.Tables[AppConstant.dsPersonalExpense].Rows.Count > 0)
            {
                foreach (DataRow data in ds.Tables[AppConstant.dsPersonalExpense].Rows)
                {
                    model.userID = userID;
                    model.rent = (double)data["Rent"];
                    model.groceries = (double)data["Groceries"];
                    model.eating = (double)data["Eating"];
                    model.utilities = (double)data["Utilities"];
                    model.phone = (double)data["Phone"];
                    model.gas = (double)data["Gas"];
                    model.automobileExpense = (double)data["AutomobileExpense"];
                    model.recreation = (double)data["Recreation"];
                    model.daycare = (double)data["DayCare"];
                    model.gifts = (double)data["Gifts"];
                    model.domesticHelp = (double)data["DomesticHelp"];
                    model.clothing = (double)data["Clothing"];
                    model.homeMaintenance = (double)data["HomeMaintenance"];
                    model.homeFurnishing = (double)data["HomeFurnishings"];
                    model.childSupport = (double)data["ChildSupport"];
                    model.alimony = (double)data["Alimony"];
                    model.entertainment = (double)data["Entertainment"];
                    model.vacations = (double)data["Vacations"];
                    model.hobbies = (double)data["Hobbies"];
                    model.gym = (double)data["Gym"];
                    model.subscription = (double)data["Subscriptions"];
                    model.petExpense = (double)data["PetExpense"];
                    model.booksMovies = (double)data["BooksMovies"];
                    model.cableTv = (double)data["CableTV"];
                    model.internet = (double)data["Internet"];
                    model.haircuts = (double)data["Haircuts"];
                    model.miscelleneous = (double)data["Miscelleneous"];
                }
            }
        }

        public static void insertData(JToken data, int userID)
        {
            PersonalExpenseModel model = new PersonalExpenseModel();
            populateModel(ref model, data, userID);
            PersonalExpenseService.insUpdPersonalExpense(AppConstant.insertOperation, model);
        }

        public static void populateModel(ref PersonalExpenseModel model, JToken data, int userID)
        {
            foreach (JToken item in data)
            {
                model.userID = userID;
                model.rent = (double)data["rentExpenses"];
                model.groceries = (double)data["groceryExpenses"];
                model.eating = (double)data["eatingOutExpenses"];
                model.utilities = (double)data["utilitiesExpenses"];
                model.phone = (double)data["mobileNetworkExpenses"];
                model.gas = (double)data["fuelExpenses"];
                model.automobileExpense = (double)data["automobiileMaintenanceExpenses"];
                model.recreation = (double)data["recreationExpenses"];
                model.daycare = (double)data["dayCareExpenses"];
                model.gifts = (double)data["giftExpenses"];
                model.domesticHelp = (double)data["domesticHelpExpenses"];
                model.clothing = (double)data["clothingExpenses"];
                model.homeMaintenance = (double)data["homeMaintenanceExpenses"];
                model.homeFurnishing = (double)data["homeFurnishingExpenses"];
                model.childSupport = (double)data["childSupportExpenses"];
                model.alimony = (double)data["alimonyExpenses"];
                model.entertainment = (double)data["entertainmentExpenses"];
                model.vacations = (double)data["vacationExpenses"];
                model.hobbies = (double)data["hobbiesExpenses"];
                model.gym = (double)data["gymMembershipExpenses"];
                model.subscription = (double)data["subscriptionExpenses"];
                model.petExpense = (double)data["petExpenses"];
                model.booksMovies = (double)data["booksMoviesExpenses"];
                model.cableTv = (double)data["tvExpenses"];
                model.internet = (double)data["internetExpenses"];
                model.haircuts = (double)data["beautyExpenses"];
                model.miscelleneous = (double)data["miscellaneousExpenses"];
            }
        }
    }
}