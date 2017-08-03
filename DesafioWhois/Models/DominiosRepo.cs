using DesafioWhois.Helpers;
using DesafioWhois.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;

namespace DesafioWhois
{
    public class DominiosRepo
    {
        private readonly IMongoClient _client = new MongoClient(MongoConfig.Url);
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Dominio> _collection;

        public DominiosRepo()
        {
            _database = _client.GetDatabase(MongoConfig.DbName);
            _collection = _database.GetCollection<Dominio>(MongoConfig.Collection);
        }

        public async Task<Dominio> BuscarPorDominio(string url)
        {
            return await _collection.Find(x => x.NomeDominio == url).FirstOrDefaultAsync();
        }

        public async Task<Dominio> BuscarPorId(string id)
        {
            return await _collection.Find(x => x.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
        }

        public async Task InserirAtualizar(Dominio dominio, string id = null)
        {
            dominio.ExpiracaoCacheInterno = DateTime.Now.AddDays(10).Date;
            dominio.Id = (id == null) ? new BsonObjectId(ObjectId.GenerateNewId()) : ObjectId.Parse(id);

            await _collection.ReplaceOneAsync(doc => doc.Id == dominio.Id, dominio, new UpdateOptions { IsUpsert = true });
        }
    }
}