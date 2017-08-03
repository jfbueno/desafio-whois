using DesafioWhois.Helpers;
using DesafioWhois.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DesafioWhois
{
    public class DominiosRepo
    {
        private IMongoClient _client = new MongoClient(MongoConfig.Url);
        private IMongoDatabase _database;
        private IMongoCollection<Dominio> _collection;

        public DominiosRepo()
        {
            _database = _client.GetDatabase(MongoConfig.DbName);
            _collection = _database.GetCollection<Dominio>(MongoConfig.Collection);
        }

        public async Task<Dominio> BuscarPorDominio(string url)
        {
            return await _collection.Find(x => x.NomeDominio == url).FirstOrDefaultAsync();
        }

        public async Task InserirAtualizar(Dominio dominio)
        {
            dominio.ExpiracaoCacheInterno = DateTime.Now.AddDays(10);
            await _collection.InsertOneAsync(dominio);
        }

        public async Task Atualizar()
        {
            //await _collection.UpdateOneAsync()
        }
    }
}