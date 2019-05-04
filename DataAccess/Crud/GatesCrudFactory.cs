﻿using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAccess.Dao;
using DataAccess.Mapper;

namespace DataAccess.Crud
{
    public class GatesCrudFactory : CrudFactory
    
    {
        GatesMapper mapper;

        public GatesCrudFactory() : base()
        {
            mapper = new GatesMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var airline = (Gates)entity;
            var sqlOperation = mapper.GetCreateStatement(airline);
            dao.ExecuteProcedure(sqlOperation);
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
            var lstGates = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstGates.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstGates;
        }
        
        public List<T> RetrieveByAirport<T>(Gates gate)
        {
            var lstGates = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveByAirportStatement(gate));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstGates.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstGates;
        }

        public override void Update(BaseEntity entity)
        {
            var airline = (Gates)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(airline));
        }

        public override void Delete(BaseEntity entity)
        {
            var airline = (Gates)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(airline));
        }

        public override void Activar(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
