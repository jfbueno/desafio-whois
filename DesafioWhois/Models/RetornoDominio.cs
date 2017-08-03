using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioWhois.Models
{
    public class RetornoDominio
    {
        public Dominio Dado { get; set; }
        public bool Cacheado { get; set; }
    }
}