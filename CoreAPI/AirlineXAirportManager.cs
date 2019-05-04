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
    public class AirlineXAirportManager : BaseManager
    {
        private AirlineXAirportCrudFactory crudAirlineXAirport;

        public AirlineXAirportManager()
        {
            crudAirlineXAirport = new AirlineXAirportCrudFactory();
        }

        public void Create(AirlineXAirport data)
        {
            try
            {
                crudAirlineXAirport.Create(data);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<AirlineXAirport> RetrieveAll()
        {
            return crudAirlineXAirport.RetrieveAll<AirlineXAirport>();
        }

        public AirlineXAirport RetrieveById(AirlineXAirport data)
        {
            AirlineXAirport c = null;
            try
            {
                c = crudAirlineXAirport.Retrieve<AirlineXAirport>(data);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }
        
        public List<AirlineXAirport> RetrieveByType(AirlineXAirport data, string type)
        {
            return crudAirlineXAirport.RetrieveByType<AirlineXAirport>(data, type);
        }

        public void Update(AirlineXAirport data)
        {
            crudAirlineXAirport.Update(data);
        }

        public void Delete(AirlineXAirport data)
        {
            crudAirlineXAirport.Delete(data);
        }
        
        public void Activar(AirlineXAirport a)
        {
            crudAirlineXAirport.Activar(a);
        }
    }
}
