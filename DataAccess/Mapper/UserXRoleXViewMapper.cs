using System.Collections.Generic;
using System.Linq;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper {
    public class UserXRoleXViewMapper : EntityMapper, IMapper {

        public BaseEntity BuildObject(Dictionary<string, object> row) {
            return new UserXRoleXView
            {
                Id     = GetIntValue(row, DB_COL_Id), UserId     = GetStringValue(row, DB_COL_UserID),
                RoleId = GetIntValue(row, DB_COL_RoleID), ViewId = GetIntValue(row, DB_COL_ViewID)
            };
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows) {
            return lstRows.Select(BuildObject).ToList();
        }

        public SqlOperation GetCreateStatement(BaseEntity e) {
            var o = new SqlOperation {ProcedureName = "CRE_UserXRoleXView_PR"};
            var r = (UserXRoleXView) e;
            o.AddVarcharParam(DB_COL_UserID, r.UserId);
            o.AddIntParam(DB_COL_RoleID, r.RoleId);
            o.AddIntParam(DB_COL_ViewID, r.ViewId);
            return o;
        }

        public SqlOperation GetDeleteStatement(BaseEntity e) {
            var o = new SqlOperation {ProcedureName = "DEL_UserXRoleXView_PR"};
            o.AddIntParam(DB_COL_Id, ((UserXRoleXView) e).Id);
            return o;
        }

        public SqlOperation GetRetriveAllStatement() {
            var o = new SqlOperation {ProcedureName = "RET_ALL_UserXRoleXView_PR"};
            return o;
        }

        public SqlOperation GetRetriveStatement(BaseEntity e) {
            var o = new SqlOperation {ProcedureName = "RET_UserXRoleXView_PR"};
            var r = (UserXRoleXView) e;
            o.AddIntParam(DB_COL_Id, r.Id);
            return o;
        }

        public SqlOperation GetUpdateStatement(BaseEntity e) {
            var o = new SqlOperation {ProcedureName = "UPD_UserXRoleXView_PR"};
            var r = (UserXRoleXView) e;
            o.AddIntParam(DB_COL_Id, r.Id);
            return o;
        }

        // ReSharper disable InconsistentNaming
        private const string DB_COL_Id     = "ID";
        private const string DB_COL_UserID = "UserID";
        private const string DB_COL_RoleID = "RoleID";
        private const string DB_COL_ViewID = "ViewID";

        // ReSharper restore InconsistentNaming

    }
}
