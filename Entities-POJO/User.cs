using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class User : BaseEntity
    {
        public string ID { get; set; } 
        public string FirstName { get; set; } 
        public string SecondName { get; set; } 
        public string LastName1 { get; set; } 
        public string LastName2 { get; set; } 
        public string Email { get; set; } 
        public DateTime BirthDate { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Status { get; set; } 
        public bool Chatbot { get; set; } 
        public bool SMSNotification { get; set; } 
        public bool EmailNotification { get; set; } 
        public string RolName { get; set; }
        public string Password { get; set; }

        public User()
        {

        }

        //public User(string[] infoArray)
        //{
        //    if (infoArray != null && infoArray.Length >= 4)
        //    {
        //        ID = infoArray[0];
        //        FirstName = infoArray[1];
        //        SecondName = infoArray[2];
        //        LastName1 = infoArray[3];
        //        LastName2 = infoArray[4];
        //        Email = infoArray[5];
        //        BirthDate = DateTime.ParseExact(infoArray[6], "dd-MM-yyyy", CultureInfo.InvariantCulture);
        //        PhoneNumber = infoArray[7];
        //        Status = infoArray[8];
        //        Chatbot = infoArray[9];
        //        SMSNotification = infoArray[10];
        //        EmailNotification = infoArray[11];


        //        var age = 0;
        //        if (Int32.TryParse(infoArray[3], out age))
        //            Age = age;
        //        else
        //            throw new Exception("Age must be a number");
        //    }
        //    else
        //    {
        //        throw new Exception("All values are require[id,name,last_name,age]");
        //    }

        //}

    }
}