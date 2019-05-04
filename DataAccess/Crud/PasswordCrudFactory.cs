using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class PasswordCrudFactory
    {

        PasswordMapper mapper;
        protected SqlDao dao;
        public PasswordCrudFactory() : base()
        {
            mapper = new PasswordMapper();
            dao = SqlDao.GetInstance();
        }

        public void Create(BaseEntity entity)
        {
            var password = (Password)entity;
            var sqlOperation = mapper.GetCreateStatement(password);
            dao.ExecuteProcedure(sqlOperation);
        }



        public C Retrieve<C>(BaseEntity entity)
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

        public void Update(BaseEntity entity)
        {
            var password = (Password)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(password));
        }
    }
}
