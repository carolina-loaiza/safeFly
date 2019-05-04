using DataAccess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class GatesManager
    {
        private GatesCrudFactory crudfactory;

        public GatesManager()
        {
            crudfactory = new GatesCrudFactory();
        }

        public void Create(Gates a) {
            try
            {
                crudfactory.Create(a);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        
        public List<Gates> RetrieveAll() {
            return crudfactory.RetrieveAll<Gates>();
        }
        
       public List<Gates> RetrieveByAirport(Gates gate) {
            return crudfactory.RetrieveByAirport<Gates>(gate);
        }

        public Gates RetrieveById(Gates a) {
            Gates tmpGates = null;
            try
            {
                tmpGates = crudfactory.Retrieve<Gates>(a);
                if (tmpGates == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return tmpGates;
        }

        public void Update(Gates a) {
            crudfactory.Update(a);
        }

        public void Delete(Gates a) {
            crudfactory.Delete(a);
        }

        public void Activar(Gates a)
        {
            crudfactory.Activar(a);
        }
    }
}

