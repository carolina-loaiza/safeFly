using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public abstract class EntityMapper
    {

        protected string GetStringValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is string)
                return (string) val;

            return "";
        }

        protected char GetCharValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            var p = '-';
            if (dic.ContainsKey(attName) && val is string)
                p = Convert.ToChar(val);
            return p;
        }

        protected int GetIntValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is int || val is decimal))
                  return (int)val;

            //return 0;
            return -1;
        }

        protected decimal GetDecimalValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && (val is int || val is decimal))
                return (decimal)dic[attName];

            //return 0;
            return -1;
        }

         protected DateTime GetDateValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is DateTime)
                return (DateTime)dic[attName];

            return DateTime.Now;
        }

        protected Boolean GetBooleanValue(Dictionary<string, object> dic, string attName)
        {
            var val = dic[attName];
            if (dic.ContainsKey(attName) && val is bool)
                return (bool)dic[attName];

            return false;
        }
    }
}
