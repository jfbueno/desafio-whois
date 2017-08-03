using DesafioWhois.Helpers;
using DesafioWhois.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;


namespace DesafioWhois.Controllers.Api
{
    public class BuscarController : ApiController
    {
        private readonly DominiosRepo _repoDominios = new DominiosRepo();
        
        public async Task<IHttpActionResult> Get([FromUri] string dominio)
        {
            var registroCacheado = await _repoDominios.BuscarPorDominio(dominio);            
            
            if(registroCacheado?.CacheExpirado ?? true)
            {
                Dominio model = await ApiWrapper.BuscarInformacoes(dominio);

                if (registroCacheado != null)
                    model.Id = registroCacheado.Id;

                await _repoDominios.InserirAtualizar(model);

                return Ok(new RetornoDominio { Dado = model, Cacheado = false });
            }

            return Ok(new RetornoDominio { Dado = registroCacheado, Cacheado = true });
        }

        [HttpPost, Route("api/AtualizarCache")]
        public async Task<IHttpActionResult> AtualizarCache([FromUri] string idRegistro)
        {
            var registro = await _repoDominios.BuscarPorId(idRegistro);

            if (registro == null)
                return NotFound();

            Dominio model = await ApiWrapper.BuscarInformacoes(registro.NomeDominio);
            await _repoDominios.InserirAtualizar(model, idRegistro);

            return Ok(new RetornoDominio { Dado = model, Cacheado = false });
        }
    }
}
