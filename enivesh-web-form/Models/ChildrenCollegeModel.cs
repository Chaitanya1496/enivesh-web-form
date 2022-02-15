using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enivesh_web_form.Models
{
    public class ChildrenCollegeModel
    {
        public int userID { get; set; }
        public int childrenCount { get; set; }
        public string name { get; set; }
        public DateTime dob { get; set; }
        public int yearOfCollege { get; set; }
        public double courseFees { get; set; }
    }
}