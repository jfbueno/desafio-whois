using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DesafioWhois.Models
{
    public class Dominio
    {
        public BsonObjectId Id { get; set; }
        
        public string NomeDominio { get; set; }
                
        public DateTime? DataCriacao { get; set; }
        
        public DateTime? DataExpiracao { get; set; }
        
        public DateTime? DataAtualizacao { get; set; }
        
        public IEnumerable<string> NameServers { get; set; }
        
        public IEnumerable<string> Emails { get; set; }
        
        public string RawInfo { get; set; }
        
        public IEnumerable<Contato> Contatos { get; set; }

        public DateTime ExpiracaoCacheInterno { get; set; }

        public bool Registrado { get; set; }

        public bool CacheExpirado => DateTime.Today > ExpiracaoCacheInterno;
    }    
}