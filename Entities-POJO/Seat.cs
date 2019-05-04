using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Seat : BaseEntity
    {
        public string Id { get; set; }
        public string SeatNumber { get; set; }
        public string FlyNumber { get; set; }
        public char SeatClass { get; set; }
        public string Status { get; set; }

        public Seat()
        {

        }
    }
}
