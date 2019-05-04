using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class AirportMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        public string BD_COL_LegalNumber = "LegalNumber";
        public string BD_COL_NameAirport = "NameAirport";
        public string BD_COL_BusinessName = "BusinessName";
        public string BD_COL_Admin = "Administrator";
        public string BD_COL_Email = "Email";
        public string BD_COL_Latitude = "Latitude";
        public string BD_COL_Longitude = "Longitude";
        public string BD_COL_Representative = "Representative";
        public string BD_COL_RepresentativeID = "RepresentativeID";
        public string BD_COL_Status = "Estado";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_AIRPORT_PR"};

            var a = (Airport)entity;
            
                operation.AddVarcharParam(BD_COL_LegalNumber, a.LegalNumber);
                operation.AddVarcharParam(BD_COL_NameAirport, a.NameAirport);
                operation.AddVarcharParam(BD_COL_BusinessName, a.BusinessName);
                operation.AddVarcharParam(BD_COL_Admin, a.Administrator);
                operation.AddVarcharParam(BD_COL_Email, a.Email);
                operation.AddVarcharParam(BD_COL_Latitude, a.Latitude);
                operation.AddVarcharParam(BD_COL_Longitude, a.Longitude);
                operation.AddVarcharParam(BD_COL_Representative, a.Representative);
                operation.AddVarcharParam(BD_COL_RepresentativeID, a.RepresentativeID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_AIRPORT_PR" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_AIRPORT_PR" };

            var a = (Airport)entity;

            operation.AddVarcharParam(BD_COL_LegalNumber, a.LegalNumber);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_AIRPORT_PR" };

            var a = (Airport)entity;

            operation.AddVarcharParam(BD_COL_LegalNumber, a.LegalNumber);
            operation.AddVarcharParam(BD_COL_NameAirport, a.NameAirport);
            operation.AddVarcharParam(BD_COL_BusinessName, a.BusinessName);
            operation.AddVarcharParam(BD_COL_Admin, a.Administrator);
            operation.AddVarcharParam(BD_COL_Email, a.Email);
            operation.AddVarcharParam(BD_COL_Latitude, a.Latitude);
            operation.AddVarcharParam(BD_COL_Longitude, a.Longitude);
            operation.AddVarcharParam(BD_COL_Representative, a.Representative);
            operation.AddVarcharParam(BD_COL_RepresentativeID, a.RepresentativeID);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_AIRPORT_PR" };

            var a = (Airport)entity;

            operation.AddVarcharParam(BD_COL_LegalNumber, a.LegalNumber);
            return operation;
        }

        public SqlOperation GetActivarStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_AIRPORT_PR" };

            var a = (Airport)entity;

            operation.AddVarcharParam(BD_COL_LegalNumber, a.LegalNumber);
            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var Airports = new Airport
            {
                LegalNumber = GetStringValue(row, BD_COL_LegalNumber),
                NameAirport = GetStringValue(row, BD_COL_NameAirport),
                BusinessName = GetStringValue(row, BD_COL_BusinessName),
                Administrator = GetStringValue(row, BD_COL_Admin),
                Email = GetStringValue(row, BD_COL_Email),
                Latitude = GetStringValue(row, BD_COL_Latitude),
                Longitude = GetStringValue(row, BD_COL_Longitude),
                Representative = GetStringValue(row, BD_COL_Representative),
                RepresentativeID = GetStringValue(row, BD_COL_RepresentativeID),
                Estado = GetStringValue(row, BD_COL_Status)
            };
            return Airports;  
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listado = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var airports = BuildObject(row);
                listado.Add(airports);
            }
            return listado;
        }
    }
}
