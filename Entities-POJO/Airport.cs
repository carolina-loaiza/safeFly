using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Airport : BaseEntity
    {
        public string LegalNumber { get; set; }
        public string NameAirport { get; set; }
        public string BusinessName { get; set; }
        public string Administrator { get; set; }
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Representative { get; set; }
        public string RepresentativeID { get; set; }
        public string Estado { get; set; }

        public Airport()
        {

        }
    }
}
