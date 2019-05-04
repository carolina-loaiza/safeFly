using DataAccess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class GatesMapper : EntityMapper, ISqlStatements, IObjectMapper
    {   
        public string BD_COL_ID = "ID";
        public string BD_COL_AirportID = "AirportID";
        public string BD_COL_GateCode = "GateCode";
        public string BD_COL_Status = "Status";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_GATES_PR"};

            var a = (Gates)entity;
            
                operation.AddVarcharParam(BD_COL_AirportID, a.AirportID);
                operation.AddVarcharParam(BD_COL_GateCode, a.GateCode);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_GATES_PR" };

            return operation;
        }
        
        public SqlOperation GetRetriveByAirportStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_GATES_BY_AIRPORT_PR" };
             var a = (Gates)entity;
            
            operation.AddVarcharParam(BD_COL_AirportID, a.AirportID);
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_GATES_BY_ID_PR" };

            var a = (Gates)entity;

            operation.AddIntParam(BD_COL_ID, a.ID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_GATES_PR" };

            var a = (Gates)entity;
                
                operation.AddVarcharParam(BD_COL_AirportID, a.AirportID);
                operation.AddVarcharParam(BD_COL_GateCode, a.GateCode);
                operation.AddVarcharParam(BD_COL_Status, a.Status);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_GATES_PR" };

            var a = (Gates)entity;

            operation.AddVarcharParam(BD_COL_AirportID, a.AirportID);
            operation.AddVarcharParam(BD_COL_GateCode, a.GateCode);
            return operation;
        }

        public SqlOperation GetActivarStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "ACT_GATES_PR" };

            var a = (Gates)entity;

            operation.AddVarcharParam(BD_COL_AirportID, a.AirportID);
            operation.AddVarcharParam(BD_COL_GateCode, a.GateCode);
            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var Gates = new Gates
            {
                ID = GetIntValue(row, BD_COL_ID),
                AirportID = GetStringValue(row, BD_COL_AirportID),
                GateCode = GetStringValue(row, BD_COL_GateCode),
                Status = GetStringValue(row, BD_COL_Status)
            };
            return Gates;  
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listado = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var Gates = BuildObject(row);
                listado.Add(Gates);
            }
            return listado;
        }
    }
}

