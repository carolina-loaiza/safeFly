using System.Collections.Generic;
using System.Linq;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper {
    internal class TaxMapper : EntityMapper, IMapper {

        // ReSharper disable InconsistentNaming
        private const string DB_COL_ID          = "ID",
                             DB_COL_NAME        = "Name",
                             DB_COL_AMOUNT      = "Amount",
                             DB_COL_STATUS      = "Status",
                             DB_COL_DESCRIPTION = "Description";

        // ReSharper restore InconsistentNaming

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            return lstRows.Select(BuildObject).ToList();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row) {
            return new Tax
            {
                Id = GetIntValue(
                    row,
                    DB_COL_ID
                ),
                Name = GetStringValue(
                    row,
                    DB_COL_NAME
                ),
                Amount = GetDecimalValue(
                    row,
                    DB_COL_AMOUNT
                ),
                Description = GetStringValue(
                    row,
                    DB_COL_DESCRIPTION
                )
            };
        }

        public SqlOperation GetCreateStatement(BaseEntity entity) {
            var o = new SqlOperation {ProcedureName = "CRE_TAX_PR"};
            var e = (Tax) entity;

            o.AddVarcharParam(
                DB_COL_NAME,
                e.Name
            );

            o.AddVarcharParam(
                DB_COL_DESCRIPTION,
                e.Description
            );

            o.AddVarcharParam(
                DB_COL_STATUS,
                e.Status
            );

            o.AddDecimalParam(
                DB_COL_AMOUNT,
                e.Amount
            );
            return o;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity) {
            var o = new SqlOperation {ProcedureName = "RET_TAX_PR"};
            var e = (Tax) entity;

            o.AddIntParam(
                DB_COL_ID,
                e.Id
            );
            return o;
        }

        public SqlOperation GetRetriveAllStatement() {
            var o = new SqlOperation {ProcedureName = "RET_ALL_TAX_PR"};
            return o;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity) {
            var o = new SqlOperation {ProcedureName = "UPD_TAX_PR"};
            var e = (Tax) entity;

            o.AddIntParam(
                DB_COL_ID,
                e.Id
            );

            o.AddVarcharParam(
                DB_COL_NAME,
                e.Name
            );

            o.AddVarcharParam(
                DB_COL_DESCRIPTION,
                e.Description
            );

            o.AddVarcharParam(
                DB_COL_STATUS,
                e.Status
            );

            o.AddDecimalParam(
                DB_COL_AMOUNT,
                e.Amount
            );
            return o;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity) {
            var o = new SqlOperation {ProcedureName = "DEL_TAX_PR"};
            var e = (Tax) entity;

            o.AddIntParam(
                DB_COL_ID,
                e.Id
            );
            return o;
        }

    }
}
