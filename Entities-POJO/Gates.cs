using System;
using System.Globalization;

namespace Entities_POJO
{
    public class Gates : BaseEntity
    {
        public int ID { get; set; }
        public string AirportID { get; set; }
        public string GateCode { get; set; }
        public string Status { get; set; }
    }
}
