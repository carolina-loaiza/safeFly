using System;
using DataAccess.Mapper;
using Entities_POJO;

namespace DataAccess.Crud {
    public class TaxCrudFactory : BasicCrud<Tax> {

        public TaxCrudFactory() { Mapper = new TaxMapper(); }
        public override void Activar(BaseEntity entity) { throw new NotImplementedException(); }

    }
}
