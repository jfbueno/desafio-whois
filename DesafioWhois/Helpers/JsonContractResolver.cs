using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWhois.Helpers
{
    public class JsonContractResolver : DefaultContractResolver
    {
        private Dictionary<string, string> Mapping { get; set; }

        public JsonContractResolver()
        {
            Mapping = new Dictionary<string, string>
            {
                {"NomeDominio", "domain_name"},
                {"DataCriacao", "date_created"},
                {"DataExpiracao", "date_expires"},
                {"DataAtualizacao", "date_updated"},
                {"NameServers", "nameservers"},
                {"Emails", "emails"},
                {"RawInfo", "whois_raw_parent"},
                {"Contatos", "contacts"},
                {"Nome", "name"},
                {"Tipo", "type"},
                {"Organizacao", "organization"},
                {"Fone", "phone"},
                {"Email", "email"},
                {"EnderecoCompleto", "full_address"},
            };
        }

        protected override string ResolvePropertyName(string nomePropriedade)
        {
            string nome = null;
            var resolved = Mapping.TryGetValue(nomePropriedade, out nome);

            return (resolved) ? nome : base.ResolvePropertyName(nomePropriedade);
        }
    }
}