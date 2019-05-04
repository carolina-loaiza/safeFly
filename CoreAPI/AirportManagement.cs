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
    public class AirportManagement
    {
        private AirportCrudFactory crudfactory;

        public AirportManagement()
        {
            crudfactory = new AirportCrudFactory();
        }

        public void Create(Airport a) {
            try
            {
                var airport = crudfactory.Retrieve<Airport>(a);
                if (airport != null)
                {
                    throw new BussinessException(3);
                }
                crudfactory.Create(a);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public List<Airport> RetrieveAll() {
            return crudfactory.RetrieveAll<Airport>();
        }
        
       public List<Airport> RetrieveAllApproval(string Approvement, string AirlineID) {
            return crudfactory.RetrieveAllApproval<Airport>(Approvement, AirlineID);
        }

        public Airport RetrieveById(Airport a) {
            Airport tmpAirport = null;
            try
            {
                tmpAirport = crudfactory.Retrieve<Airport>(a);
                if (tmpAirport == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return tmpAirport;
        }
        
       public Airport RetrieveByAdminID(Airport a) {
            Airport tmpAirport = null;
            try
            {
                tmpAirport = crudfactory.RetrieveByAdminID<Airport>(a);
                if (tmpAirport == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return tmpAirport;
        }

        public void Update(Airport a) {
            crudfactory.Update(a);
        }

        public void Delete(Airport a) {
            crudfactory.Delete(a);
        }

        public void Activar(Airport a)
        {
            crudfactory.Activar(a);
        }
    }
}
