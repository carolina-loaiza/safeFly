using DataAccess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class ContactUsMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_FIRSTNAME = "FIRSTNAME";
        private const string DB_COL_LASTNAME = "LASTNAME";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_COMMENT = "COMMENT";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CONTACTUS_PR" }; // -- CREATE -- Procedimiento de la base de datos

            var c = (ContactUs)entity;
            operation.AddVarcharParam(DB_COL_FIRSTNAME, c.FirstName);
            operation.AddVarcharParam(DB_COL_LASTNAME, c.LastName);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddVarcharParam(DB_COL_COMMENT, c.Comment);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CONTACTUS_PR" }; //  --  RETRIVE -- Procedimiento de la base de datos

            var c = (ContactUs)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CONTACTUS_PR" }; //  -- RETRIVE ALL --  Procedimiento de la base de datos             
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CONTACTUS_PR" }; //  -- UPDATE --  Procedimiento de la base de datos

            var c = (ContactUs)entity;

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CONTACTUS_PR" }; //  -- DELETE --  Procedimiento de la base de datos

            var c = (ContactUs)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)  // - INSERT -- 
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var contactus = BuildObject(row);
                lstResults.Add(contactus);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var contactus = new ContactUs
            {
                FirstName = GetStringValue(row, DB_COL_FIRSTNAME),
                LastName = GetStringValue(row, DB_COL_LASTNAME),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Comment = GetStringValue(row, DB_COL_COMMENT)
            };

            return contactus;
        }
    }
}
