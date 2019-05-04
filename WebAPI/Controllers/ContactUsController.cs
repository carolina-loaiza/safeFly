using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ContactUsController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET 
        // Retrieve - 
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new ContactUsManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/
        // Retrieve by id
        public IHttpActionResult Get(string contactUs)
        {
            try
            {
                var mng = new ContactUsManager();
                var contactus = new ContactUs
                {
                    Email = contactUs
                };

                contactus = mng.RetrieveById(contactus);
                apiResp = new ApiResponse();
                apiResp.Data = contactus;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(ContactUs contactus)
        {

            try
            {
                var mng = new ContactUsManager();
                mng.Create(contactus);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";


                //en la siguiente instruccion enviamos el correo
                enviarCorreo(contactus);

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
        public IHttpActionResult Put(ContactUs contactus)
        {
            try
            {
                var mng = new ContactUsManager();
                mng.Update(contactus);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE == delete
        public IHttpActionResult Delete(ContactUs contactus)
        {
            try
            {
                var mng = new ContactUsManager();
                mng.Delete(contactus);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        private static void enviarCorreo(ContactUs contactus)
        {
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            mmsg.To.Add("wizardco2019@gmail.com");
            mmsg.Subject = "Correo enviado por un usuario desde la pagina de SafeFly para SafeFly";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
            mmsg.Bcc.Add(contactus.Email); //con copia al usuario que lo envió

            //contenido del mensaje:
            mmsg.Body = ("Hola! El siguiente correo ha sido generado desde el formulario de contacto " +
                "         de la plataforma de SafeFly Inc, el mensaje fue enviado por: " + contactus.FirstName + 
                          ". Cuya dirección de correo electronico es: " + contactus.Email +
                          ". El detalle del mensaje que el usuario quiere compartir es el siguiente: " + contactus.Comment);  //mensaje del usuario para SafeFly
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
