using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Password : BaseEntity
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Keyword { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }

        public Password(){

        }

        public Password(string UserID, string Keyword, DateTime ExpirationDate, string Status) {

            this.UserID = UserID;
            this.Keyword = Keyword;
            this.ExpirationDate = ExpirationDate;
            this.Status = Status;

        }


    }
}
