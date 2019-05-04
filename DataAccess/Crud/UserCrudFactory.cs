using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAccess.Mapper;
using DataAccess.Dao;

namespace DataAccess.Crud
{
    public class UserCrudFactory : CrudFactory
    {
        UserMapper mapper;

        public UserCrudFactory() : base()
        {
            mapper = new UserMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var user = (User)entity;
            var sqlOperation = mapper.GetCreateStatement(user);
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

        public override void Update(BaseEntity entity)
        {
            var user = (User)entity;
          //  var sqlOperation = mapper.GetUpdateStatement(user);
            dao.ExecuteProcedure(mapper.GetUpdateStatement(user));
        }

        public override void Delete(BaseEntity entity)
        {
            var user = (User)entity;
          //  var sqlOperation = mapper.GetDeleteStatement(user);
            dao.ExecuteProcedure(mapper.GetDeleteStatement(user));
        }

        public override void Activar(BaseEntity entity)
        {
            var user = (User)entity;
            var sqlOperation = mapper.GetActivarStatement(user);
            dao.ExecuteProcedure(sqlOperation);
        }

        public T GetEmail<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetUserRoleStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildRole(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }
    }
}
