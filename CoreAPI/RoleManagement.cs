using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;

namespace CoreAPI {
    public class RoleManagement : Manager<Role> {

        public RoleManagement() { CrudFactory = new RoleCrudFactory(); }
        public override void       Create(Role       e) { CrudFactory.Create(e); }
        public override void       Delete(Role       e) { CrudFactory.Delete(e); }
        public override void       Update(Role       e) { CrudFactory.Update(e); }
        public override Role       RetrieveById(Role e) { return CrudFactory.Retrieve<Role>(e); }
        public override List<Role> RetriveAll()         { return CrudFactory.RetrieveAll<Role>(); }

    }
}
