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
    public class CoinController : ApiController
    {
        ApiResponse apiResp = new ApiResponse();

        // GET api/coin
        // Retrieve - 
        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new CoinManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        // GET api/coin/5
        // Retrieve by id
        public IHttpActionResult Get(string coinN)
        {
            try
            {
                var mng = new CoinManager();
                var coin = new Coin
                {
                    CoinName = coinN
                };

                coin = mng.RetrieveById(coin);
                apiResp = new ApiResponse();
                apiResp.Data = coin;
                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Coin coin)
        {

            try
            {
                var mng = new CoinManager();
                mng.Create(coin);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Coin coin)
        {
            try
            {
                var mng = new CoinManager();
                mng.Update(coin);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE == delete
        public IHttpActionResult Delete(Coin coin)
        {
            try
            {
                var mng = new CoinManager();
                mng.Delete(coin);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}
