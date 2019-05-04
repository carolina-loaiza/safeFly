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
    public class UserManager : BaseManager
    {
        private UserCrudFactory crudUser;
        private PasswordCrudFactory crudPassword;

        public UserManager()
        {
            crudUser = new UserCrudFactory();
            crudPassword = new PasswordCrudFactory();
        }

        public void Create(User user)
        {
            try
            {
                 var c = crudUser.Retrieve<User>(user);
              
                if (c != null)
                {
                    //User already exist
                    throw new BussinessException(3);
                }

               // if (user.Age >= 18)
                    crudUser.Create(user);
              //  else
                //    throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<User> RetrieveAll()
        {
            return crudUser.RetrieveAll<User>();
        }

        public User RetrieveById(User user)
        {
            User c = null;
            try
            {
                c = crudUser.Retrieve<User>(user);
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

        public User RetrieveByEmail(User user)
        {
            User c = null;
            try
            {
                c = crudUser.GetEmail<User>(user);
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

        public void Update(User user)
        {
            crudUser.Update(user);
        }

        public void Delete(User user)
        {
            crudUser.Delete(user);
        }

        public void Activar(User user)
        {
            crudUser.Activar(user);
        }


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
