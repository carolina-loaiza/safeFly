using CoreAPI;
using Entities_POJO;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class UserController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/user
        // Retrieve
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new UserManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/user/5
        // Retrieve by id
        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new UserManager();
                var user = new User
                {
                    ID = id
                };

                user = mng.RetrieveById(user);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion Solicitada";
                apiResp.Data = user;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(User user)
        {

            try
            {
                var mng = new UserManager();
                mng.Create(user);

                var mngpass = new PasswordManager();
                DateTime ExpirationDate = DateTime.Today;
                mngpass.Create(user.Email, user.Password, ExpirationDate.AddYears(5), "Activo");

                apiResp = new ApiResponse();
                apiResp.Message = "El Usuario se ha registrado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(User user)
        {
            try
            {
                var mng = new UserManager();
                mng.Update(user);

                apiResp = new ApiResponse();
                apiResp.Message = "El usuario se ha modificado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(User user)
        {
            try
            {
                var mng = new UserManager();
                mng.Delete(user);

                apiResp = new ApiResponse();
                apiResp.Message = "El usuario se ha desactivado";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        [Route("api/User/Activar")]
        [HttpPut]
        public IHttpActionResult Activar(User tmpUser)
        {
            try
            {
                var mng = new UserManager();
                mng.Activar(tmpUser);
                apiResp = new ApiResponse();
                apiResp.Message = "El usuario se ha activado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }

        }

        [Route("api/user/LogIn")]
        [HttpGet]
        public IHttpActionResult LogIn(string email, string password)
        {
            try
            {
                var mng = new UserManager();
                var keyword = new Password
                {
                    UserID = email,
                    Keyword = password
                };

                keyword = mng.GetPassword(keyword);
                apiResp = new ApiResponse();
                apiResp.Data = keyword;
                return Ok(apiResp.Data);
            }

            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        [HttpGet]
        [Route("api/user/GetEmail")]
        public IHttpActionResult GetEmail(string email)
        {
            try
            {
                var mng = new UserManager();
                var user = new User
                {
                    Email = email
                };

                user = mng.RetrieveByEmail(user);
                apiResp = new ApiResponse();
                apiResp.Data = user;
                return Ok(apiResp.Data);
            }

            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
