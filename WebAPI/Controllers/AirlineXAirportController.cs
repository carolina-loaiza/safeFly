using CoreAPI;
using Entities_POJO;
using Exceptions;
using System;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AirlineXAirportController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new AirlineXAirportManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(int ID)
        {
            try
            {
                var mng = new AirlineXAirportManager();
                var data = new AirlineXAirport
                {
                    Id = ID
                };
                data = mng.RetrieveById(data);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = data; 
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(AirlineXAirport tmpData)
        {
            try
            {
                var mng = new AirlineXAirportManager();
                mng.Create(tmpData);
                apiResp = new ApiResponse();
                apiResp.Message = "Se ha registrado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        [Route("api/airlinexairport/activar")]
        [HttpPut]
        public IHttpActionResult Activar(AirlineXAirport tmpData)
        {
            try
            {
                var mng = new AirlineXAirportManager();
                mng.Activar(tmpData);
                apiResp = new ApiResponse();
                apiResp.Message = "La aerolinea se ha activado.";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
        
        [HttpGet]
        [Route("api/airlinexairport/byAirline/{airlineID}")]
        public IHttpActionResult ByAirline(string airlineID)
        {
            try
            {
                var mng = new AirlineXAirportManager();
                var data = new AirlineXAirport
                {
                    AirlineId = airlineID
                };
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = mng.RetrieveByType(data, "AirlineId");
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
        
        
        [HttpGet]
        [Route("api/airlinexairport/byAirport/{airportID}")]
        public IHttpActionResult ByAirport(string airportID)
        {
            try
            {
                var mng = new AirlineXAirportManager();
                var data = new AirlineXAirport
                {
                    AirportId = airportID
                };
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = mng.RetrieveByType(data, "AirportId");
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}
