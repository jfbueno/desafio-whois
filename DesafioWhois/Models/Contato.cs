using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWhois.Models
{
    public class Contato
    {
        public string Nome { get; set; }        
        public string Tipo { get; set; }        
        public string Organizacao { get; set; }        
        public string Fone { get; set; }        
        public string Email { get; set; }        
        public string EnderecoCompleto { get; set; }
    }
}