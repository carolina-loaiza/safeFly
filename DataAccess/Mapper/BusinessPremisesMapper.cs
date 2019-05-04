using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class BusinessPremisesMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        public string BD_COL_ID = "ID";
        public string BD_COL_AirportID = "AirportID";
        public string BD_COL_AlquilerAmount = "AlquilerAmount";
        public string BD_COL_Description = "Description";
        public string BD_COL_Tenant = "Tenant";
        public string BD_COL_TenantID = "TenantID";
        public string BD_COL_Phone = "Phone";
        public string BD_COL_Area = "Area";
        public string BD_COL_ComerceNumber = "ComerceNumber";
        public string BD_COL_Status = "Status";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_BUSINESSPREMISES_PR" };

            var a = (BusinessPremises)entity;

            operation.AddIntParam(BD_COL_ID, a.ID);
            operation.AddVarcharParam(BD_COL_AirportID, a.AirportID);
            operation.AddDecimalParam(BD_COL_AlquilerAmount, a.AlquilerAmount);
            operation.AddVarcharParam(BD_COL_Description, a.Description);
            operation.AddVarcharParam(BD_COL_Tenant, a.Tenant);
            operation.AddVarcharParam(BD_COL_TenantID, a.TenantID);
            operation.AddVarcharParam(BD_COL_Phone, a.Phone);
            operation.AddDecimalParam(BD_COL_Area, a.Area);
            operation.AddIntParam(BD_COL_ComerceNumber, a.ComerceNumber);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_BUSINESSPREMISES_PR" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_BUSINESSPREMISES_PR" };

            var a = (BusinessPremises)entity;

            operation.AddIntParam(BD_COL_ID, a.ID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_BUSINESSPREMISES_PR" };

            var a = (BusinessPremises)entity;

            operation.AddIntParam(BD_COL_ID, a.ID);
            operation.AddVarcharParam(BD_COL_AirportID, a.AirportID);
            operation.AddDecimalParam(BD_COL_AlquilerAmount, a.AlquilerAmount);
            operation.AddVarcharParam(BD_COL_Description, a.Description);
            operation.AddVarcharParam(BD_COL_Tenant, a.Tenant);
            operation.AddVarcharParam(BD_COL_TenantID, a.TenantID);
            operation.AddVarcharParam(BD_COL_Phone, a.Phone);
            operation.AddDecimalParam(BD_COL_Area, a.Area);
            operation.AddIntParam(BD_COL_ComerceNumber, a.ComerceNumber);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_BUSINESSPREMISES_PR" };

            var a = (BusinessPremises)entity;

            operation.AddIntParam(BD_COL_ID, a.ID);
            return operation;
        }

        public SqlOperation GetActivarStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_BUSINESSPREMISES_PR" };

            var a = (BusinessPremises)entity;

            operation.AddIntParam(BD_COL_ID, a.ID);
            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var business = new BusinessPremises
            {
                ID = GetIntValue(row, BD_COL_ID),
                AirportID = GetStringValue(row, BD_COL_AirportID),
                AlquilerAmount = GetDecimalValue(row, BD_COL_AlquilerAmount),
                Description = GetStringValue(row, BD_COL_Description),
                Tenant = GetStringValue(row, BD_COL_Tenant),
                TenantID = GetStringValue(row, BD_COL_TenantID),
                Phone = GetStringValue(row, BD_COL_Phone),
                Area = GetDecimalValue(row, BD_COL_Area),
                ComerceNumber = GetIntValue(row, BD_COL_ComerceNumber),
                Status = GetStringValue(row, BD_COL_Status)
        };
            return business;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listado = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var business = BuildObject(row);
                listado.Add(business);
            }
            return listado;
        }
    }
}
