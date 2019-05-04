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
    public class ContactUsManager : BaseManager
    {
        private ContactUsCrudFactory crudContactUs;

        public ContactUsManager()
        {
            crudContactUs = new ContactUsCrudFactory();
        }

        public void Create(ContactUs contactUs)
        {
            try
            {
                //var c = crudContactUs.Retrieve<ContactUs>(contactUs);
                crudContactUs.Create(contactUs);    
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<ContactUs> RetrieveAll()
        {
            return crudContactUs.RetrieveAll<ContactUs>();
        }

        public ContactUs RetrieveById(ContactUs contactUs)
        {
            ContactUs c = null;
            try
            {
                c = crudContactUs.Retrieve<ContactUs>(contactUs);
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

        public void Update(ContactUs contactUs)
        {
            crudContactUs.Update(contactUs);
        }

        public void Delete(ContactUs contactUs)
        {
            crudContactUs.Delete(contactUs);
        }
    }
}
