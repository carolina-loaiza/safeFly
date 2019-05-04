using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class SeatMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        public const string BD_COL_Id = "Id";
        public const string BD_COL_SeatNumber = "SeatNumber";
        public const string BD_COL_FlyNumber = "FlyNumber";
        public const string BD_COL_SeatClass = "SeatClass";
        public const string BD_COL_Status = "Status";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_SEAT_PR" };
            var s = (Seat)entity;

            operation.AddVarcharParam(BD_COL_Id, s.Id);
            operation.AddVarcharParam(BD_COL_SeatNumber, s.SeatNumber);
            operation.AddVarcharParam(BD_COL_FlyNumber, s.FlyNumber);
            operation.AddCharParam(BD_COL_SeatClass, s.SeatClass);
            operation.AddVarcharParam(BD_COL_Status, s.Status);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SEAT_PR" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SEAT_PR" };
            var s = (Seat)entity;

            operation.AddVarcharParam(BD_COL_SeatNumber, s.SeatNumber);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_SEAT_PR" };
            var s = (Seat)entity;

            operation.AddVarcharParam(BD_COL_SeatNumber, s.SeatNumber);
            operation.AddVarcharParam(BD_COL_FlyNumber, s.FlyNumber);
            operation.AddCharParam(BD_COL_SeatClass, s.SeatClass);
            operation.AddVarcharParam(BD_COL_Status, s.Status);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_SEAT_PR" };
            var s = (Seat)entity;

            operation.AddVarcharParam(BD_COL_FlyNumber, s.FlyNumber);
            operation.AddVarcharParam(BD_COL_SeatNumber, s.SeatNumber);

            return operation;
        }
        
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var seat = new Seat
            {
                Id = GetStringValue(row, BD_COL_Id),
                SeatNumber = GetStringValue(row, BD_COL_SeatNumber),
                FlyNumber = GetStringValue(row, BD_COL_FlyNumber),
                SeatClass = GetCharValue(row, BD_COL_SeatClass),
                Status = GetStringValue(row, BD_COL_Status)
            };
            return seat;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listado = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var seats = BuildObject(row);
                listado.Add(seats);
            }
            return listado;
        }
    }
}
