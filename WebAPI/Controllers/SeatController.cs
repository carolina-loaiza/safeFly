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
    public class SeatController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new SeatManagement();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new SeatManagement();
                var seat = new Seat
                {
                    SeatNumber = id
                };
                seat = mng.RetrieveById(seat);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = seat;
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Seat tmpSeat)
        {
            try
            {
                var mng = new SeatManagement();
                mng.Create(tmpSeat);
                apiResp = new ApiResponse();
                apiResp.Message = "El asiento se ha registrado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Seat tmpSeat)
        {
            try
            {
                var mng = new SeatManagement();
                mng.Update(tmpSeat);
                apiResp = new ApiResponse();
                apiResp.Message = "El asiento se ha modificado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Seat tmpSeat)
        {
            try
            {
                var mng = new SeatManagement();
                mng.Delete(tmpSeat);
                apiResp = new ApiResponse();
                apiResp.Message = "El asiento se ha desactivado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}
