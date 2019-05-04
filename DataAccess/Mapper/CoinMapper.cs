using DataAccess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class CoinMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_COIN = "COIN";
        private const string DB_COL_AMOUNT = "AMOUNT";
        private const string DB_COL_SYMBOL = "SYMBOL";
        private const string DB_COL_STATUS = "STATUS";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_COIN_PR" }; // -- CREATE -- Procedimiento de la base de datos

            var c = (Coin)entity;
            operation.AddVarcharParam(DB_COL_COIN, c.CoinName);
            operation.AddDecimalParam(DB_COL_AMOUNT, c.Amount);
            operation.AddVarcharParam(DB_COL_SYMBOL, c.Symbol);
            operation.AddVarcharParam(DB_COL_STATUS, c.Status);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_COIN_PR" }; //  --  RETRIVE -- Procedimiento de la base de datos

            var c = (Coin)entity;
            operation.AddVarcharParam(DB_COL_COIN, c.CoinName);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_COIN_PR" }; //  -- RETRIVE ALL --  Procedimiento de la base de datos             
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_COIN_PR" }; //  -- UPDATE --  Procedimiento de la base de datos

            var c = (Coin)entity;

            operation.AddVarcharParam(DB_COL_COIN, c.CoinName);
            operation.AddDecimalParam(DB_COL_AMOUNT, c.Amount);
            operation.AddVarcharParam(DB_COL_SYMBOL, c.Symbol);
            operation.AddVarcharParam(DB_COL_STATUS, c.Status);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_COIN_PR" }; //  -- DELETE --  Procedimiento de la base de datos

            var c = (Coin)entity;
            operation.AddVarcharParam(DB_COL_COIN, c.CoinName);
            return operation;
        }


        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)  // - INSERT -- 
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var coin = BuildObject(row);
                lstResults.Add(coin);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var coin = new Coin
            {
                CoinName = GetStringValue(row, DB_COL_COIN),
                Amount = GetDecimalValue(row, DB_COL_AMOUNT),
                Symbol = GetStringValue(row, DB_COL_SYMBOL),
                Status = GetStringValue(row, DB_COL_STATUS)
            };

            return coin;
        }
    }
}
