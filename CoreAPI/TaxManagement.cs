using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;

namespace CoreAPI {
    public class TaxManagement : Manager<Tax> {

        public TaxManagement() { CrudFactory = new TaxCrudFactory(); }
        public override void      Create(Tax       e) { CrudFactory.Create(e); }
        public override void      Update(Tax       e) { CrudFactory.Update(e); }
        public override void      Delete(Tax       e) { CrudFactory.Delete(e); }
        public override Tax       RetrieveById(Tax e) { return CrudFactory.Retrieve<Tax>(e); }
        public override List<Tax> RetriveAll()        { return CrudFactory.RetrieveAll<Tax>(); }

    }
}
