using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class PasswordMapper : EntityMapper
    {
        UserMapper userMapper = new UserMapper();
        private const string BD_COL_ID = "ID";
        private const string BD_COL_UserID = "UserID";
        private const string BD_COL_Keyword = "Keyword";
        private const string BD_COL_ExpirationDate = "ExpirationDate";
        private const string BD_COL_Status = "Status";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PASS_PR" };

            var c = (Password)entity;
            operation.AddVarcharParam(BD_COL_UserID, c.UserID);
            operation.AddVarcharParam(BD_COL_Keyword, c.Keyword);
            operation.AddDateTimeParam(BD_COL_ExpirationDate, c.ExpirationDate);
            operation.AddVarcharParam(BD_COL_Status, c.Status);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "GET_PASSWORD_PR" };

            var c = (Password)entity;
            operation.AddVarcharParam(BD_COL_UserID, c.UserID);
            operation.AddVarcharParam(BD_COL_Keyword, c.Keyword);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PASSWORD_PR" };

            var c = (Password)entity;
            operation.AddVarcharParam(BD_COL_UserID, c.UserID);
            operation.AddVarcharParam(BD_COL_Keyword, c.Keyword);
            operation.AddDateTimeParam(BD_COL_ExpirationDate, c.ExpirationDate);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var password = new Password
            {
                
                UserID = GetStringValue(row, BD_COL_UserID),
                Keyword = GetStringValue(row, BD_COL_Keyword)
            };
            return password;
        }
    }
}
