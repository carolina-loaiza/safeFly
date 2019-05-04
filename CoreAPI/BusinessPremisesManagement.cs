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
    public class BusinessPremisesManagement
    {
        private BusinessPremisesCrudFactory crudfactory;

        public BusinessPremisesManagement()
        {
            crudfactory = new BusinessPremisesCrudFactory();
        }

        public void Create(BusinessPremises business)
        {
            try
            {
                var b = crudfactory.Retrieve<BusinessPremises>(business);
                if(b != null)
                {
                    throw new BussinessException(3);
                }

                crudfactory.Create(business);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<BusinessPremises> RetrieveAll()
        {
            return crudfactory.RetrieveAll<BusinessPremises>();
        }

        public BusinessPremises RetrieveById(BusinessPremises business)
        {
            BusinessPremises tmpBusiness = null;
            try
            {
                tmpBusiness = crudfactory.Retrieve<BusinessPremises>(business);
                if (tmpBusiness ==  null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return tmpBusiness;
        }

        public void Update(BusinessPremises business)
        {
            crudfactory.Update(business);
        }

        public void Delete(BusinessPremises business)
        {
            crudfactory.Delete(business);
        }

        public void Activar(BusinessPremises business)
        {
            crudfactory.Activar(business);
        }
    }
}
