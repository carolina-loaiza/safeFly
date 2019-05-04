using System;
using System.Collections.Generic;
using DataAccess.Dao;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud
{
    public class RoleCrudFactory : BasicCrud<Role>
    {
        public RoleCrudFactory() => Mapper = new RoleMapper();
        public override void Activar(BaseEntity entity) => throw new NotImplementedException();
    }
}
