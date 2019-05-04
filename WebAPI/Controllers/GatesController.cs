using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class GatesController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new GatesManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }
        
        [Route("api/gates/getByAirport/{airport}")]
        [HttpGet]
        public IHttpActionResult GetByAirport(string airport)
        {
            try
            {
                var mng = new GatesManager();
                var gate = new Gates
                {
                    AirportID = airport
                };
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = mng.RetrieveByAirport(gate);
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Gates tmpGates)
        {
            try
            {
                var mng = new GatesManager();
                mng.Create(tmpGates);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha registrado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Gates tmpGates)
        {
            try
            {
                var mng = new GatesManager();
                mng.Update(tmpGates);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha modificado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Gates tmpGates)
        {
            try
            {
                var mng = new GatesManager();
                mng.Delete(tmpGates);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha desactivado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}

