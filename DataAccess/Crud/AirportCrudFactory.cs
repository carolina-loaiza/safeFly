
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class AirportCrudFactory : CrudFactory
    {
        AirportMapper mapper;

        public AirportCrudFactory() : base()
        {
            mapper = new AirportMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var a = (Airport)entity;
            var sqlOperation = mapper.GetCreateStatement(a);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var lista = new Dictionary<string, object>();
            if(lstResult.Count > 0)
            {
                lista = lstResult[0];
                var objs = mapper.BuildObject(lista);
                return (T)Convert.ChangeType(objs, typeof(T));
            }
            return default(T);
        }
        
        public override List<T> RetrieveAll<T>()
        {
            var listado = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            if(lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var a in objs)
                {
                    listado.Add((T)Convert.ChangeType(a, typeof(T)));
                }
            }
            return listado;
        }

        public override void Update(BaseEntity entity)
        {
            var a = (Airport)entity;
            var sqlOperation = mapper.GetUpdateStatement(a);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var a = (Airport)entity;
            var sqlOperation = mapper.GetDeleteStatement(a);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Activar(BaseEntity entity)
        {
            var a = (Airport)entity;
            var sqlOperation = mapper.GetActivarStatement(a);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
