using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AirlineController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new AirlineManagement();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new AirlineManagement();
                var airline = new Airline
                {
                    ID = id
                };
                airline = mng.RetrieveById(airline);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = airline; 
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Airline tmpAirline)
        {
            try
            {
                var mng = new AirlineManagement();
                mng.Create(tmpAirline);
                apiResp = new ApiResponse();
                apiResp.Message = "La aerolinea se ha registrado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Airline tmpAirline)
        {
            try
            {
                var mng = new AirlineManagement();
                mng.Update(tmpAirline);
                apiResp = new ApiResponse();
                apiResp.Message = "La aerolinea se ha modificado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Airline tmpAirline)
        {
            try
            {
                var mng = new AirlineManagement();
                mng.Delete(tmpAirline);
                apiResp = new ApiResponse();
                apiResp.Message = "La aerolinea se ha desactivado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        [Route("api/Airport/Activar")]
        [HttpPut]
        public IHttpActionResult Activar(Airline tmpAirline)
        {
            try
            {
                var mng = new AirlineManagement();
                mng.Activar(tmpAirline);
                apiResp = new ApiResponse();
                apiResp.Message = "La aerolinea se ha activado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}
