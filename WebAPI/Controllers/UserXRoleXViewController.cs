using System;
using System.Web.Http;
using CoreAPI;
using Entities_POJO;
using Exceptions;

namespace WebAPI.Controllers
{
    public class UserXRoleXViewController : BasicController<UserXRoleXView, UserXRoleXViewManagement>
    {
        /// <summary>
        ///     Retorna una elemnto con el indentificador ingresado
        /// </summary>
        /// <param name="id">Identificador especificao del elemento consultado</param>
        /// <returns></returns>
        public override IHttpActionResult Get(string id)
        {
            try
            {
                var e = new UserXRoleXView {Id = int.Parse(id)};
                ApiResp.Data = Mng.RetrieveById(e);
                return ApiResp.Data == null ? (IHttpActionResult) NotFound() : Ok(ApiResp);
            } catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}