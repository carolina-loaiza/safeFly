using DataAccess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class AirlineMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        public string BD_COL_ID = "ID";
        public string BD_COL_Name = "Name";
        public string BD_COL_BusinessName = "BusinessName";
        public string BD_COL_Admin = "Admin";
        public string BD_COL_Email = "Email";
        public string BD_COL_PhoneNumber = "PhoneNumber";
        public string BD_COL_RepresentantLegal = "RepresentantLegal";
        public string BD_COL_InscriptionDate = "InscriptionDate";
        public string BD_COL_UrlLogo = "UrlLogo";
        public string BD_COL_Approvement = "Approvement";
        public string BD_COL_Status = "Status";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_AIRLINES_PR"};

            var a = (Airline)entity;
            
                operation.AddVarcharParam(BD_COL_ID, a.ID);
                operation.AddVarcharParam(BD_COL_Name, a.Name);
                operation.AddVarcharParam(BD_COL_BusinessName, a.BusinessName);
                operation.AddVarcharParam(BD_COL_Admin, a.Admin);
                operation.AddVarcharParam(BD_COL_Email, a.Email);
                operation.AddVarcharParam(BD_COL_PhoneNumber, a.PhoneNumber);
                operation.AddVarcharParam(BD_COL_RepresentantLegal, a.RepresentantLegal);
                operation.AddVarcharParam(BD_COL_InscriptionDate, a.InscriptionDate.ToString());
                operation.AddVarcharParam(BD_COL_UrlLogo, a.UrlLogo);
                operation.AddVarcharParam(BD_COL_Approvement, a.Approvement);
                operation.AddVarcharParam(BD_COL_Status, a.Status);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_AIRLINES_PR" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_AIRLINES_BY_ID_PR" };

            var a = (Airline)entity;

            operation.AddVarcharParam(BD_COL_ID, a.ID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_AIRLINES_PR" };

            var a = (Airline)entity;
                
                operation.AddVarcharParam(BD_COL_ID, a.ID);
                operation.AddVarcharParam(BD_COL_Name, a.Name);
                operation.AddVarcharParam(BD_COL_BusinessName, a.BusinessName);
                operation.AddVarcharParam(BD_COL_Admin, a.Admin);
                operation.AddVarcharParam(BD_COL_Email, a.Email);
                operation.AddVarcharParam(BD_COL_PhoneNumber, a.PhoneNumber);
                operation.AddVarcharParam(BD_COL_RepresentantLegal, a.RepresentantLegal);
                operation.AddVarcharParam(BD_COL_UrlLogo, a.UrlLogo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_AIRLINES_PR" };

            var a = (Airline)entity;

            operation.AddVarcharParam(BD_COL_ID, a.ID);
            return operation;
        }

        public SqlOperation GetActivarStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_AIRLINES_PR" };

            var a = (Airline)entity;

            operation.AddVarcharParam(BD_COL_ID, a.ID);
            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var Airline = new Airline
            {
                ID = GetStringValue(row, BD_COL_ID),
                Name = GetStringValue(row, BD_COL_Name),
                BusinessName = GetStringValue(row, BD_COL_BusinessName),
                Admin = GetStringValue(row, BD_COL_Admin),
                Email = GetStringValue(row, BD_COL_Email),
                PhoneNumber = GetStringValue(row, BD_COL_PhoneNumber),
                RepresentantLegal = GetStringValue(row, BD_COL_RepresentantLegal),
                InscriptionDate = GetDateValue(row, BD_COL_InscriptionDate),
                UrlLogo = GetStringValue(row, BD_COL_UrlLogo),
                Approvement = GetStringValue(row, BD_COL_Approvement),
                Status = GetStringValue(row, BD_COL_Status)
            };
            return Airline;  
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listado = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var Airlines = BuildObject(row);
                listado.Add(Airlines);
            }
            return listado;
        }
    }
}
