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
    public class ScheduleController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ScheduleManagement();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(string id)
        {
            try
            {
                var mng = new ScheduleManagement();
                var schedule = new Schedule
                {
                    FlyNumber = id
                };
                schedule = mng.RetrieveById(schedule);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada:";
                apiResp.Data = schedule;
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Post(Schedule tmpSchedule)
        {
            try
            {
                var mng = new ScheduleManagement();
                mng.Create(tmpSchedule);
                apiResp = new ApiResponse();
                apiResp.Message = "El horario se ha registrado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(Schedule tmpSchedule)
        {
            try
            {
                var mng = new ScheduleManagement();
                mng.Update(tmpSchedule);
                apiResp = new ApiResponse();
                apiResp.Message = "El horario se ha modificado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(Schedule tmpSchedule)
        {
            try
            {
                var mng = new ScheduleManagement();
                mng.Delete(tmpSchedule);
                apiResp = new ApiResponse();
                apiResp.Message = "El horario se ha desactivado";
                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}
