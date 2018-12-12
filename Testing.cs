using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ePassport_Framework
{
    class Testing
    {
        static void Main(string[] args)
        {

            User_data something = new User_data();

            
            string Surname = "Johnson";
            string Name = "Nathat";
            var Date_of_Birth = new DateTime(1992, 3, 3).ToString("yyyyMMddHHmmss"); //tostringthisshit YYYYMMddTHH:mm:ss
            string Sex = "male";
            var issue_date = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            var issue_date_format = DateTime.UtcNow;
            var expiry_date = issue_date_format.AddMonths(12).ToString("yyyyMMddHHmmss"); //AddMonths(12); //Do .AddYears(foo) to add a year instead, foo should be made into a different variable. 
            string external_ID_number = "1234";
            string internal_ID_number = Date_of_Birth.ToString() + external_ID_number;
            string Authorized_by = "Admin";

            something.Serialize_json(Surname, Name, Date_of_Birth, Sex, issue_date, expiry_date, internal_ID_number, external_ID_number, Authorized_by);
            

            //unecessary message 
            //another unecessary change
        }
    }
}
