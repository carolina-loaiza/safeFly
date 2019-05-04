using System;
using System.Web.Http;
using CoreAPI;
using Entities_POJO;
using Exceptions;

namespace WebAPI.Controllers {
    public class ViewController : BasicController<View, ViewManagement> {
        public override IHttpActionResult Get(string id) {
            try {
                var e = new View {Id = int.Parse(id)};
                ApiResp.Data = Mng.RetrieveById(e);
                return ApiResp.Data == null ? (IHttpActionResult) NotFound() : Ok(ApiResp);
            }
            catch (BussinessException ex) {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

    }
}
