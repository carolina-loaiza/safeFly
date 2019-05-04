using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Schedule : BaseEntity
    {
        public int Id { get; set; }
        public string FlyNumber { get; set; }
        public string Aproovement { get; set; }
        public string Gate { get; set; }
        public string Destiny { get; set; }
        public string Departure { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArriveDate { get; set; }
    }
}
