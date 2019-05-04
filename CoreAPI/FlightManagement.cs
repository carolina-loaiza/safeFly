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
    public class FlightManagement
    {
        private FlightCrudFactory crudfactory;

        public FlightManagement()
        {
            crudfactory = new FlightCrudFactory();
        }

        public void Create(Flight a)
        {
            try
            {
                var flight = crudfactory.Retrieve<Flight>(a);
                if (flight != null)
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
        public List<Flight> RetrieveAll()
        {
            return crudfactory.RetrieveAll<Flight>();
        }

        public Flight RetrieveById(Flight a)
        {
            Flight tmpFlight = null;
            try
            {
                tmpFlight = crudfactory.Retrieve<Flight>(a);
                if (tmpFlight == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return tmpFlight;
        }

        public void Update(Flight a)
        {
            crudfactory.Update(a);
        }

        public void Delete(Flight a)
        {
            crudfactory.Delete(a);
        }
    }
}
