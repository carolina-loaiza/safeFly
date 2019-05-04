using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public abstract class BasicCrud<T> : CrudFactory
    {
        protected IMapper Mapper;

        protected BasicCrud() => dao = SqlDao.GetInstance();

        public override T Retrieve<T>(BaseEntity entity)
        {
            var
                lstResult = dao.ExecuteQueryProcedure(Mapper.GetRetriveStatement(entity));
            return lstResult.Count > 0
                ? (T) Convert.ChangeType(Mapper.BuildObject(lstResult[0]), typeof(T))
                : default(T);

        }

        public override List<T> RetrieveAll<T>() =>
            Mapper.BuildObjects(dao.ExecuteQueryProcedure(Mapper.GetRetriveAllStatement()))
                .Select(entity => (T) Convert.ChangeType(entity, typeof(T)))
                .ToList();

        public override void Create(BaseEntity entity) => dao.ExecuteProcedure(Mapper.GetCreateStatement(entity));

        public override void Update(BaseEntity entity) => dao.ExecuteProcedure(Mapper.GetUpdateStatement(entity));

        public override void Delete(BaseEntity entity) => dao.ExecuteProcedure(Mapper.GetDeleteStatement(entity));
    }
}