using System.Collections.Generic;
using DataAccess.Crud;
using Entities_POJO;

namespace CoreAPI {
    public class ViewManagement : Manager<View> {

        public ViewManagement() { CrudFactory = new ViewCrudFactory(); }
        public override void       Create(View e)       { CrudFactory.Create(e); }
        public override List<View> RetriveAll()         { return CrudFactory.RetrieveAll<View>(); }
        public override View       RetrieveById(View e) { return CrudFactory.Retrieve<View>(e); }
        public override void       Update(View       e) { CrudFactory.Update(e); }
        public override void       Delete(View       e) { CrudFactory.Delete(e); }

    }
}
