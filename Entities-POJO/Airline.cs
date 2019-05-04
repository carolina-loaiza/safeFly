using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Airline : BaseEntity
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string BusinessName { get; set; }
        public string Admin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RepresentantLegal { get; set; }
        public DateTime InscriptionDate { get; set; }
        public string UrlLogo { get; set; }
        public string Approvement { get; set; }
        public string Status { get; set; }

        public Airline()
        {
        }

        public Airline(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3) {
                    ID = infoArray[0];
                    Name = infoArray[1];
                    BusinessName = infoArray[2];
                    Admin = infoArray[3];
                    Email = infoArray[4];
                    PhoneNumber = infoArray[5];
                    RepresentantLegal = infoArray[6];
                    InscriptionDate = DateTime.ParseExact(infoArray[7], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    UrlLogo = infoArray[8];
                    Approvement = infoArray[9];
                    Status = infoArray[10];
                    
              } else {
                    throw new Exception("Todos los valores son requeridos");
              }
       }
    }
}
