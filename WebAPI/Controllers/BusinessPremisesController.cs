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
    public class BusinessPremisesController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {
            var mng = new BusinessPremisesManagement();
            apiResp = new ApiResponse();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var mng = new BusinessPremisesManagement();
                var business = new BusinessPremises
                {
                    ID = id
                };
                business = mng.RetrieveById(business);
                apiResp = new ApiResponse();
                apiResp.Message = "Informacion solicitada: ";
                apiResp.Data = business;

                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }


        /// <summary>
        /// El siguiente codigo sirve para identificar por rango de precios el total de locales alquilados
        /// por el aeropuerto
        /// </summary>
        /// <param name="type"></param>
        /// <returns> devuelve por categoria el total de locales que cumplen con los criterios.
        ///  (Between500k_1M, Less500k, Between_1M_2M, Morethan2M)
        ///  </returns>
        [HttpGet]
        public IHttpActionResult GetStatistic(string type)
        {
            apiResp = new ApiResponse();
            var mng = new BusinessPremisesManagement();

            if (type.Equals("rentRange"))
            {
                var Less500k = 0;
                var Between500k_1M = 0;
                var Between_1M_2M = 0;
                var Morethan2M = 0;

                foreach (BusinessPremises b in mng.RetrieveAll())
                {
                    if (b.AlquilerAmount <= 500000)
                    {
                        Less500k++;
                    }
                    else if (b.AlquilerAmount > 500000 && b.AlquilerAmount <= 1000000)
                    {
                        Between500k_1M++;
                    }
                    else if (b.AlquilerAmount > 1000000 && b.AlquilerAmount <= 2000000)
                    {
                        Between_1M_2M++;
                    }
                    else if (b.AlquilerAmount > 2000000)
                    {
                        Morethan2M++;
                    }
                }
                var lst = new List<int>
            {
                Less500k,
                Between500k_1M,
                Between_1M_2M,
                Morethan2M
            };
                apiResp.Data = lst;
            }
            else
            {
                apiResp.Message = "Statistic not found";
            }
            return Ok(apiResp);
        }




        public IHttpActionResult Post(BusinessPremises business)
        {
            try
            {
                var mng = new BusinessPremisesManagement();
                mng.Create(business);
                apiResp = new ApiResponse();
                apiResp.Data = "El local se ha registrado";

                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Put(BusinessPremises business)
        {
            try
            {
                var mng = new BusinessPremisesManagement();
                mng.Update(business);
                apiResp = new ApiResponse();
                apiResp.Data = "El local se ha modificado";

                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        public IHttpActionResult Delete(BusinessPremises business)
        {
            try
            {
                var mng = new BusinessPremisesManagement();
                mng.Delete(business);
                apiResp = new ApiResponse();
                apiResp.Data = "El local se ha desactivado";

                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        [Route("api/BusinessPremises/Activar")]
        [HttpPut]
        public IHttpActionResult Activar(BusinessPremises business)
        {
            try
            {
                var mng = new BusinessPremisesManagement();
                mng.Activar(business);
                apiResp = new ApiResponse();
                apiResp.Data = "El local se ha activado";

                return Ok(apiResp);
            }
            catch (BussinessException ex)
            {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }
    }
}
