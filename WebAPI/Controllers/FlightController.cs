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
    public class FlightController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new FlightManagement();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new FlightManagement();
                var flight = new Flight
                {
                    FlyNumber = id
                };
                flight = mng.RetrieveById(flight);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = flight;
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Flight tmpFlight)
        {
            try
            {
                var mng = new FlightManagement();
                mng.Create(tmpFlight);
                apiResp = new ApiResponse();
                apiResp.Message = "El vuelo se ha registrado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Flight tmpFlight)
        {
            try
            {
                var mng = new FlightManagement();
                mng.Update(tmpFlight);
                apiResp = new ApiResponse();
                apiResp.Message = "El vuelo se ha modificado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Flight tmpFlight)
        {
            try
            {
                var mng = new FlightManagement();
                mng.Delete(tmpFlight);
                apiResp = new ApiResponse();
                apiResp.Message = "El vuelo se ha desactivado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}
