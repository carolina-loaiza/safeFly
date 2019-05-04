using System;
using System.Web.Http;
using CoreAPI;
using Entities_POJO;
using Exceptions;

namespace WebAPI.Controllers
{
    public class TaxController : BasicController<Tax, TaxManagement>
    {
        
        /// <summary>
        /// retorna un elemento "Tax" basado en el id proporcionado
        /// </summary>
        /// <param name="id">Id del elemnto Tax</param>
        /// <returns></returns>
        public override IHttpActionResult Get(string id)
        {
            try
            {
                var e = new Tax {Id = int.Parse(id)};
                ApiResp.Data = Mng.RetrieveById(e);
                return ApiResp.Data == null ? (IHttpActionResult) NotFound() : Ok(ApiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}