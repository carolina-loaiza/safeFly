using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper
{
    public class ScheduleMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        public string BD_COL_Id = "Id";
        public string BD_COL_FlyNumber = "FlyNumber";
        public string BD_COL_Aproovement = "Aproovement";
        public string BD_COL_Gate = "Gate";
        public string BD_COL_Destiny = "Destiny";
        public string BD_COL_Departure = "Departure";
        public string BD_COL_DepartureDate = "DepartureDate";
        public string BD_COL_ArriveDate = "ArriveDate";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_SCHEDULE_PR" };

            var a = (Schedule)entity;

            operation.AddIntParam(BD_COL_Id, a.Id);
            operation.AddVarcharParam(BD_COL_FlyNumber, a.FlyNumber);
            operation.AddVarcharParam(BD_COL_Aproovement, a.Aproovement);
            operation.AddVarcharParam(BD_COL_Gate, a.Gate);
            operation.AddVarcharParam(BD_COL_Destiny, a.Destiny);
            operation.AddVarcharParam(BD_COL_Departure, a.Departure);
            operation.AddDateTimeParam(BD_COL_DepartureDate, a.DepartureDate);
            operation.AddDateTimeParam(BD_COL_ArriveDate, a.ArriveDate);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_SCHEDULE_PR" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_SCHEDULE_PR" };

            var a = (Schedule)entity;

            operation.AddIntParam(BD_COL_Id, a.Id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_SCHEDULE_PR" };

            var a = (Schedule)entity;

            operation.AddIntParam(BD_COL_Id, a.Id);
            operation.AddVarcharParam(BD_COL_FlyNumber, a.FlyNumber);
            operation.AddVarcharParam(BD_COL_Aproovement, a.Aproovement);
            operation.AddVarcharParam(BD_COL_Gate, a.Gate);
            operation.AddVarcharParam(BD_COL_Destiny, a.Destiny);
            operation.AddVarcharParam(BD_COL_Departure, a.Departure);
            operation.AddDateTimeParam(BD_COL_DepartureDate, a.DepartureDate);
            operation.AddDateTimeParam(BD_COL_ArriveDate, a.ArriveDate);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_SCHEDULE_PR" };

            var a = (Schedule)entity;

            operation.AddVarcharParam(BD_COL_FlyNumber, a.FlyNumber);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var schedule = new Schedule
            {
                Id = GetIntValue(row, BD_COL_Id),
                FlyNumber = GetStringValue(row, BD_COL_FlyNumber),
                Aproovement = GetStringValue(row, BD_COL_Aproovement),
                Gate = GetStringValue(row, BD_COL_Gate),
                Destiny = GetStringValue(row, BD_COL_Destiny),
                Departure = GetStringValue(row, BD_COL_Departure),
                DepartureDate = GetDateValue(row, BD_COL_DepartureDate),
                ArriveDate = GetDateValue(row, BD_COL_ArriveDate)
            };

           return schedule;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listado = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var schedules = BuildObject(row);
                listado.Add(schedules);
            }
            return listado;
        }

    }
}
