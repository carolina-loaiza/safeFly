using DataAccess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class AirlineXAirportMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_Id = "Id";
        private const string DB_COL_AirlineId = "AirlineId";
        private const string DB_COL_AirportId = "AirportId";
        private const string DB_COL_InscriptionFee = "InscriptionFee";
        private const string DB_COL_Status= "Status";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_AirlineXAirport_PR" };

            var c = (AirlineXAirport)entity;
            operation.AddVarcharParam(DB_COL_AirlineId, c.AirlineId);
            operation.AddVarcharParam(DB_COL_AirportId, c.AirportId);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var data = new AirlineXAirport
            {
                Id = GetIntValue(row, DB_COL_Id),
                AirlineId = GetStringValue(row, DB_COL_AirlineId),
                AirportId = GetStringValue(row, DB_COL_AirportId),
                InscriptionFee = GetDecimalValue(row, DB_COL_InscriptionFee),
                Status = GetStringValue(row, DB_COL_Status)
            };

            return data;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_All_AirlineXAirport_PR" };
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_AirlineXAirport_BY_ID_PR" };
            var a = (AirlineXAirport)entity;
            operation.AddIntParam(DB_COL_Id, a.Id);
            return operation;
        }

        public SqlOperation GetRetriveAirlineIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_AirlineXAirport_BY_AirlineId_PR" };
            var a = (AirlineXAirport)entity;
            operation.AddVarcharParam(DB_COL_AirlineId, a.AirlineId);
            return operation;
        }
        
        public SqlOperation GetRetriveAirportIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_AirlineXAirport_BY_AirportId_PR" };
            var a = (AirlineXAirport)entity;
            operation.AddVarcharParam(DB_COL_AirportId, a.AirportId);
            return operation;
        }
        
        public SqlOperation GetActivarStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_AirlineXAirport_PR" };
            var a = (AirlineXAirport)entity;
            operation.AddIntParam(DB_COL_Id, a.Id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listado = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var data = BuildObject(row);
                listado.Add(data);
            }
            return listado;
        }
    }
}
