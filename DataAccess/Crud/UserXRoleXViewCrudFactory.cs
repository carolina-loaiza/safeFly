using System;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud {
    public class UserXRoleXViewCrudFactory : BasicCrud<UserXRoleXView> {

        public UserXRoleXViewCrudFactory() { Mapper = new UserXRoleXViewMapper(); }
        public override void Activar(BaseEntity entity) { throw new NotImplementedException(); }

    }
}
