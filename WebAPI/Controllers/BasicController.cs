using System;
using System.Web.Http;
using CoreAPI;
using Exceptions;
using WebAPI.Models;

namespace WebAPI.Controllers {
    public abstract class BasicController<T, TMn> : ApiController where T : new() where TMn : Manager<T>, new() {

        public readonly ApiResponse ApiResp = new ApiResponse();
        public          TMn         Mng;
        protected BasicController() { Mng = new TMn(); }

        // GET: api/Basic
        /// <summary>
        ///     Retorna una lista con todos los elementos de sta entidad
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get() {
            ApiResp.Data = Mng.RetriveAll();
            return Ok(ApiResp);
        }

        // GET: api/Basic/5
        /// <summary>
        ///     Retorna una elemnto con el indentificador ingresado
        /// </summary>
        /// <param name="id">Identificador especificao del elemento consultado</param>
        /// <returns></returns>
        public abstract IHttpActionResult Get(string id);

        // POST: api/Basic
        /// <summary>
        ///     Guarda la información de una entidad en la base de datos
        /// </summary>
        /// <param name="e">Entidad que contiene la informacion a ingresar</param>
        /// <returns></returns>
        public IHttpActionResult Post(T e) {
            try {
                Mng.Create(e);
                ApiResp.Message = "Registro exitoso";
                ApiResp.Data    = null;
                return Ok(ApiResp);
            }
            catch (BussinessException ex) {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        // PUT: api/Basic/5
        /// <summary>
        ///     Modifica Lainformacion de la entidad especificada
        /// </summary>
        /// <param name="e">Entidad que contiene la informacion a modificar</param>
        /// <returns></returns>
        public IHttpActionResult Put(T e) {
            try {
                Mng.Update(e);
                ApiResp.Message = "Modificación exitosa";
                ApiResp.Data    = null;
                return Ok(ApiResp);
            }
            catch (BussinessException ex) {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

        // DELETE: api/Basic/5
        /// <summary>
        ///     Elimina una entidad especificada de la base de datos
        /// </summary>
        /// <param name="e">Entidad que se desea eliminar de la base de datos</param>
        /// <returns></returns>
        public IHttpActionResult Delete(T e) {
            try {
                Mng.Delete(e);
                ApiResp.Data    = null;
                ApiResp.Message = "Elemento eliminado";
                return Ok(ApiResp);
            }
            catch (BussinessException ex) {
                return InternalServerError(new Exception(ex.ExceptionId + "-" + ex.AppMessage.Message));
            }
        }

    }
}
