using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class BusinessPremises : BaseEntity
    {
        public int ID { get; set; }
        public string AirportID { get; set; }
        public decimal AlquilerAmount { get; set; }
        public string Description { get; set; }
        public string Tenant { get; set; }
        public string TenantID { get; set; }
        public string Phone { get; set; }
        public decimal Area { get; set; }
        public int ComerceNumber { get; set; }
        public string Status { get; set; }

        public BusinessPremises()
        {

        }
    }
}
