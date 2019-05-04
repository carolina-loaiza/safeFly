using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAccess.Dao;
using DataAccess.Mapper;

namespace DataAccess.Crud
{
    public class CoinCrudFactory : CrudFactory
    
    {
        CoinMapper mapper;

        public CoinCrudFactory() : base()
        {
            mapper = new CoinMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var coin = (Coin)entity;
            var sqlOperation = mapper.GetCreateStatement(coin);
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
            var lstCoin = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCoin.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCoin;
        }

        public override void Update(BaseEntity entity)
        {
            var coin = (Coin)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(coin));
        }

        public override void Delete(BaseEntity entity)
        {
            var coin = (Coin)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(coin));
        }

        public override void Activar(BaseEntity entity)
        {
            throw new NotImplementedException();
        }



    }
}
