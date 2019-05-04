using System.Collections.Generic;
using DataAccess.Crud;

namespace CoreAPI {
    public abstract class Manager<T> {

        protected       BasicCrud<T> CrudFactory;
        public abstract void         Create(T e);
        public abstract List<T>      RetriveAll();
        public abstract T            RetrieveById(T e);
        public abstract void         Update(T       e);
        public abstract void         Delete(T       e);

    }
}
