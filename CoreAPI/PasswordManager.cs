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
    public class PasswordManager : BaseManager
    {
      private UserCrudFactory crudUser;
        private PasswordCrudFactory crudPassword;

        public PasswordManager()
        {
           crudUser = new UserCrudFactory();
            crudPassword = new PasswordCrudFactory();
        }

        public void Create(string UserID, string Keyword, DateTime ExpirationDate, string Status)
        {

            Password passw = new Password(UserID,Keyword,ExpirationDate,Status);

            try
            {
                var c = crudPassword.Retrieve<Password>(passw);

                if (c != null)
                {
                    //User already exist
                    throw new BussinessException(3);
                }

                // if (user.Age >= 18)
                crudPassword.Create(passw);
                //  else
                //    throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

      //  public List<Password> RetrieveAll()
      //  {
      //      return crudPassword.RetrieveAll<Password>();
      //  }

        public Password RetrieveById(Password passw)
        {
            Password c = null;
            try
            {
                c = crudPassword.Retrieve<Password>(passw);
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

       

        public void Update(Password passw)
        {
            crudPassword.Update(passw);
        }

   //     public void Delete(Password passw)
    //    {
   //         crudPassword.Delete(passw);
    //    }

       


        public Password GetPassword(Password password)
        {
            Password c = null;
            try
            {
                c = crudPassword.Retrieve<Password>(password);
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
    }

}
