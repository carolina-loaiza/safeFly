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
    public class AirportAdminManager : BaseManager
    {
        private AirportAdminCrudFactory crudAirportAdmin;

        public AirportAdminManager()
        {
            crudAirportAdmin = new AirportAdminCrudFactory();
        }

        public void Create(User admon)
        {
            try
            {
                 var c = crudAirportAdmin.Retrieve<User>(admon);
              


                if (c != null)
                {
                    //User already exist
                    throw new BussinessException(3);
                }

                // if (user.Age >= 18)
                crudAirportAdmin.Create(admon);
              //  else
                //    throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

      //  public List<User> RetrieveAll()
       // {
        //    return crudAirportAdmin.RetrieveAll<User>();
      //  }

        public List<Administrator> RetrieveAll()
        {
            return crudAirportAdmin.RetrieveAll<Administrator>();
        }



        public Administrator RetrieveById(Administrator admon)
        {
            Administrator c = null;
            try
            {
                c = crudAirportAdmin.Retrieve<Administrator>(admon);
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

        public void Update(User admon)
        {
            crudAirportAdmin.Update(admon);
        }

        public void Delete(User admon)
        {
            crudAirportAdmin.Delete(admon);
        }
    }
}

        public List<Administrator> RetrieveAllAirportAdmin()
        {
            return crudAirportAdmin.RetrieveAllAirportAdmin<Administrator>();
        }
        public List<User> RetrieveAllWithoutAirport()
        {
            return crudAirportAdmin.RetrieveAllWithoutAirport<User>();
        }