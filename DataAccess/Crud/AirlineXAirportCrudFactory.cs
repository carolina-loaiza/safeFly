using  System;
using System.Collections.Generic;
using Entities_POJO;
using DataAccess.Mapper;
using DataAccess.Dao;

namespace DataAccess.Crud
{
    public class AirlineXAirportCrudFactory : CrudFactory
    {
        AirlineXAirportMapper mapper;

        public AirlineXAirportCrudFactory() : base()
        {
            mapper = new AirlineXAirportMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var data = (AirlineXAirport)entity;
            var sqlOperation = mapper.GetCreateStatement(data);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Activar(BaseEntity entity)
        {
            var data = (AirlineXAirport)entity;
            var sqlOperation = mapper.GetActivarStatement(data);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
        
        public List<T> RetrieveByType<T>(BaseEntity entity, String type)
        {
            var lstData = new List<T>();
            var lstResult = type == "AirlineId"
                ? dao.ExecuteQueryProcedure(mapper.GetRetriveAirlineIdStatement(entity))
                : dao.ExecuteQueryProcedure(mapper.GetRetriveAirportIdStatement(entity));

            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstData.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstData;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstData = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstData.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstData;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

