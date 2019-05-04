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
                //mngpass.Create(user.Email, user.Password, ExpirationDate.AddYears(5), "Activo");

                apiResp = new ApiResponse();
                apiResp.Message = "El Usuario se ha registrado";

                //welcome email
                EnviarCorreo(user);

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


        //El siguiente codigo envia un correo de bienvenida al usuario recien registrado
        private static void EnviarCorreo(User user)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add(user.Email);
            mmsg.Subject = "Welcome to SafeFly community";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            //mmsg.Bcc.Add(user.Email); //con copia al usuario que lo envió

            //contenido del mensaje:
            mmsg.Body = ("Hi there, thanks for signing up to keep in touch with Safely. Let me tell you that we're so happy you're here." +
                         "We hope you find all you need for your upcoming adventures.");  //mensaje para el usuario.
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;

            //direccion de donde se envia el correo: 
            mmsg.From = new System.Net.Mail.MailAddress("wizardco2019@gmail.com");

            //cliente correo: 
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Credenciales del correo emisor: (correo y contrasena)
            cliente.Credentials = new System.Net.NetworkCredential("wizardco2019@gmail.com", "Cenfo2019$");

            //para enviar desde un correo de gmail:
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

            //ejecucion: 
            try
            {
                //Send es el metodo que lo envia - mmsg es toda la inforamcion que se va a enviar
                cliente.Send(mmsg);
            }
            catch (Exception)
            {

            }
        }
    }
}
