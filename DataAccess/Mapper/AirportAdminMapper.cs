using DataAccess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class AirportAdminMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FIRSTNAME = "FirstName";
        private const string DB_COL_SECONDNAME = "SecondName";
        private const string DB_COL_LASTNAME1 = "LastName1";
        private const string DB_COL_LASTNAME2 = "LastName2";
        private const string DB_COL_EMAIL = "Email";
        private const string DB_COL_BIRTHDATE = "BirthDate";
        private const string DB_COL_PHONENUMBER = "PhoneNumber";
        private const string DB_COL_STATUS = "Status";
        private const bool DB_COL_CHATBOT = false;
        private const bool DB_COL_SMSNOTIFICATION = false;
        private const bool DB_COL_EMAILNOTIFICATION = false;
        private const string DB_COL_NAMEAIRPORT = "NAMEAIRPORT";
       
        //private const string DB_COL_USERID = "USERID";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_AIRPORTADMIN_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            operation.AddVarcharParam(DB_COL_FIRSTNAME, c.FirstName);
            operation.AddVarcharParam(DB_COL_SECONDNAME, c.SecondName);
            operation.AddVarcharParam(DB_COL_LASTNAME1, c.LastName1);
            operation.AddVarcharParam(DB_COL_LASTNAME2, c.LastName2);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddVarcharParam(DB_COL_BIRTHDATE, c.BirthDate.ToString());
            operation.AddVarcharParam(DB_COL_PHONENUMBER, c.PhoneNumber);
          //  operation.AddVarcharParam(DB_COL_STATUS, c.Status);
         //  operation.AddVarcharParam(DB_COL_NAMEAIRPORT, c.NameAirport);

         //   operation.AddBolParam(DB_COL_CHATBOT, true);
         //   operation.AddBolParam(DB_COL_SMSNOTIFICATION, true);
          //  operation.AddBolParam(DB_COL_EMAILNOTIFICATION, true);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_AIRPORTADMIN_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_AIRPORTADMIN_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_AIRPORTADMIN_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            operation.AddVarcharParam(DB_COL_FIRSTNAME, c.FirstName);
            operation.AddVarcharParam(DB_COL_SECONDNAME, c.SecondName);
            operation.AddVarcharParam(DB_COL_LASTNAME1, c.LastName1);
            operation.AddVarcharParam(DB_COL_LASTNAME2, c.LastName2);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddVarcharParam(DB_COL_BIRTHDATE, c.BirthDate.ToString());
            operation.AddVarcharParam(DB_COL_PHONENUMBER, c.PhoneNumber);
            operation.AddVarcharParam(DB_COL_STATUS, c.Status);
           // operation.AddVarcharParam(DB_COL_NAMEAIRPORT, c.NameAirport);
          //  operation.AddBolParam(DB_COL_CHATBOT, true);
           // operation.AddBolParam(DB_COL_SMSNOTIFICATION, true);
           // operation.AddBolParam(DB_COL_EMAILNOTIFICATION, true);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_AIRPORTADMIN_PR" };

            var c = (Administrator)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
              
                var user = BuildObject(row);
                lstResults.Add(user);

            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {


             
        // var user = new User
        var user = new Administrator

            {
                ID = GetStringValue(row, DB_COL_ID),
                FirstName = GetStringValue(row, DB_COL_FIRSTNAME),
                SecondName = GetStringValue(row, DB_COL_SECONDNAME),
                LastName1 = GetStringValue(row, DB_COL_LASTNAME1),
                LastName2 = GetStringValue(row, DB_COL_LASTNAME2),
                Email = GetStringValue(row, DB_COL_EMAIL),
                BirthDate = GetDateValue(row, DB_COL_BIRTHDATE),
                PhoneNumber = GetStringValue(row, DB_COL_PHONENUMBER),
                Status = GetStringValue(row, DB_COL_STATUS),
                NameAirport = GetStringValue(row, DB_COL_NAMEAIRPORT)
             
             //   Chatbot=GetStringValue(row, DB_COL_CHATBOT),
              //  SMSNotification=GetStringValue(row, DB_COL_SMSNOTIFICATION),
               // EmailNotification = GetStringValue(row, DB_COL_EMAILNOTIFICATION)
            };

            return user;
        }

    }
}
