using DataAccess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class UserMapper : EntityMapper, ISqlStatements, IObjectMapper
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
        private const string DB_COL_ROLE = "Name";
        private const bool DB_COL_CHATBOT = false;
        private const bool DB_COL_SMSNOTIFICATION = false;
        private const bool DB_COL_EMAILNOTIFICATION = false;

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_USER_WITHOUT_ROLE_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            operation.AddVarcharParam(DB_COL_FIRSTNAME, c.FirstName);
            operation.AddVarcharParam(DB_COL_SECONDNAME, c.SecondName);
            operation.AddVarcharParam(DB_COL_LASTNAME1, c.LastName1);
            operation.AddVarcharParam(DB_COL_LASTNAME2, c.LastName2);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddVarcharParam(DB_COL_BIRTHDATE, c.BirthDate.ToString());
            operation.AddVarcharParam(DB_COL_PHONENUMBER, c.PhoneNumber);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_USER_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_USER_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_USER_PR" };

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
          //  operation.AddVarcharParam(DB_COL_CHATBOT, c.Chatbot);
         //   operation.AddVarcharParam(DB_COL_SMSNOTIFICATION, c.SMSNotification);
          //  operation.AddVarcharParam(DB_COL_EMAILNOTIFICATION, c.EmailNotification);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_USER_PR" };

            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }

        public SqlOperation GetActivarStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_USER_PR" };

            var c = (User)entity;

            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }

        public SqlOperation GetUserRoleStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "GET_USER_ROLE_PR" };

            var c = (User)entity;

            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
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
            var user = new User
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
                Chatbot= false,
                SMSNotification= false,
                EmailNotification = false
            };

            return user;
        }

        public BaseEntity BuildRole(Dictionary<string, object> row)
        {
            var user = new User
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
                Chatbot = false,
                SMSNotification = false,
                EmailNotification = false,
                RolName = GetStringValue(row, DB_COL_ROLE)
            };

            return user;
        }
    }
}
