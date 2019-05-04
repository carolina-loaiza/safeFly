using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAccess.Dao;
using DataAccess.Mapper;

namespace DataAccess.Crud
{
    public class AirlineCrudFactory : CrudFactory
    
    {
        AirlineMapper mapper;

        public AirlineCrudFactory() : base()
        {
            mapper = new AirlineMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var airline = (Airline)entity;
            var sqlOperation = mapper.GetCreateStatement(airline);
            dao.ExecuteProcedure(sqlOperation);
        }

        public C RetrieveByAdminID<C>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByAdminIDStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (C)Convert.ChangeType(objs, typeof(C));
            }

            return default(C);
        }

        public override C Retrieve<C>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (C)Convert.ChangeType(objs, typeof(C));
            }

            return default(C);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstAirline = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAirline.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAirline;
        }
        
       public List<T> RetrieveAllApproval<T>(string Approvement, string AirportId)
        {
            var lstAirline = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllApprovalStatement(Approvement, AirportId));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAirline.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAirline;
        }

        public override void Update(BaseEntity entity)
        {
            var airline = (Airline)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(airline));
        }

        public override void Delete(BaseEntity entity)
        {
            var airline = (Airline)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(airline));
        }

        public override void Activar(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
