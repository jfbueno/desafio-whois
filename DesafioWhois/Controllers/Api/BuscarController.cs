using DesafioWhois.Helpers;
using DesafioWhois.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;


namespace DesafioWhois.Controllers.Api
{
    public class BuscarController : ApiController
    {
        private DominiosRepo _repoDominios = new DominiosRepo();
        
        public async Task<RetornoDominio> Get([FromUri] string dominio)
        {
            var registroCacheado = await _repoDominios.BuscarPorDominio(dominio);            
            
            if(registroCacheado?.CacheExpirado ?? true)
            {
                Dominio model = await ApiWrapper.BuscarInformacoes(dominio);

                if (registroCacheado != null)
                    model.Id = registroCacheado.Id;

                await _repoDominios.InserirAtualizar(model);

                return new RetornoDominio { Dado = model, Cacheado = false };
            }

            return new RetornoDominio { Dado = registroCacheado, Cacheado = true };
        }

        public async Task<Dominio> AtualizarCacheInterno()
        {
            return null;
        }
    }
}
