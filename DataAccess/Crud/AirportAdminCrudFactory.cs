using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAccess.Mapper;
using DataAccess.Dao;

namespace DataAccess.Crud
{
    public class AirportAdminCrudFactory : CrudFactory
    {
        AirportAdminMapper mapper;
        UserMapper userMapper;

        public AirportAdminCrudFactory() : base()
        {
            mapper = new AirportAdminMapper();
            userMapper = new UserMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var admon = (User)entity;
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
            var lstUsers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUsers;
        }
        
        public List<T> RetrieveAllWithoutAirport<T>()
        {
            var lstUsers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatementWithoutAirport());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = userMapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUsers;
        }
        
        public List<T> RetrieveAllAirportAdmin<T>()
        {
            var lstUsers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetAllAirportAdminStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstUsers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstUsers;
        }

        public override void Update(BaseEntity entity)
        {
            var admon = (User)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(admon));
        }

        public override void Delete(BaseEntity entity)
        {
            var admon = (User)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(admon));
        }

        public override void Activar(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
