using System;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud {
    public class ViewCrudFactory : BasicCrud<View> {

        public ViewCrudFactory() { Mapper = new ViewMapper(); }
        public override void Activar(BaseEntity entity) { throw new NotImplementedException(); }

    }
}
