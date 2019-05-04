using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAccess.Mapper;
using DataAccess.Dao;

namespace DataAccess.Crud
{
    public class AdministratorCrudFactory : CrudFactory
    {
        AdministratorMapper mapper;

        public AdministratorCrudFactory() : base()
        {
            mapper = new AdministratorMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var admon = (Administrator)entity;
            var sqlOperation = mapper.GetCreateStatement(admon);
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

        public override List<T> RetrieveAll<T>()
        {
            var lstAdmon = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAdmon.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAdmon;
        }

        public override void Update(BaseEntity entity)
        {
            var admon = (Administrator)entity;
            //  var sqlOperation = mapper.GetUpdateStatement(user);
            dao.ExecuteProcedure(mapper.GetUpdateStatement(admon));
        }

        public override void Delete(BaseEntity entity)
        {
            var admon = (Administrator)entity;
            //  var sqlOperation = mapper.GetDeleteStatement(user);
            dao.ExecuteProcedure(mapper.GetDeleteStatement(admon));
        }

        public override void Activar(BaseEntity entity)
        {
            var admon = (Administrator)entity;
            var sqlOperation = mapper.GetActivarStatement(admon);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}

