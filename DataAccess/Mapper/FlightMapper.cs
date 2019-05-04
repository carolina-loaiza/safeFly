using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class FlightMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        public const string BD_COL_FlyNumber = "FlyNumber";
        public const string BD_COL_SeatsQuantify = "SeatsQuantify";
        public const string BD_COL_FirstClassSeats = "FirstClassSeats";
        public const string BD_COL_BusinessClassSeats = "BusinessClassSeats";
        public const string BD_COL_EconomicClassSeats = "EconomicClassSeats";
        public const string BD_COL_Status = "Status";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "CRE_FLIGHT_PR"};
            var f = (Flight)entity;

            operation.AddVarcharParam(BD_COL_FlyNumber, f.FlyNumber);
            operation.AddIntParam(BD_COL_SeatsQuantify, f.SeatsQuantify);
            operation.AddIntParam(BD_COL_FirstClassSeats, f.FirstClassSeats);
            operation.AddIntParam(BD_COL_BusinessClassSeats, f.BusinessClassSeats);
            operation.AddIntParam(BD_COL_EconomicClassSeats, f.EconomicClassSeats);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_FLIGHT_PR" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_FLIGHT_PR" };
            var f = (Flight)entity;

            operation.AddVarcharParam(BD_COL_FlyNumber, f.FlyNumber);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_FLIGHT_PR" };
            var f = (Flight)entity;

            operation.AddVarcharParam(BD_COL_FlyNumber, f.FlyNumber);
            operation.AddIntParam(BD_COL_SeatsQuantify, f.SeatsQuantify);
            operation.AddIntParam(BD_COL_FirstClassSeats, f.FirstClassSeats);
            operation.AddIntParam(BD_COL_BusinessClassSeats, f.BusinessClassSeats);
            operation.AddIntParam(BD_COL_EconomicClassSeats, f.EconomicClassSeats);
            operation.AddVarcharParam(BD_COL_Status, f.Status);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_FLIGHT_PR" };
            var f = (Flight)entity;

            operation.AddVarcharParam(BD_COL_FlyNumber, f.FlyNumber);

            return operation;
        }


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var flight = new Flight
            {
                FlyNumber = GetStringValue(row, BD_COL_FlyNumber),
                SeatsQuantify = GetIntValue(row, BD_COL_SeatsQuantify),
                FirstClassSeats = GetIntValue(row, BD_COL_FirstClassSeats),
                BusinessClassSeats = GetIntValue(row, BD_COL_BusinessClassSeats),
                EconomicClassSeats = GetIntValue(row, BD_COL_EconomicClassSeats),
                Status = GetStringValue(row, BD_COL_Status)
            };
            return flight;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listado = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var flights = BuildObject(row);
                listado.Add(flights);
            }
            return listado;
        }
    }
}
