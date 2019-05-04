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
    public class AirlineManagement
    {
        private AirlineCrudFactory crudfactory;

        public AirlineManagement()
        {
            crudfactory = new AirlineCrudFactory();
        }

        public void Create(Airline a) {
            try
            {
                var airline = crudfactory.Retrieve<Airline>(a);
                if (airline != null)
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
        public List<Airline> RetrieveAll() {
            return crudfactory.RetrieveAll<Airline>();
        }

        public Airline RetrieveById(Airline a) {
            Airline tmpAirport = null;
            try
            {
                tmpAirport = crudfactory.Retrieve<Airline>(a);
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

        public void Update(Airline a) {
            crudfactory.Update(a);
        }

        public void Delete(Airline a) {
            crudfactory.Delete(a);
        }

        public void Activar(Airline a)
        {
            crudfactory.Activar(a);
        }
    }
}

        public List<Airline> RetrieveAllApproval(string Approvement, string AirportId) {
            return crudfactory.RetrieveAllApproval<Airline>(Approvement, AirportId);
        }