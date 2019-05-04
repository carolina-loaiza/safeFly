using System.Collections.Generic;
using System.Linq;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper {
    public class RoleMapper : EntityMapper, IMapper {

        public BaseEntity BuildObject(Dictionary<string, object> row) {
            return new Role
            {
                Id = GetIntValue(
                    row,
                    DB_COL_Id
                ),
                Name = GetStringValue(
                    row,
                    DB_COL_Name
                ),
                Status = GetStringValue(
                    row,
                    DB_COL_Status
                ),
                Description = GetStringValue(
                    row,
                    DB_COL_Description
                )
            };
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            return lstRows.Select(BuildObject).ToList();
        }

        public SqlOperation GetCreateStatement(BaseEntity e) {
            var o = new SqlOperation {ProcedureName = "CRE_ROLE_PR"};
            var r = (Role) e;

            o.AddVarcharParam(
                DB_COL_Name,
                r.Name
            );

            o.AddVarcharParam(
                DB_COL_Status,
                r.Status
            );

            o.AddVarcharParam(
                DB_COL_Description,
                r.Description
            );
            return o;
        }

        public SqlOperation GetDeleteStatement(BaseEntity e) {
            var o = new SqlOperation {ProcedureName = "DEL_ROLE_PR"};
            var r = (Role) e;

            o.AddIntParam(
                DB_COL_Id,
                r.Id
            );
            return o;
        }

        public SqlOperation GetRetriveAllStatement() {
            var o = new SqlOperation {ProcedureName = "RET_ALL_ROLES_PR"};
            return o;
        }

        public SqlOperation GetRetriveStatement(BaseEntity e) {
            var o = new SqlOperation {ProcedureName = "RET_ROLE_PR"};
            var r = (Role) e;

            o.AddIntParam(
                DB_COL_Id,
                r.Id
            );
            return o;
        }

        public SqlOperation GetUpdateStatement(BaseEntity e) {
            var o = new SqlOperation {ProcedureName = "UPD_ROLE_PR"};
            var r = (Role) e;

            o.AddIntParam(
                DB_COL_Id,
                r.Id
            );

            o.AddVarcharParam(
                DB_COL_Name,
                r.Name
            );

            o.AddVarcharParam(
                DB_COL_Description,
                r.Description
            );
            return o;
        }

        // ReSharper disable InconsistentNaming
        private const string DB_COL_Description = "Description";
        private const string DB_COL_Id          = "ID";
        private const string DB_COL_Name        = "Name";
        private const string DB_COL_Status      = "Status";

        // ReSharper restore InconsistentNaming

    }
}
