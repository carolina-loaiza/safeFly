using System.Collections.Generic;
using System.Linq;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper {
    internal class ViewMapper : EntityMapper, IMapper {

        private const string DB_COL_ID          = "ID",
                             DB_COL_NAME        = "Name",
                             DB_COL_DESCRIPTION = "Description",
                             DB_COL_STATUS      = "Status";

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            return lstRows.Select(BuildObject).ToList();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row) {
            return new View
            {
                Id = GetIntValue(
                    row,
                    DB_COL_ID
                ),
                Name = GetStringValue(
                    row,
                    DB_COL_NAME
                ),
                Description = GetStringValue(
                    row,
                    DB_COL_DESCRIPTION
                ),
                Status = GetStringValue(
                    row,
                    DB_COL_STATUS
                )
            };
        }

        public SqlOperation GetCreateStatement(BaseEntity entity) {
            var o = new SqlOperation {ProcedureName = "CRE_VIEW_PR"};
            var r = (View) entity;

            o.AddVarcharParam(
                DB_COL_NAME,
                r.Name
            );

            o.AddVarcharParam(
                DB_COL_STATUS,
                r.Status
            );

            o.AddVarcharParam(
                DB_COL_DESCRIPTION,
                r.Description
            );
            return o;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity) {
            var o = new SqlOperation {ProcedureName = "RET_VIEW_PR"};
            var r = (View) entity;

            o.AddIntParam(
                DB_COL_NAME,
                r.Id
            );
            return o;
        }

        public SqlOperation GetRetriveAllStatement() {
            var o = new SqlOperation {ProcedureName = "RET_ALL_VIEW_PR"};
            return o;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity) {
            var o = new SqlOperation {ProcedureName = "UPD_VIEW_PR"};
            var r = (View) entity;

            o.AddIntParam(
                DB_COL_NAME,
                r.Id
            );
            return o;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity) {
            var o = new SqlOperation {ProcedureName = "DEL_VIEW_PR"};
            var r = (View) entity;

            o.AddIntParam(
                DB_COL_NAME,
                r.Id
            );
            return o;
        }

    }
}
