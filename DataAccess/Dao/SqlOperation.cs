﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        public void AddVarcharParam(string paramName, string paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.VarChar)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddCharParam(string paramName, char paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Char)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Int)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDecimalParam(string paramName, decimal paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDateTimeParam(string paramName, DateTime paramValue)
        {
            string sqlDate = paramValue.ToString("yyyy-MM-dd HH:mm:ss");

            var param = new SqlParameter("@P_" + paramName, SqlDbType.DateTime)
            {
                Value = sqlDate
            };

            Parameters.Add(param);
        }
        
        public void AddDateTimeParam(string paramName, string paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.DateTime)
            {
                Value = DateTime.ParseExact(paramValue, "dd/MM/yyyy", null)
            };
            Parameters.Add(param);
        }



        public void AddBolParam(string paramName, Boolean paramValue)
        {
            var param = new SqlParameter("@P_" + paramName, SqlDbType.Char)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

    }
}
