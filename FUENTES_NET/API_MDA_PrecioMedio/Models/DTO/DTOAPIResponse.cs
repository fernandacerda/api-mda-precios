using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_MDA_PrecioMedio.Models.DTO
{
    public class DTOAPIResponse
    {
        public string data { get; set; }
        public string timestamp { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public string param { get; set; }
    }
}