using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api_Auditoria.Controllers.v1
{
    /// <summary>
    /// Recurso controlador dos logs de auditoria
    /// </summary>
    [Route("publico/v1/auditoria")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private static List<auditoria> _listaLog = null;
        private static List<auditoria> ListaLog
        {
            get
            {
                if (_listaLog == null)
                    _listaLog = new List<auditoria>();

                return _listaLog;
            }
        }

        /// <summary>
        /// Incluir um novo Log de auditoria.
        /// </summary>
        /// <param name="auditoria">Informação a ser incluída</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] auditoria auditoria)
        {
            ListaLog.Add(auditoria);
            return Ok();
        }

        /// <summary>
        /// Obter transações feitas por um usuário.
        /// </summary>
        /// <param name="idusuario">Id do usuário.</param>
        /// <returns></returns>
        [HttpGet, Route("{idusuario}")]
        public ActionResult Post(long idusuario)
        {
            return Ok(ListaLog.Where(x => x.idusuario == idusuario));
        }
    }
}