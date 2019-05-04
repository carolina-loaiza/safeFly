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
    public class AirportController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new AirportManagement();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    LegalNumber = id
                };
                airport = mng.RetrieveById(airport);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = airport; 
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
        
        [HttpGet]
        [Route("api/Airport/ByAdminID/{adminID}")]
        public IHttpActionResult GetByAdminID(string adminID)
        {
            try
            {
                var mng = new AirportManagement();
                var airport = new Airport
                {
                    Administrator = adminID
                };
                airport = mng.RetrieveByAdminID(airport);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = airport; 
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
        
        [HttpGet]
        [Route("api/Airport/AllApproval/{AirlineID}/{Approvement}")]
       public IHttpActionResult GetByApproval(string AirlineID, string Approvement)
        {
            try
            {
                var mng = new AirportManagement();
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = mng.RetrieveAllApproval(Approvement, AirlineID); 
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
        
        public IHttpActionResult Post(Airport tmpAirport)
        {
            try
            {
                var mng = new AirportManagement();
                mng.Create(tmpAirport);
                apiResp = new ApiResponse();
                apiResp.Message = "El aeropuerto se ha registrado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Airport tmpAirport)
        {
            try
            {
                var mng = new AirportManagement();
                mng.Update(tmpAirport);
                apiResp = new ApiResponse();
                apiResp.Message = "El aeropuerto se ha modificado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Airport tmpAirport)
        {
            try
            {
                var mng = new AirportManagement();
                mng.Delete(tmpAirport);
                apiResp = new ApiResponse();
                apiResp.Message = "El aeropuerto se ha desactivado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        [Route("api/Airport/Activar")]
        [HttpPut]
        public IHttpActionResult Activar(Airport tmpAirport)
        {
            try
            {
                var mng = new AirportManagement();
                mng.Activar(tmpAirport);
                apiResp = new ApiResponse();
                apiResp.Message = "El aeropuerto se ha activado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}
