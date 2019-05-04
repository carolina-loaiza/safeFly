using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;

namespace CoreAPI {
    public class UserXRoleXViewManagement : Manager<UserXRoleXView> {

        public UserXRoleXViewManagement() { CrudFactory = new UserXRoleXViewCrudFactory(); }
        public override void Create(UserXRoleXView e) { CrudFactory.Create(e); }

        public override List<UserXRoleXView> RetriveAll() {
            return CrudFactory.RetrieveAll<UserXRoleXView>();
        }

        public override UserXRoleXView RetrieveById(UserXRoleXView e) {
            return CrudFactory.Retrieve<UserXRoleXView>(e);
        }

        public override void Update(UserXRoleXView e) { CrudFactory.Update(e); }
        public override void Delete(UserXRoleXView e) { CrudFactory.Delete(e); }

    }
}
