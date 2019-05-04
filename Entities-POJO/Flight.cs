using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Flight : BaseEntity
    {
        public string FlyNumber { get; set; }
        public int SeatsQuantify { get; set; }
        public int FirstClassSeats { get; set; }
        public int BusinessClassSeats { get; set; }
        public int EconomicClassSeats { get; set; }
        public string Status { get; set; }

        public Flight()
        {

        }
    }
}
